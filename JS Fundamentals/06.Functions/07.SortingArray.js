function sortArray(args) {
  var len = +args[0],
      numbers = args[1].split(' ').map(Number);

  return sortByDescendingOrder(numbers).reverse().join(' ');

  function sortByDescendingOrder(array) {
    var i, len, maxEl, maxElIndex, temp;

    for (i = 0, len = array.length; i < len; i += 1) {
      maxEl = getMax(i, array);
      maxElIndex = array.indexOf(maxEl, i);
      temp = array[i];
      array[i] = maxEl;
      array[maxElIndex] = temp;
    }
    return array;
  }

  function getMax(index, numArray) {
    var i, len,
      maxElement = Number.NEGATIVE_INFINITY;

    for (i = index, len = numArray.length; i < len; i += 1) {
      if (numArray[i] > maxElement) {
        maxElement = numArray[i];
      }
    }
    return maxElement;
  }
  // easy way
  // sortedArray = numbers.sort(function(a, b) {
  //   return a - b;
  // });
}

console.log(sortArray(['6', '3 4 1 5 2 6']));
console.log(sortArray(['10', '36 10 1 34 28 38 31 27 30 20']));
console.log(sortArray(['4', '2 -2 2 0']));  //if maxElement = Number.MIN_VALUE - first number is not 0 but 5e-324
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