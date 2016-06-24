function maxSequence(args) {
  var i, len,
      count = 1,
      maxCount = 0,
      numbers = args[0].split('\n').map(Number);
      console.log(numbers.length + ' mmm');
  for (i = 1, len = numbers.length; i < len; i += 1) {
    if (numbers[i] === numbers[i + 1]) {
      count += 1;
      if (count > maxCount) {
        maxCount = count;
      }
    } else {
      count = 1;
    }
  }

  return maxCount;
}
console.log(maxSequence(['10\n2\n1\n1\n2\n3\n3\n2\n2\n2\n1']));
// if i = 0 -> it will count the first num inclusive, which is the length, not a part of the sequence!
//console.log(maxSequence(['6\n6\n6\n1\n1\n1'])); -> counts 3 times 6, not 3 times 1



/*
Write a program that finds the length of the maximal sequence of equal elements in an array of N integers.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the length of the maximal sequence
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input   Output
10      3
2
1
1
2
3
3
2
2
2
1 
*/