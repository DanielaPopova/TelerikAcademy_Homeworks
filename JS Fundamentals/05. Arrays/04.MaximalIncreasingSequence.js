function maxIncreaseSequence(args) {
  var i, len, 
      count = 1,
      maxCount = 0,
      numbers = args[0].split('\n').map(Number);

  for ( i = 1, len = numbers.length; i < len; i += 1) {
    if (numbers[i] < numbers[i + 1]) {
        count += 1;
        if (count > maxCount) {
          maxCount = count;
        }
    }
    else {
      count = 1;
    }
  }
  return maxCount;
}

console.log(maxIncreaseSequence(['8\n7\n3\n2\n3\n4\n2\n2\n4']));

/*
Write a program that finds the length of the maximal increasing sequence in an array of N integers.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the length of the maximal increasing sequence
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input Output
8     3
7
3
2
3
4
2
2
4 
*/