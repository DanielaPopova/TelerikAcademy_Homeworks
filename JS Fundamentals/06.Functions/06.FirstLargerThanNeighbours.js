function printIndex(args) {
  
    var numbers = args[1].split(' ').map(Number);
    
    return findIndex(numbers);

  function findIndex(numArray) {
    var i, len, index;
    for (i = 1, len = numArray.length; i < len - 1; i += 1) {
      if (numArray[i] > numArray[i - 1] && numArray[i] > numArray[i + 1]) {
        index = i;
        break;
      }
    }
    return index;
  }
}

console.log(printIndex(['6', '-26 -25 -28 31 2 27']));

/*
Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there is no such element.

Input

On the first line you will receive the number N - the size of the array
On the second line you will receive N numbers sepated by spaces - the array
Output

Print the index of the first element that is larger than its neighbours or -1 if none are
Constraints

1 <= N <= 1024
Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input                 Output
6
-26 -25 -28 31 2 27   1
*/