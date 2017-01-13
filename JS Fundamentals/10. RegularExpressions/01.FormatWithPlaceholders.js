function solve(args) {
  let value,
    options = JSON.parse(args[0]),
    template = args[1];
    //regex = /#{(.*?)}/i;

  for (const prop in options) {
    if (options.hasOwnProperty(prop)) {
      value = options[prop];      
      let match = new RegExp('#{' + prop + '}', 'gi');  // if there are more placeholders with the same property 
      
      template = template.replace(match, value);
    }
  }

  console.log(template);
}

solve(['{ "name": "John" }',
"Hello, there! Are you #{name}?"]);

solve(['{ "name": "John", "age": 13 }',
"My name is #{name} and I am #{age}-years-old"]);

/*
Write a function that formats a string. The function should have placeholders, as shown in the example
Add the function to the String.prototype
Input

The input array will look like that:
[
    '{ "name": "John", age: 13 }', // options as JSON
    'My name is #{name} and I am #{age}-years-old' // template
]
Hint: you can use JSON.parse method to convert the options to an object.
Output

Output the formatted string.
Constraints

The options will always be passed as a JSON-stringified object
The input will be relatively small
The options will be 6-7 at most
The longest template string will be shorter than 2000 symbols
Time limit: 0.2s
Memory limit: 32MB
Sample tests

Input                                                 Output
[
'{ "name": "John" }',
"Hello, there! Are you #{name}?"
] '                                                   Hello, there! Are you John'
[
'{ "name": "John", "age": 13 }',
"My name is #{name} and I am #{age}-years-old"
]'                                                    My name is John and I am 13-years-old'
*/