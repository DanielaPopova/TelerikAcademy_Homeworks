function deepClone(obj) {
  var clone = {};

  if (obj === null || typeof(obj) !== 'object') {
    return obj;
  }

  if (Array.isArray(obj)) {
    return obj.slice();
  }

  for (var prop in obj) {
    if (obj.hasOwnProperty(prop)) {
      clone[prop] = obj[prop];
    }
  }

  return clone;
}

// var newObject = JSON.parse(JSON.stringify(oldObject)); .-> works if there are no functions in the object
/*
// Shallow copy
  var newObject = jQuery.extend({}, oldObject);

// Deep copy
  var newObject = jQuery.extend(true, {}, oldObject);
*/

// Testing 
var person = {
  name: 'Ivan',
  age: 25,
  toString: function() {
    console.log(this.name + ' ' + this.age);
  }
};

var clonePerson = deepClone(person);

person.toString();
clonePerson.toString();

clonePerson.name = 'Stoian';

person.toString();
clonePerson.toString();

var a = 2;
var b = a;
console.log('b = ' + b);
b = deepClone(a);
b = 3;
console.log('b = ' + b);
console.log('a = ' + a);

var str = 'hello';
var cloneStr = deepClone(str);
cloneStr = 'bye';
console.log(str);
console.log(cloneStr);

var array = [5, 10, 15];
var cloneArray = deepClone(array);
cloneArray[0] = 4;
console.log(array);
console.log(cloneArray);
/*
Write a function that makes a deep copy of an object. The function should work for both primitive and reference types.
*/