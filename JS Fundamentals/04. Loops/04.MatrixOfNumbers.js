function printMatrix(args) {
	var i, j,
		result = '';
	for (i = 0; i < +args[0]; i += 1) {
		for (j = i + 1; j <= +args[0] + i; j += 1) {
			result += j + ' ';
		}
		result += '\n';
	}

	return result;
}

console.log(printMatrix(['2']));
console.log(printMatrix(['3']));
console.log(printMatrix(['4']));

// Write a javascript function that prints a matrix like in the examples below by a given integer N.
// Use two nested loops.

// Challenge: achieve the same effect without nested loops.
// Input

// The input array will contain a single number as string, the integer N.
// Output

// See the examples.
// Constraints

// 1 <= N <= 20
// N will always be a valid integer number
// Time limit: 0.2s
// Memory limit: 32MB
// Sample tests

// Input	Output
// 2		1 2
// 			2 3
// 3		1 2 3
// 			2 3 4
// 			3 4 5
// 4		1 2 3 4
// 			2 3 4 5
// 			3 4 5 6
// 			4 5 6 7