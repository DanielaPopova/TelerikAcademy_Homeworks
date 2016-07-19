/*
Problem 1
Write a function for creating persons.
Each person must have firstname, lastname, age and gender (true is female, false is male)
Generate an array with ten person with different names, ages and genders
*/

function createPerson(firstName, lastName, age, gender) {
    return {
        firstName: firstName,
        lastName: lastName,
        age: age,
        gender: gender === true ? 'male' : 'female',
        toString: function () {
          return 'name: ' + this.firstName + ' ' + this.lastName + '; age: ' + this.age + '; gender: ' + this.gender;
        }
    };
}

function createPeople() {
  var i, arr = [],
    minAge = 10,
    maxAge = 50;

  for (i = 0; i < 10; i += 1) {
    arr.push(createPerson('person', i, Math.floor(Math.random() * (maxAge - minAge + 1) + minAge), i % 2 === Math.round(Math.random() * 1)));
  }

  return arr;
}

function createRandomPeople() {
  var i, arr = [],
    minAge = 10,
    maxAge = 50,
    firstNames = ['Marian', 'Geroge', 'Daniel', 'Svetlin', 'Martin', 'Ivan', 'Peter', 'Mitko', 'Radoslav', 'Nikolai'],
    lastNames = ['Stoianov', 'Peshev', 'Grigorov', 'Kostov', 'Ivanov', 'Popov', 'Kirov', 'Tenchev', 'Iliev', 'Ianev'];

  for (i = 0; i < 10; i += 1) {
    arr.push(createPerson(firstNames[Math.random() * 10 | 0], lastNames[Math.random() * 10 | 0], Math.floor(Math.random() * (maxAge - minAge + 1) + minAge), true));
  }

  return arr;
}

function separator() {
  console.log(Array(51).join("=")); 
}

var arrPeople = createPeople();
arrPeople.forEach(function(item){console.log(item.toString());});

/*
Problem 2
Write a function that checks if an array of person contains only people of age (with age 18 or greater)
Use only array methods and no regular loops (for, while)
*/

separator();

var peopleOfAge = 
arrPeople.every(function (person) {
  return person.age >= 18;
});
console.log('Are there only people of age? ' + (peopleOfAge === true ? 'Yes' : 'No'));

/*
Problem 3
Write a function that prints all underaged persons of an array of person
Use Array#filter and Array#forEach
Use only array methods and no regular loops (for, while)
*/

separator();

var underaged = arrPeople.filter(function (person) {
      return person.age < 18;
    })
    .forEach(function (person) {
      console.log(person.toString());
    });


/*
Problem 4
Write a function that calculates the average age of all females, extracted from an array of persons
Use Array#filter
Use only array methods and no regular loops (for, while)
*/

separator();

var allFemales = arrPeople.filter(function (person) {
    if (person.gender === 'female') {
      return person.age;
    }
});

allFemales.forEach(function (person) {
  console.log(person.toString());
});

var sumAge = allFemales.reduce(function (sumAge, person) {
  return sumAge + person.age;
}, 0);

var averageAge = (sumAge / allFemales.length).toFixed(2);

console.log('Average age is: ' + averageAge);

/*
Problem 5
Write a function that finds the youngest male person in a given array of people and prints his full name
Use only array methods and no regular loops (for, while)
Use Array#find
*/

separator();

var youngestMale = arrPeople.sort(function (a, b) {
  return a.age - b.age;
}).find(function (person) {
  return person.gender === 'male';
});

console.log('Youngest is: ' + youngestMale.firstName + youngestMale.lastName);

/*
Problem 6
Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object
Use Array#reduce
Use only array methods and no regular loops (for, while)
Example:

    result = {
        'a': [{
            firstname: 'Asen',
            ...
        }, {
            firstname: 'Anakonda',
            ...
        }],
        'j': [{
            firstname: 'John',
            ...
        }]
    };
*/

separator();

var people = createRandomPeople();
var groupPeople = people.reduce(function (groups, person) {
  var firstLetter = person.firstName[0];

  if (!groups[firstLetter]) {
    groups[firstLetter] = [];
  }

  groups[firstLetter].push(person);

  return groups;
}, {});

console.log(groupPeople);