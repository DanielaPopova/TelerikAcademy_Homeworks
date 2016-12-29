/*jshint esversion: 6 */
function selectionSort(args) {
  let len = +args.shift(),
      numbers = args.map(Number),
      smallestNumber = Number.MAX_VALUE,
      position = 0;      

      for (let i = 0; i < len; i += 1) {
          for (let j = i; j < len; j += 1) {
              if (numbers[j] < smallestNumber) {
                smallestNumber = numbers[j];
                position = j;                
              }
          }
          numbers.splice(position, 1);
          numbers.unshift(smallestNumber);          
          smallestNumber = Number.MAX_VALUE;
      }
      numbers.reverse();
      console.log(numbers.join('\n'));
}

selectionSort(['6', '3', '4', '1', '5', '2', '6']);
selectionSort(['10', '36', '10', '1', '34', '28', '38', '31', '27', '30', '20']);

/*
Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
Use the Selection sort algorithm: Find the smallest element, move it at the first position,
find the smallest from the rest, move it at the second position, etc.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the sorted array
Each number should be on a new line
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input   
['6', '3', '4', '1', '5', '2', '6']

Output
1
2
3
4
5
6

Input
['10', '36', '10', '1', '34', '28', '38', '31', '27', '30', '20']

Output
1
10
20
27
28
30
31
34
36
38
*/