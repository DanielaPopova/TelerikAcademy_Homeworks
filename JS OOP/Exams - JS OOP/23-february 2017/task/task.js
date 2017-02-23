//71/100 
function solve() {
	
	const VALIDATOR = {
		isOfTypeString: function(str){
			if(typeof str !== 'string'){
				throw new Error('Value must be a string!');
			}
		},
		isStirngLengthInRange: function(str, min, max){
			if(str.length < min || str.length > max){
				throw new Error('String length must be in range!');
			}
		},
		isConsistedOfValidSymbols: function(str){
			let regex = /[^a-zA-Z0-9\s]/;
			if(str.match(regex)){
				throw new Error('String contains invalid symbols!');
			}
		},
		isNumberPositive: function(num){
			if(typeof num !== 'number' || num < 0){
				throw new Error('Number must be positive!');
			}
		},
		isRatingValid: function(num){
			if(typeof num !== 'number' || num < 1 || num > 10){
				throw new Error('Rating is number between 1 and 10!');
			}
		},
		validateApplication: function(apps){
			if(!Array.isArray(apps)){
				throw new Error('Value must be an array!');
			}

			apps.forEach(function(a){
				try{
					let testApp = new App(a.name, a.description, a.version, a.rating);
				} catch(error){
					error.message = 'Element must be a valid instance of App!';
					throw error;
				}
			});
		}		
	};

	const generateUploadTime = (function(){
		let counter = 1;
		return function(){
			return counter += 1;
		}
	})();

	class App{
		constructor(name, description, version, rating){
			this.name = name;
			this.description = description;
			this.version = version;
			this.rating = rating;
			this._uploadTime = 0;
		}

		get name(){
			return this._name;
		}

		set name(newName){
			VALIDATOR.isOfTypeString(newName);
			VALIDATOR.isStirngLengthInRange(newName, 1, 24);
			VALIDATOR.isConsistedOfValidSymbols(newName);
			this._name = newName;
		}

		get description(){
			return this._description;
		}

		set description(newDes){
			VALIDATOR.isOfTypeString(newDes);
			this._description = newDes;
		}

		get version(){
			return this._version;
		}

		set version(newVersion){
			VALIDATOR.isNumberPositive(newVersion);
			this._version = newVersion;
		}

		get rating(){
			return this._rating;
		}

		set rating(newRating){
			VALIDATOR.isRatingValid(newRating);
			this._rating = newRating;
		}

		release(options){
			if (typeof options === 'number') {
				if (options < this.version) {
					throw new Error('Not e new version!');
				}

				this.version = options;
			} else if (typeof options === 'object'){
				if(!options.version){
					throw new Error('Unspecified value for version!');
				}

				if(options.version < this.version){
					throw new Error('Not e new version!');
				}

				this.version = options.version;

				if(options.hasOwnProperty('description')){
					this.description = options.description;
				}

				if(options.hasOwnProperty('rating')){
					this.rating = options.rating;
				}
			}			
		}
	}

	class Store extends App{
		constructor(name, description, version, rating){
			super(name, description, version, rating);
			this.apps = [];
		}

		get apps(){
			return this._apps;
		}

		set apps(newArr){
			if(!Array.isArray(newArr)){
				throw new Error('Value must be an Array!');
			}
			this._apps = newArr;
		}

		uploadApp(app){
			try{
				let testApp = new App(app.name, app.description, app.version, app.rating)
			} catch(error){
				error.message = 'Passed value must be of type App!';
				throw error;
			}
			
			let foundApp = this.apps.find(a => a.name === app.name);

			if(!foundApp){
				app._uploadTime = generateUploadTime();
				this.apps.push(app);
			} else {
				foundApp.description = app.description;
				foundApp.rating = app.rating;

				if(foundApp.version > app.version){
					throw new Error('This version is old!');
				}
				foundApp.version = app.version
			}

			return this;
		}

		takedownApp(name){
			let index = this.apps.findIndex(a => a.name === name);
			if(index === -1){
				throw new Error('There is no such app with that name!');
			}

			this.apps.splice(index, 1);
			return this;
		}

		search(pattern){			
			return this.apps.filter(function(app){
				return app.name.toLowerCase().indexOf(pattern.toLowerCase()) >= 0;
			}).sort((a, b) => a.name.localeCompare(b.name));
		}

		listMostRecentApps(count){
			count = count || 10;

			let sortedApps = this.apps.sort((a, b) => b._uploadTime - a._uploadTime);

			return sortedApps.splice(0, count);
		}

		listMostPopularApps(count){
			count = count || 10;

			let sortedByRating = this.apps.sort(function(a, b){
                let comparator = b.rating - a.rating;
                if(comparator === 0){
                    return b._uploadTime - a._uploadTime;
                }
                return comparator;
            });

			return sortedByRating.splice(0, count);
		}
	}

	class Device{
		constructor(hostname, apps){
			this.hostname = hostname;
			this.apps = apps;			
		}

		get hostname(){
			return this._hostname;
		}

		set hostname(newHost){
			VALIDATOR.isOfTypeString(newHost);
			VALIDATOR.isStirngLengthInRange(newHost, 1, 32);
			this._hostname = newHost;
		}

		get apps(){
			return this._apps;
		}

		set apps(newApps){
			VALIDATOR.validateApplication(newApps);
			this._apps = newApps;
		}

		search(pattern){			
			let appsWithPattern = this.apps.filter(function(app){
				return app.name.toLowerCase().indexOf(pattern.toLowerCase()) >= 0;
			}).sort((a, b) => a.name.localeCompare(b.name));

			let appsWithPatternAndLattestVersion = [];

			for(let i = 0; i < appsWithPattern.length - 1; i++){
				let currApp = appsWithPattern[i],
					nextApp = appsWithPattern[i + 1];

				if(currApp.name === nextApp.name){
					if(currApp.version > nextApp.version){
						appsWithPatternAndLattestVersion.push(currApp);						
					} else {
						appsWithPatternAndLattestVersion.push(nextApp);
					}
				} else {
					appsWithPatternAndLattestVersion.push(currApp);
				}
			}
			return appsWithPatternAndLattestVersion;
		}

		install(name){
			let appsWithSameName = this.apps.filter(function(a){
				return a.name === name;
			});

			if(appsWithSameName.length === 0){
				throw new Error('There is no app with that name!');
			} else {
				let latestVersion = appsWithSameName.reduce(function(prev, curr){
					return (prev.version > curr.version) ? prev : curr
				});
				this.apps.push(latestVersion);
			}

			return this;
		}

		uninstall(name){
			let index = this.apps.findIndex(a => a.name === name);
			if(index === -1){
				throw new Error('No such app with that name!');
			}
			this.apps.splice(index, 1);
			return this;
		}

		listInstalled(){
			return this.apps.sort((a, b) => a.name.localeCompare(b.name));
		}

		update(){
			
			return this;
		}
	}

	return {
		createApp(name, description, version, rating) {
			return new App(name, description, version, rating);
		},
		createStore(name, description, version, rating) {
			return new Store(name, description, version, rating);
		},
		createDevice(hostname, apps) {
			return new Device(hostname, apps);
		}
	};
}

module.exports = solve;
