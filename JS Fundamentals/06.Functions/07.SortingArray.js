function sortArray(args) {
  var sortedArray = [],
      numbers = args[0].replace('\n', ' ').split(' ').map(Number);
      numbers.shift();

  sortedArray = numbers.sort(function(a, b) {
    return a - b;
  });

  return sortedArray.join(' ');
}

console.log(sortArray(['6\n3 4 1 5 2 6']));
console.log(sortArray(['10\n36 10 1 34 28 38 31 27 30 20']));

/*
Write a method that returns the maximal element in a portion of array of integers starting at given index.
Using it write another method that sorts an array in ascending / descending order. Write a program that sorts a given array.

Input

On the first line you will receive the number N - the size of the array
On the second line you will receive N numbers separated by spaces - the array
Output

Print the sorted array
Elements must be separated by spaces
Constraints

1 <= N <= 1024
Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input                           Output
6
3 4 1 5 2 6                     1 2 3 4 5 6
10
36 10 1 34 28 38 31 27 30 20    1 10 20 27 28 30 31 34 36 38
*/