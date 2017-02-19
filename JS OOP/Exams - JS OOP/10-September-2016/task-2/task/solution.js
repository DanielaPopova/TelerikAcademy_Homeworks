function solve() {
    'use strict';

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_ALIGNMENT: 'Alignment must be good, neutral or evil!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!'
    };

    const VALIDATOR = {
        isOfTypeString: function(str){
            if(typeof str !== 'string'){
                throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
            }
        },
        isLengthInRange: function(str, min, max){
            if(str.length < min || str.length > max){
                throw new Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
            }
        },
        hasInvalidSymbols: function(str){
            let regex = /[^a-zA-Z\s]/;
            if(str.match(regex)){            
                throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }
        },
        isPositiveIntegerNumber: function(num){
            if(Number.isNaN(num) || num < 1){
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
        },
        isFunctionWithOneParameter: function(func){
            if(typeof func !== 'function' && func.length !== 1){
                throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
            }
        },
        isValidAlignment: function(align){
            const validValues = ['good', 'neutral', 'evil'];
            let index = validValues.indexOf(align);
            if(index === -1){
                throw new Error(ERROR_MESSAGES.INVALID_ALIGNMENT);
            }
        },
        isValidDamage: function(damage){
            if(Number.isNaN(damage) || damage < 0 || damage > 100){
                throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
            }
        },
        isValidHealth: function(health){
            if(Number.isNaN(health) || health < 0 || health > 200){
                throw new Error(ERROR_MESSAGES.INVALID_HEALTH);
            }
        },
        isCountValid: function(count){
            if(Number.isNaN(count) || count < 0 || (count | 0) !== count){
                throw new Error(ERROR_MESSAGES.INVALID_COUNT);
            }
        },
        isSpeedValid: function(speed){
            if(Number.isNaN(speed) || speed < 0 || speed > 100){
                throw new Error(ERROR_MESSAGES.INVALID_SPEED);
            }
        },
        isValidMana: function(mana){
            if(Number.isNaN(x) || typeof x !== 'number' || x <= 0 ){
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
        }
    };
    
    class Spell{
        constructor(name, manaCost, effect){
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        get name(){
            return this._name;
        }

        set name(x){
            VALIDATOR.isOfTypeString(x);
            VALIDATOR.isLengthInRange(x, 2, 20);
            VALIDATOR.hasInvalidSymbols(x);
            this._name = x;
        }

        get manaCost(){
            return this._manaCost;
        }

        set manaCost(x){
            VALIDATOR.isPositiveIntegerNumber(x);
            this._manaCost = x;
        }

        get effect(){
            return this._effect;
        }

        set effect(x){
            VALIDATOR.isFunctionWithOneParameter(x);
            this._effect = x;
        }
    }

    class Unit{
        constructor(name, alignment){
            this.name = name;
            this.alignment = alignment;
        }

        get name() {
            return this._name;
        }

        set name(x) {
            VALIDATOR.isOfTypeString(x);
            VALIDATOR.isLengthInRange(x, 2, 20);
            VALIDATOR.hasInvalidSymbols(x);
            this._name = x;
        }

        get alignment(){
            return this._alignment;
        }

        set alignment(x){
            VALIDATOR.isOfTypeString(x);
            VALIDATOR.isValidAlignment(x);
            this._alignment = x;
        }
    }

    const generateId = (function(){
        let counter = 0;
        return function(){
            counter += 1;
            return counter;            
        };
    })();

    class ArmyUnit extends Unit{
        constructor(name, alignment, damage, health, count, speed){
            super(name, alignment);
            this._id = generateId();           
            this.damage = damage;
            this.health = health;
            this.count = count;
            this.speed = speed;
        }

        get id(){
            return this._id;
        }

        get damage(){
            return this._damage;
        }

        set damage(x){
            VALIDATOR.isValidDamage(x);
            this._damage = x;
        }

        get health(){
            return this._health;
        }

        set health(x){
            VALIDATOR.isValidHealth(x);
            this._health = x;
        }

        get count(){
            return this._count;
        }

        set count(x){
            VALIDATOR.isCountValid(x);
            this._count = x;
        }

        get speed(){
            return this._speed;
        }

        set speed(x){
            VALIDATOR.isSpeedValid(x);
            this._speed = x;
        }
    }
    
    class Commander extends Unit{
        constructor(name, alignment, mana){
            super(name, alignment);
            this.mana = mana;
            this.spellbook = [];
            this.army = [];
        }

        get mana(){
            return this._mana;
        }

        set mana(x){
            VALIDATOR.isValidMana(x);
            this._mana = x;
        }

        get spellbook(){
            return this._spellbook;
        }

        set spellbook(x){
            this._spellbook = x;
        }

        get army(){
            return this._army;
        }

        set army(x){
            this._army = x;
        }
    }

    const battlemanagerData = {
        commanders: [],
        armyUnitsObj: {},
        armyUnits: [],
    };   

    Array.prototype.filterByProperty = function(query, propName) {
      if(!query.hasOwnProperty(propName)) {
        return this;
      }

      const value = query[propName];
      return this.filter(x => x[propName] === value);
    };

    const battlemanager = {       

        getCommander: function(name, alignment, mana){
            return new Commander(name, alignment, mana);
        },
        getArmyUnit: function(options){
            let name = options.name,
                alignment = options.alignment,
                speed = options.speed,
                count = options.count,
                damage = options.damage,
                health = options.health;
            
            let unit = new ArmyUnit(name, alignment, damage, health, count, speed);
            battlemanagerData.armyUnitsObj[unit.id] = unit;
            battlemanagerData.armyUnits.push(unit);

            return unit;

        },
        getSpell: function(name, manaCost, effect){
            return new Spell(name, manaCost, effect);
        },
        addCommanders: function(...commanders){
            battlemanagerData.commanders.push(...commanders);
            return this;
        },
        addArmyUnitTo: function(commanderName, armyUnit){
            battlemanagerData.commanders.find(c => c.name === commanderName).army.push(armyUnit);
            return this;
        },
        addSpellsTo: function(commanderName, ...spells){           
            
            spells.forEach(function(spell){
                try{
                    let realSpell = new Spell(spell.name, spell.manaCost, spell.effect);                    
                } catch (error){
                    error.message = ERROR_MESSAGES.INVALID_SPELL_OBJECT; 
                    throw error;                   
                }                
            });

           battlemanagerData.commanders.find(c => c.name === commanderName).spellbook.push(...spells);

           return this;
        },
        findCommanders: function(query){
            return battlemanagerData.commanders
                .slice()
                .filterByProperty(query, 'name')
                .filterByProperty(query, 'alignment')
                .sort((x, y) => x.name.localeCompare(y.name));
        },
        findArmyUnitById: function(id){

        },
        findArmyUnits: function(query){

        },
        spellcast: function(casterName, spellName, targetUnitId){

        },
        battle: function(attacker, defender){

        }
    };

    return battlemanager;
}

const battlemanager = solve();

const cyki = battlemanager.getCommander('Cyki', 'good', 15),
    koce = battlemanager.getCommander('Koce', 'good', 20);

battlemanager.addCommanders(cyki, koce);

const penguins = battlemanager.getArmyUnit({
        name: 'Penguin Warriors',
        alignment: 'neutral',
        damage: 15,
        health: 40,
        speed: 10,
        count: 120
    }),
    cavalry = battlemanager.getArmyUnit({
        name: 'Horsemen',
        alignment: 'good',
        damage: 40,
        health: 60,
        speed: 50,
        count: 50
    });

module.exports = solve;