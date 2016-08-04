var game = new Phaser.Game(800, 600, Phaser.AUTO, '', { preload: preload, create: create, update: update });

function preload() {
    game.load.image('sky', 'sprites/sky.png');
    game.load.image('ground', 'sprites/platform.png');
    game.load.image('star', 'sprites/star.png');
    game.load.image('health', 'assets/health.png');
    game.load.image('live', 'assets/live.png');    
    game.load.spritesheet('baddie', 'sprites/baddie.png', 33, 32);
    game.load.spritesheet('player', 'assets/player.png', 49, 63);
}

var player;
var baddie;
var platforms;
var cursors;

var hearts;
var lives;
var stars;
var score = 0;
var scoreText;
var stateText;
var healthText;
var countOverlap = 0;
var hits = 0;

function create() {

    game.physics.startSystem(Phaser.Physics.ARCADE);

    //  A simple background for our game
    game.add.sprite(0, 0, 'sky'); 

    // Add platforms
    platforms = game.add.group();

    //  We will enable physics for any object that is created in this group
    platforms.enableBody = true;

    // Here we create the ground.
    var ground = platforms.create(0, game.world.height - 64, 'ground');

    //  Scale it to fit the width of the game (the original sprite is 400x32 in size)
    ground.scale.setTo(2, 2);

    //  This stops it from falling away when you jump on it
    ground.body.immovable = true;

    //  Now let's create two ledges
    var ledge = platforms.create(400, 400, 'ground');

    ledge.body.immovable = true;

    ledge = platforms.create(-150, 250, 'ground');

    ledge.body.immovable = true;

    // Adding PESHO and baddie
     player = game.add.sprite(5, game.world.height - 150, 'player');

     baddie = game.add.sprite(game.world.width - 50, game.world.height - 230, 'baddie');

    //  enable physics on the player/baddie
    game.physics.arcade.enable(player);
    game.physics.arcade.enable(baddie);

     //  Player 
    player.body.gravity.y = 400;
    player.body.collideWorldBounds = true;
    //player.alpha = 1;
    //player.hittimer = 0;
    //  Our two animations, walking left and right.
    player.animations.add('left', [4, 3, 2, 1, 0], 14, true);
    player.animations.add('right', [6, 7, 8, 9, 10], 14, true);
    player.animations.add('jump_right', [11], 14, true);
    player.animations.add('jump_left', [12], 14, true);
    player.animations.add('dead', [13], 14, true);

    baddie.body.collideWorldBounds = true;    

    baddie.animations.add('move', [0, 1], 4, true);
    baddie.animations.play('move',3,true);
    
    game.add.tween(baddie).to( { x: 400}, 3000, Phaser.Easing.Quadratic.InOut, true, 0, 1000, true);

    //Add hearts
    hearts = game.add.group();
    hearts.enableBody = true;

    for (i = 0; i < 2; i += 1) {
        var heart = hearts.create(((Math.random() * (game.world.width / 2) | 0) + game.world.width - 400), game.world.height - 100, 'health');    
        
    }
    healthText = game.add.text(14, 40, 'Lives: ', { font: 'bold 24px Consolas', fill: '#000'});

    //Add lives 
    lives = game.add.group();
    for (i = 0; i < 3; i += 1) {
        var live = lives.create(game.world.width - 700 + (40 * i), 35, 'live');
        live.scale.setTo(0.9, 0.9);
    }

    // Add stars to collect
    stars = game.add.group();

    // Enable physics for any star in this group
    stars.enableBody = true;

    //  Create 12 stars evenly spaced apart
    for (var i = 0; i < 12; i++)
    {
        //  Create a star inside of the 'stars' groupp
        var star = stars.create(i * 30, 0, 'star');

        //  Let gravity do its thing
        star.body.gravity.y = 300;

        //  This just gives each star a slightly random bounce value
        star.body.bounce.y = 0.5 + Math.random() * 0.2;
    }

    scoreText = game.add.text(14, 14, 'Score: 0', { font: 'bold 24px Consolas', fill: '#000'});

    // Add state text    
    stateText = game.add.text(game.world.centerX,game.world.centerY,' ', { font: 'bold 24px Consolas', fill: '#000'});
    stateText.anchor.setTo(0.5, 0.5);
    stateText.visible = false;

    cursors = game.input.keyboard.createCursorKeys();
    
}

