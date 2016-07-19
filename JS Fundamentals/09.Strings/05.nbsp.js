function solve(args) {
  var text = args[0],
    result;

  result = text.replace(/\s/g, '&nbsp;');
  console.log(result);
}

solve(['hello world']);
solve(['This text contains 4 spaces!!']);


function withoutRegex(args) {
  var i, len,
    result = '';
  text = args[0];

  for (i = 0, len = text.length; i < len; i += 1) {
    result += text[i] === ' ' ? '&nbsp;' : text[i];
  }

  console.log(result);
}

withoutRegex(['hello world']);
withoutRegex(['This text contains 4 spaces!!']);
/*
Write a function that replaces non breaking white-spaces in a text with &nbsp.

Input

The input will consist of an array containing one string
Output

The output should be consisted of one line
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample Test 1

Input
[ 'hello world' ]
Output
hello&nbsp;world

Sample Test 2

Input
[ 'This text contains 4 spaces!!' ]
Output
This&nbsp;text&nbsp;contains&nbsp;4&nbsp;spaces!!
*/