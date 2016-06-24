function printWord(args) {
  var lastDigit = +args[0][parseInt(args[0].length - 1)];  // number % 10
  //console.log(typeof(lastDigit));
  return getDigitAsWord(lastDigit);

  function getDigitAsWord(digit) {
    switch (digit) {
      case 0:
        return 'zero';
      case 1:
        return 'one';
      case 2:
        return 'two';
      case 3:
        return 'three';
      case 4:
        return 'four';
      case 5:
        return 'five';
      case 6:
        return 'six';
      case 7:
        return 'seven';
      case 8:
        return 'eight';
      case 9:
        return 'nine';
    }
  }
}

console.log(printWord(['42']));

/*
Write a method that returns the last digit of given integer as an English word.
Write a program that reads a number and prints the result of the method.

Input

On the first line you will receive a number
Output

Print the last digit of the number as an English word
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input Output
42    two
*/