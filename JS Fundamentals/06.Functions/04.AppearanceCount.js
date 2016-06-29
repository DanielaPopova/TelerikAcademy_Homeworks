function printResult(args) {
  var searchedNumber = +args[2],      
      numbers = args[1].split(' ').map(Number);  

  return countTimes(numbers, searchedNumber);

  function countTimes(numArray, numberToSearch) {
    var i, len, count = 0;

    for (i = 0, len = numArray.length; i < len; i += 1) {
      if (numArray[i] === numberToSearch) {
        count += 1;
      }
    }
    return count;
  }
}

console.log(printResult(['8', '28 6 21 6 -7856 73 73 -56', '73']));

/*
Write a method that counts how many times given number appears in a given array.
Write a test program to check if the method is working correctly.

Input

On the first line you will receive a number N - the size of the array
On the second line you will receive N numbers separated by spaces - the numbers in the array
On the third line you will receive a number X
Output

Print how many times the number X appears in the array
Constraints

1 <= N <= 1024
Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input                       Output
8
28 6 21 6 -7856 73 73 -56   2
73  
*/