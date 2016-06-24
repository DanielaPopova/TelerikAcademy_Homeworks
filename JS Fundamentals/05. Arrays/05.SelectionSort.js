function selectionSort(args) {
    var i, j, len,
        position = 0,
        numbers = args[0].split('\n').map(Number);
        smallest = Number.MAX_VALUE;
        //numbers.shift();
        
    for (i = 0, len = numbers.length; i < len; i += 1) {
      for (j = i + 1; j < len; j += 1) {
          if (numbers[j] < smallest) {
             smallest = numbers[j];
             position = j;
          }
      }      
      numbers.splice(position, 1);
      numbers.unshift(smallest);      
      smallest = Number.MAX_VALUE;
    }
    numbers.shift();
    numbers.reverse();   
    console.log(numbers.join('\n'));
}

selectionSort(['6\n3\n4\n1\n5\n2\n6']);
selectionSort(['10\n36\n10\n1\n34\n28\n38\n31\n27\n30\n20']);

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

Input   Output
6       
3       1 
4       2 
1       3 
5       4 
2       5 
6       6
10
36      1
10      10
1       20
34      27
28      28
38      30
31      31
27      34
30      36
20      38
*/