function update() {
  //  PESHO and platforms -need group from Stoyan
    game.physics.arcade.collide(stars, platforms);    

    game.physics.arcade.collide(player, platforms);

      //  Checks to see if the player overlaps with any of the stars, if he does call the collectStar function
      game.physics.arcade.overlap(player, stars, collectStar, null, this);

      //  Checks to see if the player overlaps with any of the hearts, if he does call the heal function
      game.physics.arcade.overlap(player, hearts, heal, null, this);

    if (player.alive) {

        player.body.velocity.x = 0;
        player.enableBody = true;
        player.alpha = 1;

        if (cursors.left.isDown)
        {
            //  Move to the left
            if (player.body.touching.down) {
              player.animations.play('left');
            } else {
              player.animations.play('jump_left');
            }

            player.body.velocity.x = -200;

        }
        else if (cursors.right.isDown)
        {
            //  Move to the right
            if (player.body.touching.down) {
              player.animations.play('right');
            } else {
              player.animations.play('jump_right');
            }
            
            player.body.velocity.x = 200;

        } else {
            //  Stand still
            player.animations.stop();

            player.frame = 5;
        }
        
        //  Allow the player to jump if he is touching the ground.
        if (cursors.up.isDown && player.body.touching.down)
        {
            player.body.velocity.y = -350;
        } 

        if (checkOverlap(player, baddie))
        {
            countOverlap += 1;
            player.enableBody = false;
            player.play('dead');
            player.alpha = 0.8;

            if (countOverlap === 1) {

                hits += 1; 
               
                if (hits <= 3) {
                    live = lives.getFirstAlive();

                    if (live)
                    {
                        live.kill();
                    }
                }

                if (hits === 3) {
                    player.kill();
                    hits = 0;

                    stateText.text=" GAME OVER \n Click to restart";
                     stateText.visible = true;

                    //the "click to restart" handler
                     game.input.onTap.addOnce(restart,this);
                } 
                
            } 
        }
        else
        {
            player.enableBody = true;
            player.alpha = 1;
            countOverlap = 0;
        }
    }

}

function calculateDistance(spriteA, spriteB) {
    var distance = game.math.distance(spriteA.body.x + spriteA.body.width, spriteA.body.y + spriteA.body.height,
                                      spriteB.body.x + spriteB.body.width, spriteB.body.y + spriteB.body.height);

    return game.math.roundTo(distance, 0);
}

function checkOverlap(spriteA, spriteB) {

    var boundsA = spriteA.getBounds();
    var boundsB = spriteB.getBounds();

    return Phaser.Rectangle.intersects(boundsA, boundsB);

}

function collectStar (player, star) {
    
    // Removes the star from the screen
    star.kill();

    //  Add and update the score
    score += 10;
    scoreText.text = 'Score: ' + score;

}

function heal (player, heart) {
    
    //heart.kill();
    // Removes the heart from the screen
    live = hearts.getFirstAlive();
    live.kill();
    if (lives.countLiving < 3) {
        live.revive();
    }

    //  Add and update to the health
    // if (lives.countLiving < 3) {
        
    //     var live = lives.create(game.world.width - 200, 35, 'live');
        
        
    // }

    //healthText.text = 'Health: ' + player.health;

}

function collectKey() {
  // body...
}


function restart () {

    //  A new level starts
    
    //resets the life count
    lives.callAll('revive'); 

    //revives the player
    player.x = 5;
    player.y = game.world.height - 150;
    player.alpha = 1;
    
    player.revive();

    //hides the text
    stateText.visible = false;

    // reset the score
    score = 0;
    scoreText.text = 'Score: ' + score;

}