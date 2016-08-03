var game = new Phaser.Game(800, 600, Phaser.AUTO, '', { preload: preload, create: create, update: update });

function preload() {
    game.load.image('sky', 'sprites/sky.png');
    game.load.image('ground', 'sprites/platform.png');
    game.load.image('star', 'sprites/star.png');
    game.load.image('health', 'assets/health.png');
    game.load.image('live', 'assets/live.png');
    //game.load.spritesheet('dead', 'assets/dead.png');
    game.load.spritesheet('baddie', 'sprites/baddie.png', 33, 32);
    game.load.spritesheet('player', 'assets/player.png', 49, 63);
}

var player;
var baddie;
var platforms;
var cursors;

var hearts;
var lives = 3;
var stars;
var score = 0;
var scoreText;
var stateText;
var healthText;

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
//player.body.x, player.body.y-20, player.body.width, player.body.height+20

    //player.hitArea = new Phaser.Rectangle(player.body.x, player.body.y, player.body.width, player.body.height);
    //console.log(player.hitArea);
  // Add health to player
    //player.health = 3;
    //player.maxHealth = 3;
    // Adding baddie


    baddie.body.collideWorldBounds = true;    

    baddie.animations.add('move', [0, 1], 4, true);
    baddie.animations.play('move',3,true);
//this.sprite.body.center.x-10, this.sprite.body.center.y-20, 20, 36

    //baddie.hitArea = new Phaser.Rectangle(baddie.body.x, baddie.body.y, baddie.body.width, baddie.body.height);
    //console.log(baddie.hitArea);
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
        //live.anchor.setTo(0.5, 0,5);
        live.scale.setTo(0.9, 0.9);

    }

    //  Finally some stars to collect
    stars = game.add.group();

    //  We will enable physics for any star that is created in this group
    stars.enableBody = true;

    //  Here we'll create 12 of them evenly spaced apart
    for (var i = 0; i < 12; i++)
    {
        //  Create a star inside of the 'stars' group
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
      game.physics.arcade.collide(player, hearts, heal, null, this);

      // Damage from baddie or spike
      //game.physics.arcade.overlap(player, baddie, takeDamage, null, this);

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
            player.enableBody = false;
            player.play('dead');
            player.alpha = 0.8;
            
            // game.time.events.add(Phaser.Timer.SECOND * 1, function () {
            //     live = lives.getFirstAlive();

            //     if (live)
            //     {
            //         live.kill();
            //     }
            // }, this);
            

            live = lives.getFirstAlive();

            if (live)
            {
                live.kill();
            }

            // if (lives.countLiving() < 1)
            // {
            //     player.kill();

            //     stateText.text=" GAME OVER \n Click to restart";
            //     stateText.visible = true;

            //     //the "click to restart" handler
            //     game.input.onTap.addOnce(restart,this);
            // }           
        }
        else
        {
            player.enableBody = true;
            player.alpha = 1;
        }
       //  var hitTimer = 0;
       // if (player.alpha == 1 && Phaser.Rectangle.intersects(player.hitArea, baddie.hitArea))
       //  {
         

       //              player.enableBody = false;
         
       //              player.alpha = 0.5;
       //              hitTimer = game.time.now + 2500;

       //  } else {
       //          player.enableBody = true;
       //          player.alpha = 1;
       //          hitTimer = 0;
       //  }
                    
               
        

    }

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
    
    heart.kill();
    // Removes the heart from the screen
    //hearts.getFirstAlive().kill();

    //  Add and update to the health
    // if (lives.countLiving < 3) {
        
    //     var live = lives.create(game.world.width - 200, 35, 'live');
        
        
    // }

    //healthText.text = 'Health: ' + player.health;

}

function takeDamage() {
   
   // if (player.body.x + player.width <= baddie.body.x) {
    
   //  console.log('player' + player.body.x );
   //  console.log('baddie' + baddie.body.x);
        player.enableBody = false;
        player.alpha = 0.5;

        // if (player.body.x + player.body.width / 2 > baddie.body.x ) {
        //     console.log('baddieSec' + baddie.body.x);
        //     console.log('playerSec' + player.body.x);
        //     player.enableBody = true;
        //     player.alpha = 1;
        // }
   //} 
   // if (player.body.x > baddie.body.x) {
   //       console.log('baddieLeft' + baddie.body.x);
   //          console.log('playerLeft' + player.body.x);
   //          player.enableBody = false;
   //          player.alpha = 0.5;
            

   //      if (baddie.body.x + baddie.body.width / 2 > player.body.x) {
   //          console.log('baddieLEftSec' + baddie.body.x);
   //          console.log('playerLeftSec' + player.body.x);
   //          player.enableBody = true;
   //          player.alpha = 1;
   //      }
   // }
        
        
    
   
      
    
    
    //player.hittimer = game.time.now + 2500;   
    live = lives.getFirstAlive();

    if (live)
    {
        live.kill();
    }

    

    // if (lives.countLiving() < 1)
    // {
    //     player.kill();

    //     stateText.text=" GAME OVER \n Click to restart";
    //     stateText.visible = true;

    //     //the "click to restart" handler
    //     game.input.onTap.addOnce(restart,this);
    // }
    

    
}

function collectKey() {
  // body...
}
// load dead png
//load live ong - fix lives
// fix falling down of a platform
//  game.camera.follow(player, Phaser.Camera.FOLLOW_LOCKON, 0.1);

function restart () {

    //  A new level starts
    
    //resets the life count
    lives.callAll('revive'); 

    //revives the player
    player.x = 5;
    player.y = game.world.height - 150;
    player.alpha = 1;
    //player.hittimer = 0;
    player.revive();

    //hides the text
    stateText.visible = false;

    // reset the score
    score = 0;
    scoreText.text = 'Score: ' + score;

}