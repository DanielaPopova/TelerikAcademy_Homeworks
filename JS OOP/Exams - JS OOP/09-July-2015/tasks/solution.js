function solve() {

	const VALIDATOR = {
		isNonEmptyString: function(str){
			if(str.length === 0 || !str.trim()){
				throw new Error('Value should be a non-empty string!');
			}
		},
		isStringLengthInRange: function(str, min, max){
			if(typeof str !== 'string' || str.length < min || str.length > max){
				throw new Error('Length must be in range!');
			}
		},
		isIsbnValid: function(str){
			if(typeof str !== 'string' || !str.match(/^([0-9]{10}|[0-9]{13})$/)) {
				throw new ERROR('Isbn should consist of exactly 10 or 13 symbols!');
			}
		},		
		isPositiveNumber: function(num){
			if(typeof num !== 'number' || num <= 0){
				throw new Error('Number must be positive!');
			}
		},
		isNumberInRange: function(num, min, max){
			if(typeof num !== 'number' || num < min || num > max){
				throw new Error('Number must be in range!');		
			}
		}
	}

	const generateId = (function() {
		let count = 0;
		return function () {
			return count += 1;
		};
	})();

	class Item{
		constructor(name, description){
			this.name = name;			
			this.description = description;
			this._id = generateId();			
		}
		
		get name() {
			return this._name;
		}

		set name(x) {
			VALIDATOR.isStringLengthInRange(x, 2, 40);
			this._name = x;
		} 

		get description() {
			return this._description;
		}

		set description(x) {
			VALIDATOR.isNonEmptyString(x);
			this._description = x;
		}

		get id() {
			return this._id;
		}		
	}

	class Book extends Item{
		constructor(name, isbn, genre, description){
			super(name, description);
			this.isbn = isbn;
			this.genre = genre;
		}

		get isbn(){
			return this._isbn;
		}

		set isbn(x){
			VALIDATOR.isIsbnValid(x);			
			this._isbn = x;
		}

		get genre(){
			return this._genre;
		}

		set genre(x){
			VALIDATOR.isStringLengthInRange(x, 2, 20);
			this._genre = x;
		}
	}

	class Media extends Item{
		constructor(name, rating, duration, description){
			super(name, description);
			this.duration = duration;
			this.rating = rating;
		}

		get rating(){
			return this._rating;
		}

		set rating(x){
			VALIDATOR.isNumberInRange(x, 1, 5);
			this._rating = x;
		}

		get duration(){
			return this._duration;
		}

		set duration(x){
			VALIDATOR.isPositiveNumber(x);			
			this._duration = x;
		}
	}

	class Catalog{
		constructor(name){
			this.name = name;
			this._id = generateId();
			this._items = [];
		}

		get name(){
			return this._name;
		}

		set name(x){
			VALIDATOR.isStringLengthInRange(x, 2, 40);
			this._name = x;
		}

		get id(){
			return this._id;
		}

		get items(){
			return this._items;
		}
		
		add(...items){
			
			if(Array.isArray(items[0])){
				items = items[0];
			}

			if(!items.length){
				throw new Error('There are no items!');
			}

			items.forEach(item => {
				try{
					let testItem = new Item(item.name, item.description)
				} catch(error){
					error.message = 'Items must be of Item instance!';
					throw error;
				}				
			});

			this._items.push(...items);	

			return this;		
		}

		find(params){

			function findById(id){
				if(!id || typeof id !== 'number'){
					throw new Error('Invalid id!');
				}

				let item = this._items.find(item => item.id === id);

				return item === undefined ? null : item;
			}

			function findByOptions(options){
				return this._items.filter(function (item) {
					if ((!options.id || options.id === item.id) &&
						(!options.name || options.name === item.name)) {
						return item;
					}
				});
			}
			
			if(typeof params === 'object'){
				return findByOptions.call(this, params);
			} else {
				return findById.call(this, params);
			}
		}

		search(pattern){
			if(!pattern.length || !pattern.trim()){
				throw new Error('Invalid pattern!');
			}		
			return this._items.filter(item => item.name.includes(pattern) || item.description.includes(pattern));
		}
	}

	class BookCatalog extends Catalog{
		constructor(name){
			super(name);
		}

		add(...books){

			if(Array.isArray(books[0])){
				books = books[0];
			}

			if(!books.length){
				throw new Error('There are no books!');
			}

			books.forEach(book => {
				try{
					let testbook = new Book(book.name, book.isbn, book.genre, book.description)
				} catch(error){
					error.message = 'Item must be of Book instance!';
					throw error;
				}				
			});

			return super.add(books)
		}

		getGenres(){
			return this._items.map(item => item.genre.toLowerCase())
				.sort()
				.filter((genre, index, genres) => index === 0 || genre !== genres[index - 1]);
		}

		find(params){
			if (typeof params === 'object'){
				return this._items.filter(function (book) {
					if ((!params.id || params.id === book.id) &&
						(!params.name || params.name === book.name) &&
						(!params.genre || params.genre === book.genre)) {
						return book;
					}
				}); 
			}

			return super.find(params);
		}
	}

	class MediaCatalog extends Catalog{
		constructor(name){
			super(name);
		}

		add(...media){

			if(Array.isArray(media[0])){
				media = media[0];
			}

			if(!media.length){
				throw new Error('There is no media!');
			}

			media.forEach(item => {
				try{
					let testItem = new Media(item.name, item.rating, item.duration, item.description)
				} catch(error){
					error.message = 'Items must be of Item instance!';
					throw error;
				}				
			});

			this._items.push(...media);	

			return this;		
		}

		getTop(count){
			if(typeof count !== 'number' || count < 1){
				throw new Error('Count must be a number bigger then 1!');
			}

			return this._items.sort((a, b) => b.rating - a.rating)
				.map(media => {
					return {
						name: media.name,
						id: media.id
					}
				}).slice(0, count);
		}

		getSortedByDuration(){
			return this._items.sort((a, b) => {
				let comparator = b.duration - a.duration;
				if(comparator === 0){
					return a.id - b.id;
				}
				return comparator;
			});
		}

		find(params){
			if (typeof params === 'object'){
				return this._items.filter(function (media) {
					if ((!params.id || params.id === media.id) &&
						(!params.name || params.name === media.name) &&
						(!params.rating || params.rating === media.rating)) {
						return media;
					}
				}); 
			}

			return super.find(params);
		}
	}

	return {
		getBook: function (name, isbn, genre, description) {
			return new Book(name, isbn, genre, description);
		},
		getMedia: function (name, rating, duration, description) {
			return new Media(name, rating, duration, description);
		},
		getBookCatalog: function (name) {
			return new BookCatalog(name);
		},
		getMediaCatalog: function (name) {
			return new MediaCatalog(name)
		}
	};
}

module.exports = solve;
