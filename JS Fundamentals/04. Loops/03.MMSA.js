function findMinMaxSumAverage(args) {
	var i, len, min, max, sum, average;
		average = 0;
		sum = 0;
		min = +args[0];
		max = +args[0];

	for (i = 0, len = args.length; i < len; i += 1) {

		if (+args[i] >= max) {
			max = +args[i];
		}

		if (+args[i] <= min) {
			min = +args[i];
		}

		sum += +args[i];
	}

	average = sum / len;

	console.log('min=' + min.toFixed(2));
	console.log('max=' + max.toFixed(2));
	console.log('sum=' + sum.toFixed(2));
	console.log('avg=' + average.toFixed(2));		
}

findMinMaxSumAverage(['2', '5', '1']);
findMinMaxSumAverage(['2', '-1', '4']);

// Implement a javascript function that accepts an array of floating-point numbers as strings
// and returns the minimal, the maximal number, the sum and the average of all numbers
// (displayed with 2 digits after the decimal point).

// Input

// The array that will be passed as a parameter to your function will contain the numbers of the sequence.
// Output

// You output must always consist of exactly 4 lines - the minimal element on the first line, the maximal on the second, the sum on the third and the average on the fourth, in the following format:
// min=3.00
// max=6.00
// sum=9.00
// avg=4.50
// Constraints

// 1 <= N <= 1000
// All numbers will be valid floating-point numbers that will be in the range [-10000, 10000]
// Time limit: 0.2s
// Memory limit: 32MB
// Sample tests

// Input	Output
// 2		min=1.00
// 5 		max=5.00
// 1		sum=8.00
// 			avg=2.67 		
// 2		min=-1.00
// -1		max=4.00
// 4		sum=5.00
// 			avg=1.67