var people = [
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname: 'John', lastname: 'Doe', age: 42 },
    { firstname: 'Pesho', lastname: 'Pesho', age: 22 },
    { firstname: 'Asdf', lastname: 'Xyz', age: 81 },
    { firstname: 'Gosho', lastname: 'Gosho', age: 22 }
];

var associativeArray = {};

for (const person of people) {
    if (!associativeArray[person.age]) {
        associativeArray[person.age] = [person];
    }
    else{
        associativeArray[person.age].push(person);
    }
}

console.log(associativeArray);
/*
Write a function that groups an array of people by age. The function must return an associative array,
with keys - the groups, and values - arrays with people in this groups Use function overloading (i.e. just one function)

Example:

var people = [
  { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
  { firstname: 'Bay', lastname: 'Ivan', age: 81 },
  { firstname: 'John', lastname: 'Doe', age: 42 },
  { firstname: 'Pesho', lastname: 'Pesho', age: 22 },
  { firstname: 'Asdf', lastname: 'Xyz', age: 81 },
  { firstname: 'Gosho', lastname: 'Gosho', age: 22 }
];

var groupedByAge = group(people);
groupedByAge must be:
{
  '22': [
    { firstname: 'Pesho', lastname: 'Pesho', age: 22 },
    { firstname: 'Gosho', lastname: 'Gosho', age: 22 }
  ],
  '32': [
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 }
  ],
  '42': [
    { firstname: 'John', lastname: 'Doe', age: 42 }
  ],
  '81': [
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname: 'Asdf', lastname: 'Xyz', age: 81 }
  ]
}
*/