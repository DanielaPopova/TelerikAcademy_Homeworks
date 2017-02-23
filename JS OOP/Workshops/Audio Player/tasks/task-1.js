function solve() { 

    const VALIDATOR = {
        isStringLengthValid: function(str){
            if(typeof str !== 'string' || str.length < 3 || str.length > 25){
                throw new Error('String length must be between 3 and 25!');
            }
        },
        isNumberPositive: function(num){
            if(typeof num !== 'number' || num < 0){
                throw new Error('Number must have positive value!');
            }
        },
        isImdbRatingValid: function(num){
            if(typeof num !== 'number' || num < 1 || num > 5){
                throw new Error('Rating must be a number between 1 and 5!');
            }
        }
    }

    const generateId = (function(){
        let count = 1;
        return function(){
            return count +=1;
        }
    })();

    class Player{
        constructor(name){
            this.name = name;
            this._id = generateId();
            this._playlists = [];
        }

        get name(){
            return this._name;  
        }

        set name(newName){
            VALIDATOR.isStringLengthValid(newName);
            this._name = newName;
        }

        get id(){
            return this._id;
        }

        addPlaylist(playlistToAdd){
            
            if(typeof playlistToAdd !== 'object' || !playlistToAdd.name){
                throw new Error('Item must be of type PlayList');
            }

            VALIDATOR.isStringLengthValid(playlistToAdd.name);
            this._playlists.push(playlistToAdd);

            return this;
        }

        getPlaylistById(id){
            let playlistToAdd = this._playlists.find(pl => pl.id === id);

            return playlistToAdd === undefined ? null : playlistToAdd;
        }

        removePlaylist(options){
            let index = 0;
            if (typeof options === 'number') {
                index = this._playlists.findIndex(pl => pl.id === options);
            } else if (typeof options === 'object') {
                index = this._playlists.findIndex(pl => pl.id === playlist.id);
            }

            if (index === -1) {
                throw new Error('There is no such playlist with that id!');
            }

            this._playlists.splice(index, 1);
            return this;
        }

        listPlaylists(page, size){
            if(typeof page !== 'number' || page < 0){
                throw new Error('Page is a positive number!');
            }

            if(typeof size !== 'number' || size <= 0){
                throw new Error('Size is a positive number greater than 0!');
            }

            if((page * size) > this._playlists.length){
                throw new Error('Invalid values for page and size!');
            }

            let sortedList = this._playlists.sort(function(a, b){
                let comparator = a.name - b.name;
                if(comparator === 0){
                    return a.id - b.id;
                }
                return comparator;
            });

            return sortedList.slice((page * size), (page + 1) * size);
        }

        contains(playable, playlist){
            if(!(this._playlists.includes(playlist))){
                throw new Error('This player doesnt have that playlist!');
            }

            let foundItem = playlist._playables.find(pl => pl.title === playable.title && pl.author === playable.author && pl.id === playable.id);

            if(foundItem === undefined){
                return false;
            } else {
                return true;
            }
        }

        search(pattern){
            
            return this._playlists.filter(function(list){
                return list._playables.some(function(playable){
                    return playable.title.toLowerCase().indexOf(pattern.toLowerCase()) >= 0;
                });
            }).map(list => {
                return {
                    name: list.name,
                    id: list.id
                }
            });
        }
    }    

    class PlayList{
        constructor(name){
            this.name = name;
            this._id = generateId();
            this._playables = [];
        }

        get name(){
            return this._name;  
        }

        set name(newName){
            VALIDATOR.isStringLengthValid(newName);
            this._name = newName;
        }

        get id(){
            return this._id;
        }

        addPlayable(playable){
            this._playables.push(playable);

            return this;
        }

        getPlayableById(id){
            let foundItem = this._playables.find(pl => pl.id === id);

            return foundItem === undefined ? null : foundItem;
        }

        removePlayable(options){
            let index = 0;

            if (typeof options === 'number') {
                index = this._playables.findIndex(pl => pl.id === options);

            } else if (typeof options === 'object') {
                index = this._playables.findIndex(pl => pl.id === options.id);
            }

            if (index === -1) {
                throw new Error('There is no such item with that id!');
            }

            this._playables.splice(index, 1);
            return this;
        }

        listPlayables(page, size){
             if(typeof page !== 'number' || page < 0){
                throw new Error('Page is a positive number!');
            }

            if(typeof size !== 'number' || size <= 0){
                throw new Error('Size is a positive number greater than 0!');
            }

            if((page * size) > this._playables.length){
                throw new Error('Invalid values for page and size!');
            }

            let sortedPlayables = this._playables.sort(function(a, b){
                let comparator = a.title - b.title;
                if(comparator === 0){
                    return a.id - b.id;
                }
                return comparator;
            });

            return sortedPlayables.slice((page * size), (page + 1) * size);
        }
    }

    class Playable{
        constructor(title, author){
            this.title = title;
            this.author = author;
            this._id = generateId();
        }

        get title(){
            return this._title;
        }

        set title(newTitle){
            VALIDATOR.isStringLengthValid(newTitle);
            this._title = newTitle;
        }

        get author(){
            return this._author;
        }

        set author(newAuthor){
            VALIDATOR.isStringLengthValid(newAuthor);
            this._author = newAuthor;
        }

        get id(){
            return this._id;
        }

        play(){
            let format = `[${this.id}]. [${this.title}] - [${this.author}]`;
            return format;
        }
    }

    class Audio extends Playable{
        constructor(title, author, length){
            super(title, author);
            this.length = length
        }

        get length(){
            return this._length;
        } 

        set length(newLength){
            VALIDATOR.isNumberPositive(newLength);
            this._length = newLength;
        }  

        play(){ 
            return super.play() + ` - [${this.length}]`;
        }
    }

    class Video extends Playable{
        constructor(title, author, imdbRating){
            super(title, author);
            this.imdbRating = imdbRating;
        }

        get imdbRating(){
            return this._imdbRating;
        }

        set imdbRating(newRating){
            VALIDATOR.isImdbRatingValid(newRating);
            this._imdbRating = newRating;
        }

        play(){
            return super.play() + ` - [${this.imdbRating}]`;
        }
    }

    const module = {
        getPlayer: function (name) {   
            return new Player(name);
        },
        getPlaylist: function (name) {
            return new PlayList(name);
        },
        getAudio: function (title, author, length) {
             return new Audio(title, author, length);
        },
        getVideo: function (title, author, imdbRating) {
            return new Video(title, author, imdbRating);
        }
    };

    return module;
}

module.exports = solve;

let result = solve();
let playerOne = result.getPlayer('Dubstep');
let playerTwo = result.getPlayer('Alternative');
let playlist1 = result.getPlaylist('Red Hot'),
    playlist2 = result.getPlaylist('Arctic Monkeys'),
    playlist3 = result.getPlaylist('ChaseNStatus');

let audio1 = result.getAudio('Do I wanna know', 'Arctic Monkeys', 4),
    audio2 = result.getAudio('Cant stop', 'RHCP', 4.3),
    audio3 = result.getAudio('Did I let you know', 'RHCP', 4.5);

playlist1.addPlayable(audio2).addPlayable(audio3);
playlist2.addPlayable(audio1);

playerOne.addPlaylist(playlist3);
playerTwo.addPlaylist(playlist1).addPlaylist(playlist2);
console.log(playerTwo.search('know'));

