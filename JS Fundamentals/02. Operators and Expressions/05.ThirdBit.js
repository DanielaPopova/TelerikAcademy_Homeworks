function printThirdBit(number) {
	var position = 3;
	var thirdBit = (number & (1 << position)) >> position;

	return thirdBit;
}

var num = 15;
console.log('Binary representation of ' + num);
var n = num.toString(2);
n = ('0000000000000000' + n).slice(-16);
console.log(n);

console.log(printThirdBit(15));

// Using bitwise operators, write a javascript function(that accepts a single array with arguments as a parameter)
// that uses an expression to find the value of the bit at index 3 of an unsigned integer read from the console.

// The bits are counted from right to left, starting from bit 0.
// The result of the expression should be either 1 or 0. Print it on the console.
// Input

// The only element of the parameter array, will be a positive integer as a string - the number whose 3rd bit you must print.
// Output

// Output a single number - 1 or 0 - the value of the 3rd bit, counted from 0 and from right to left.
// You can use console.log to print the results or you can use return to return the answer. Both are correct.
// Constraints

// The input number will always be a valid positive integer number.
// Time limit: 0.2s
// Memory limit: 16MB
// Sample tests

// Input	Output
// 15		1
// 1024		0