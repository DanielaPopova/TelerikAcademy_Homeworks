function printResult(args) {
  var numbers = args[1].split(' ').map(Number);  

  return checkNeighbours(numbers);

  function checkNeighbours(numArray) {
    var i, len,
        currNum, before, after,
        count = 0;

    for (i = 1, len = numArray.length; i < len - 1; i += 1) {
      before = numArray[i - 1];
      currNum = numArray[i];
      after = numArray[i + 1];

      if (currNum > before && currNum > after) {
        count += 1;
      }
    }
    return count;
  }
}

console.log(printResult(['6', '-26 -25 -28 31 2 27']));

/*
Write a method that checks if the element at given position in given array of integers is larger
than its two neighbours (when such exist). Write program that reads an array of numbers and prints
how many of them are larger than their neighbours.

Input

On the first line you will receive the number N - the size of the array
On the second line you will receive N numbers separated by spaces - the array
Output

Print how many numbers in the array are larger than their neighbours
Constraints

1 <= N <= 1024
Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input                 Output
6
-26 -25 -28 31 2 27   2
*/

//  var numbers = args[0].replace(/\n/g, ' ').split(' ').map(Number); numbers.pop() - last member
