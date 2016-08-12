window.onload = function () {
    var game = new Phaser.Game(1024, 500, Phaser.CANVAS, '', { preload: preload, create: create, update: update });

    function preload() {

        game.load.tilemap('level1', 'scripts/level1.json', null, Phaser.Tilemap.TILED_JSON);
        game.load.spritesheet('healthBar', 'assets/game-sources/health-bar.png', 36, 30);
        game.load.image('life', 'assets/game-sources/life.png');
        game.load.image('key', 'assets/game-sources/key.png');
        game.load.image('bossBullets', 'assets/game-sources/undefined.png');
        game.load.image('boss', 'assets/game-sources/boss.png');
        game.load.image('zero', 'assets/game-sources/zero.png');
        game.load.image('one', 'assets/game-sources/one.png');
        game.load.spritesheet('player', 'assets/game-sources/player.png', 49, 63);
        game.load.image('background', 'assets/game-sources/bg.png');
        game.load.image('sci-fi', 'assets/game-sources/TileSets/scifi_platformTiles_32x32.png');
        game.load.image('trapsSprite', 'assets/game-sources/TileSets/TrapsSprite.png');
        game.load.image('octo-cat', 'assets/game-sources/robo-octocat-small.png');
        game.load.image('javascript', 'assets/game-sources/js.png');
        game.load.image('css', 'assets/game-sources/css3.png');
        game.load.image('html', 'assets/game-sources/html5.png');
        game.load.image('doorImage', 'assets/game-sources/door.png');
    }

    var player,
        cursors,
        spaceKey,
        lives = 3,
        healthBar = [],
        js,
        allLivesOnMap,
        key,
        isKeyTaken = false,
        score = 0,
        scoreText,
        stateText,
        stateTextBar,
        keyText,
        keyBar,
        keyTextBar,
        keyTextStyle,
        healthText,
        layer,
        map,
        badDudes,
        trapsLayer,
        countOverlap = 0,
        hits = 0,
        boss,
        bossSpeed = 400,
        bossMove,
        bullet,
        bullets,
        bulletCount = 0,
        bulletTime = 1000,
        firingTimer = 0,
        zeroes,
        ones,
        zero,
        one,
        zeroCount = 1,
        oneCount = 1,
        takenZero = false,
        takenOne = false,
        door,
        doorObjectFromTileMap,
        winzone,
        doorLayer,
        traps;

    function create() {

        game.physics.startSystem(Phaser.Physics.ARCADE);

        game.stage.backgroundColor = '#787878';
        map = game.add.tilemap('level1');

        //Map images
        map.addTilesetImage('tech', 'sci-fi');
        map.addTilesetImage('traps', 'trapsSprite');
        map.setCollisionByExclusion([13, 14, 15, 16, 46, 47, 48, 49, 50, 51]);
        
        bg = game.add.tileSprite(0, 0, 1024, 500, 'background');
        bg.fixedToCamera = true;
        layer = map.createLayer(0);
        layer.resizeWorld();

        //Door
        doorObjectFromTileMap = map.objects["obj"][0];
        winzone = map.objects['obj'][1];
        trapsLayer = map.objects['TrapsObj'];

        trapsCreation();

        createDoor();

        //Add player
        player = game.add.sprite(64, 128, 'player');

        game.physics.arcade.enable(player);
        player.body.gravity.y = 350;
        player.body.collideWorldBounds = true;

        //Add animations to player
        player.animations.add('left', [4, 3, 2, 1, 0], 14, true);
        player.animations.add('right', [6, 7, 8, 9, 10], 14, true);
        player.animations.add('jump_right', [11], 14, true);
        player.animations.add('jump_left', [12], 14, true);
        player.animations.add('dead', [13], 14, true);

        //Moving with player
        game.camera.follow(player);

        //Add boss
        boss = game.add.sprite(2960, 3050, 'boss');
        game.physics.arcade.enable(boss);

        bossMove = game.add.tween(boss);
        bossMove.to({y: 2820}, bossSpeed,Phaser.Easing.Linear.None, true, 0, -1, true);
    
        //Adding bullets, ones and zeroes
        bullets = game.add.group();
        bullets.enableBody = true;
        bullets.physicsBodyType = Phaser.Physics.ARCADE;

        for (var j = 0; j < 50; j++) {
            var b = bullets.create(0, 0, 'bossBullets');
            b.name = 'bossBullets' + j;
            b.exists = false;
            b.visible = false;
        }

        zeroes = game.add.group();
        zeroes.enableBody = true;
        createZero();

        ones = game.add.group();
        ones.enableBody = true;
        createOne();

        //Creating collectabels
        js = game.add.group();
        js.enableBody = true;
        createJSCollectabe();

        css = game.add.group();
        css.enableBody = true;
        createCSSCollectabe();

        html = game.add.group();
        html.enableBody = true;
        createHTMLCollectabe();

         //Add lives
        allLivesOnMap = game.add.group();
        addLiviesOnMap();

        //Add health bar and health text   
        healthText = game.add.text(14, 40, 'Lives: ', { font: 'bold 24px Consolas', fill: '#FFF' });
        healthText.fixedToCamera = true;

        for (var i = 0; i < 3; i += 1) {
            var oneUp;
            oneUp = game.add.sprite(100 + (40 * i), 35, 'healthBar');
            oneUp.animations.add('full', [0]);
            oneUp.animations.add('empty', [1]);
            oneUp.fixedToCamera = true;
            oneUp.animations.play(i < lives ? 'full' : 'empty', 0, false);

            healthBar.push(oneUp);
        }

        //Add key
        key = game.add.sprite(2432, 64, 'key');
        //key = game.add.sprite(400, 100, 'key');

        game.physics.arcade.enable(key);
        key.enableBody = true;

        //Add warning text for key
        keyTextBar = game.add.graphics();
        keyTextBar.beginFill(0x173B0B);
        keyTextBar.drawRoundedRect(220, 288, 300, 50, 10);
        game.physics.arcade.enable(keyTextBar);
        keyTextBar.enableBody = true;
        keyTextBar.fixedToCamera = true;
        keyTextBar.visible = false;

        keyTextStyle = { font: "bold 24px Consolas", fill: "#fff", boundsAlignH: "center", boundsAlignV: "middle" };
        keyText = game.add.text(0, 0, 'Go get the key first!', keyTextStyle);
        keyText.fixedToCamera = true;
        keyText.setTextBounds(220, 288, 300, 50);
        keyText.visible = false;

        //Add bar behind the key
        keyBar = game.add.graphics();
        keyBar.beginFill(0xFFFFFF);
        keyBar.drawCircle(990, 35, 50);
        game.physics.arcade.enable(keyBar);
        keyBar.enableBody = true;
        keyBar.fixedToCamera = true;
        keyBar.visible = false;

        //Add score text        
        scoreText = game.add.text(14, 14, 'Score: 0', { font: 'bold 24px Consolas', fill: '#FFF' });
        scoreText.fixedToCamera = true;

        //Add state text and state text bar
        stateTextBar = createTextBar(300, 150);
        stateText = createText(50, 30, 'GAME OVER\n restart', 300, 150);
        stateText.addColor('#254D61', 9);
        stateText.addFontWeight('normal', 9);        

        //Enable keyboard
        cursors = game.input.keyboard.createCursorKeys();
        spaceKey = game.input.keyboard.addKey(Phaser.Keyboard.SPACEBAR);

        //Create badDudes
        badDudes = game.add.group();
        createBadDudes();

    }   

    function update() {

        //Door - key Handler
        game.physics.arcade.overlap(player, door, tryEnterDoor, null, this);

        //Interaction between player and surroundings
        game.physics.arcade.collide(player, layer);
        game.physics.arcade.overlap(player, allLivesOnMap, heal, null, this);
        game.physics.arcade.overlap(player, key, collectKey, null, this);
        game.physics.arcade.overlap(player, js, collectItem, null, this);
        game.physics.arcade.overlap(player, css, collectItem, null, this);
        game.physics.arcade.overlap(player, html, collectItem, null, this);
        game.physics.arcade.collide(player, traps, takeDamage, null, this);
        game.physics.arcade.overlap(player, zeroes, collectZero, null, this);
        game.physics.arcade.collide(player, ones, collectOne, null, this);

        //Interaction between surroundings and layer
        game.physics.arcade.collide(badDudes, layer);
        game.physics.arcade.collide(js, layer);
        game.physics.arcade.collide(css, layer);
        game.physics.arcade.collide(html, layer);

        //Interaction between player and boss
        game.physics.arcade.overlap(player, boss, takeDamage, null, this);        

        //Boss behaviour
        if (game.time.now > bulletTime) {
            fireBullet();
        }
        
        if(bossSpeed <= 0){
            bossSpeed = 400;
        }

        if(bossSpeed >= 3000){
            bossSpeed = 2600;
        }

        if (takenZero) {

            bossSpeed -= 300;           
            bossMove.updateTweenData('duration', bossSpeed); 
            takenZero = false;

        } else if (takenOne) {

            bossSpeed += 300;            
            bossMove.updateTweenData('duration', bossSpeed);
            takenOne= false;
        }

        //Player behaviour
        if (player.alive) {
            checkIfPlayerReachedTheEndOfTheLevel();

            player.body.velocity.x = 0;
            player.enableBody = true;
            player.alpha = 1;

            if (cursors.left.isDown) {
                //  Move to the left
                if (player.body.onFloor()) {

                    player.animations.play('left');
                    player.body.velocity.x = -200;

                } else {

                    player.animations.play('jump_left');
                    player.body.velocity.x = -150;

                }
            } else if (cursors.right.isDown) {
                //Move to the right
                if (player.body.onFloor()) {

                    player.animations.play('right');
                    player.body.velocity.x = 200;

                } else {

                    player.animations.play('jump_right');
                    player.body.velocity.x = 150;
                }

            } else {
                //Stand still
                player.animations.stop();

                player.frame = 5;
            }

            //Jump
            if (cursors.up.isDown && player.body.onFloor()) {
                player.body.velocity.y = -300;                
            }

            //Interaction between player and enemies
            if (game.physics.arcade.overlap(player, badDudes, collisionHandler, processHandler, this) ||
                game.physics.arcade.overlap(player, bullets, collisionHandler, null, this)) {
                countOverlap += 1;

                player.enableBody = false;
                player.play('dead');

                if (countOverlap === 1) {

                    hits += 1;

                    if (hits <= 3) {
                        lives--;
                        updateLife();
                    }
                }
            }
            else {
                player.enableBody = true;
                countOverlap = 0;
            }
        }

    }

    function collisionHandler(sprite, group) {

        var spriteBounds = sprite.getBounds(),
            groupBounds = group.getBounds();

        return Phaser.Rectangle.intersects(spriteBounds, groupBounds);

    }

    function processHandler(sprite, group) {
        return true;
    }

    function takeDamage() {

        lives = 0;
        updateLife();
        allLivesOnMap.callAll('kill');        
    }

    function updateLife() {

        var total = healthBar.length;
        for (var i = 0; i < total; i += 1) {
            healthBar[i].animations.play(i < lives ? 'full' : 'empty', 0, false);
        }

        if (lives === 0) {

            player.kill();
            hits = 0;
            
            stateText.visible = true;
            stateTextBar.visible = true;
            //the "click to restart" handler            
            game.input.onTap.addOnce(restart, this);

        }
    }

    function heal(player, life) {

        life.kill();
        if (lives < 3) {
            lives += 1;
            hits -= 1;
            updateLife();
        }
    }

    function fireBullet() {
        bulletTime = game.time.now + 2000;

        bulletCount += 1;

        for (var i = 1; i < bulletCount; i += 1) {
            bullet.kill();
        }

        if (game.time.now < bulletTime) {
            bullet = bullets.getFirstExists(false);

            if (bullet) {
                bullet.reset(boss.x - 150, boss.y + 50);
                bullet.body.velocity.x = -300;
            }
        }
    }

    function addLiviesOnMap() {
        var livesCoordinatesX = [2080, 3104, 1216, 64, 2016],
            livesCoordinatesY = [1024, 1184, 1952, 2528, 2240];

        allLivesOnMap.enableBody = true;
        for (var m = 0; m < 5; m += 1) {
            life = allLivesOnMap.create(livesCoordinatesX[m], livesCoordinatesY[m], 'life');
        }
    }

    function createTextBar(barWidth, barHeight) {

        var textBar = game.add.graphics();
        textBar.beginFill(0xF9FAD2);
        textBar.drawRoundedRect(game.width / 2 - barWidth / 2, game.height / 2 - barHeight / 2, barWidth, barHeight, 10);
        game.physics.arcade.enable(textBar);
        textBar.enableBody = true;
        textBar.alpha = 0.9;
        textBar.fixedToCamera = true;        

        textBar.visible = false;

        return textBar;
    }

    function createText(positionX, positionY, textString, width, height) {

        var text = game.add.text(positionX, positionY, textString, { font: 'bolder 40px Consolas', fill: '#11242C' });
        text.setShadow(2, -2, 'rgba(0,0,0,0.5)', 0);
        text.fixedToCamera = true;
        text.setTextBounds(game.width / 2 - width / 2, game.height / 2 - height / 2, width, height);        

        text.visible = false;

        return text;
    }

    function createBadDudes() {

        var startPosition = [[160, 640, 1300],
            [416, 1472, 1408, 192],
            [672, 128, 896],
            [992, 640, 1568],
            [1248, 672, 1376],
            [1504, 992, 928],
            [2496, 704],
            [2816, 1312]];
        var endXPositon = [[1000, 1664],
            [1984,  960,  576],
            [ 384, 1344],
            [ 224, 1792],
            [1056, 1760],
            [1248,  640],
            [ 960],
            [1792]];
        for (var y = 0; y < startPosition.length; y++) {
            for (var x = 1; x < startPosition[y].length; x++) {
                var octoCat = badDudes.create(startPosition[y][x], startPosition[y][0], 'octo-cat');
                octoCat.scale.setTo(0.4, 0.4);
                game.physics.arcade.enable(octoCat);
                octoCat.body.gravity.y = 800;
                octoCat.body.collideWorldBounds = true;
                game.add.tween(octoCat).to({ x: endXPositon[y][x - 1] }, 3000, Phaser.Easing.Linear.None, true, 0, 1000, true);
            }
        }
    }

    function createJSCollectabe() {
        var jsXPosition = [16, 74, 24, 42, 40, 51, 1, 98, 35, 56, 53, 49, 47, 43, 74, 74, 25, 29, 31, 43, 13, 15, 15, 19, 27, 60, 35, 31, 8, 75, 80, 98, 98];
        var jsYPosition = [3, 13, 13, 26, 39, 49, 65, 51, 4, 4, 12, 12, 12, 12, 16, 23, 13, 18, 18, 17, 28, 28, 38, 38, 35, 40, 45, 45, 44, 76, 75, 57, 63];
        for (var i = 0; i < jsXPosition.length; i++) {

            var jsColectable = js.create(jsXPosition[i] * 32, jsYPosition[i] * 32, 'javascript');

        }
    }

    function createCSSCollectabe() {
        var cssXPosition = [36, 30, 14, 74, 28, 60, 8, 76, 98, 15, 58, 52, 50, 46, 44, 74, 24, 74, 25, 42, 44, 42, 16, 18, 40, 34, 32, 81, 98, 98];
        var cssYPosition = [3, 17, 27, 22, 35, 39, 43, 75, 56, 4, 4, 11, 11, 11, 11, 12, 12, 17, 12, 18, 18, 27, 37, 37, 38, 44, 44, 74, 52, 62];
        for (var i = 0; i < cssXPosition.length; i++) {

            var cssColectable = css.create(cssXPosition[i] * 32, cssYPosition[i] * 32, 'css');

        }
    }

    function createHTMLCollectabe() {
        var htmlXPosition = [57, 51, 74, 62, 17, 33, 4, 82, 98, 17, 37, 45, 74, 24, 74, 25, 28, 32, 41, 45, 42, 12, 16, 29, 40, 60, 8, 74, 98, 98];
        var htmlYPosition = [3, 10, 18, 17, 36, 43, 60, 73, 61, 4, 4, 10, 11, 11, 24, 11, 19, 19, 19, 19, 28, 29, 29, 35, 37, 41, 45, 77, 53, 58];
        for (var i = 0; i < htmlXPosition.length; i++) {

            var htmlColectable = html.create(htmlXPosition[i] * 32, htmlYPosition[i] * 32, 'html');

        }
    } 

     function createCollectables() {
        createJSCollectabe();
        createCSSCollectabe();
        createHTMLCollectabe();
    }  

    function createDoor() {
        door = game.add.group();
        door.enableBody = true;

        door.create(doorObjectFromTileMap.x, doorObjectFromTileMap.y, "doorImage");
    } 

    function trapsCreation() {
        traps = game.add.group();
        traps.enableBody = true;

        trapsLayer.forEach(function (currentTrap) {
            traps.create(currentTrap.x, currentTrap.y);
        });
    }

    function createZero() {
        if (zeroCount == 1) {
            zeroCount = 0;
        }
        for (var i = 0; i < 1; i++) {

            zero = zeroes.create(i, i, 'zero');

            zero.x = game.rnd.between(2200, 3010);
            zero.y = game.rnd.between(3000, 3100);

            takenZero = false;

            game.time.events.add(Phaser.Timer.SECOND * 3, zeroHide, this);
        }
    }

    function createOne() {
        if (oneCount == 1) {
            oneCount = 0;
        }
        for (var i = 0; i < 1; i++) {

            one = ones.create(i, i, 'one');

            one.x = game.rnd.between(2200, 3010);
            one.y = game.rnd.between(3000, 3100);

            takenOne = false;

            game.time.events.add(Phaser.Timer.SECOND * 3, oneHide, this);
        }
    }

    function zeroHide() {
        game.add.tween(zero).to({ alpha: 0 }, 1000, Phaser.Easing.Linear.None, true);
        zero.kill();
        createZero();
    }

    function oneHide() {
        game.add.tween(one).to({ alpha: 0 }, 1000, Phaser.Easing.Linear.None, true);
        one.kill();
        createOne();
    }

     function collectZero(player, zero) {
        zeroCount = 1;
        zero.kill();
        takenZero = true;
    }

    function collectOne(player, one) {
        oneCount = 1;
        one.kill();
        takenOne = true;
    }

    function collectKey() {

        isKeyTaken = true;
        keyBar.visible = true;
        game.world.bringToTop(key);
        key.x = 966;
        key.y = 10;
        key.fixedToCamera = true;
    }

    function collectItem(player, item) {

        //Removes the item
        item.kill();

        //Add and update the score
        score += 10;
        scoreText.text = 'Score: ' + score;
    }

    function warningMessage() {
        keyText.visible = true;
        keyTextBar.visible = true;
        game.time.events.add(Phaser.Timer.SECOND * 2, function () {
            keyText.visible = false;
            keyTextBar.visible = false;
        }, this);
    }

    function checkIfPlayerReachedTheEndOfTheLevel() {
        if (player.x === winzone.x && player.y === winzone.y) {
            stateText.text = " YOU WIN! \n restart";
            stateText.visible = true;
            stateTextBar.visible = true;
            boss.kill();
            bullet.kill();
            zero.kill();
            one.kill();
            game.paused = true;
            game.input.onTap.addOnce(restart, this);
        }
    }

    function tryEnterDoor() {
        if (spaceKey.isDown && !isKeyTaken) {
            warningMessage();
        }
        if (!isKeyTaken || !spaceKey.isDown) {
            player.x -= 10;
        } else if (isKeyTaken && spaceKey.isDown) {
            // this will teleport Pesho to the other side of the door
            player.x += 100;
            // this will make the door disappear
            // door.y += 10;
        }
    }

    function restart() {

        //Revives the player
        player.revive();
        player.x = 64;
        player.y = 128;

        //Revives the boss
        bossSpeed = 400;
        boss.revive();
        zero.revive();
        one.revive();

        //Lives reset
        lives = 3;
        hits = 0;
        addLiviesOnMap();
        updateLife();

        game.paused = false;

        //Key reset
        keyBar.visible = false;
        key.fixedToCamera = false;
        key.x = 2432;
        key.y = 64;
        isKeyTaken = false;

        //Hides the text
        stateText.text = "GAME OVER\n restart";
        stateText.visible = false;
        stateTextBar.visible = false;        

        //Reset the score
        js.destroy(false, true);
        html.destroy(false, true);
        css.destroy(false, true);
        score = 0;
        scoreText.text = 'Score: ' + score;
        createCollectables();
    }

}
