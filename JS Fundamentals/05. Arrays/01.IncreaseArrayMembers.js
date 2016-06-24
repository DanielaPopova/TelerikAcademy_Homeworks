function increaseArrayMembers(length) {
  var i,
      array = [];
      
  for (i = 0; i < length; i += 1) {
    array[i] = i * 5;
	  console.log(array[i]);
  }
}

increaseArrayMembers(5);

/*
Write a program that allocates array of N integers, initializes each element by its index multiplied by 5 and the prints the obtained array on the console.

Input

On the only line you will receive the number N
Output

Print the obtained array on the console.
Each number should be on a new line
Constraints

1 <= N <= 20
N will always be a valid integer number
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
5		0
		5
		10
		15
		20

*/