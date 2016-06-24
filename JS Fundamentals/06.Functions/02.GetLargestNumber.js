function findLargest(args) {
  var numbers = args[0].split(' ');
  var firstNum = +numbers[0],
      secondNum = +numbers[1],
      thirdNum = +numbers[2];

  if (thirdNum > getMax(firstNum, secondNum)) {
    return thirdNum;
  } else {
    return getMax(firstNum, secondNum);
  }

  function getMax(first, second) {
    if (first > second) {
      return first;
    } else {
      return second;
    }
  }
}

console.log(findLargest(['8 3 6']));
console.log(findLargest(['7 19 19']));

/*
Write a method GetMax() with two parameters that returns the larger of two integers.
Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().

Input

On the first line you will receive 3 integers separated by spaces
Output

Print the largest of them
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input     Output
8 3 6     8
7 19 19   19
*/