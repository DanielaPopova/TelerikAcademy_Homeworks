function solve(args) {
  var str = args[0];

  console.log(reverse(str));

  function reverse(someString) {
    return someString.split('').reverse().join('');
  }
}

solve(['sample']);
solve(['qwertytrewq']);


/*
Write a JavaScript function that reverses a string.

Input

The input will consist of an array containing one string
Output

The output should be consisted of one line - the reversed string
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample Test 1

Input

[ 'sample' ]
Output

elpmas
Sample Test 2

Input

[ 'qwertytrewq' ]
Output

qwertytrewq
*/