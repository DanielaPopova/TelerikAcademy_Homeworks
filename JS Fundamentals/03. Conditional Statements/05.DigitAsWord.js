function printDigitAsWord(number) {
	switch(+number) {
		case 0: return 'zero';
		case 1: return 'one';
		case 2: return 'two';
		case 3: return 'three';
		case 4: return 'four';
		case 5: return 'five';
		case 6: return 'six';
		case 7: return 'seven';
		case 8: return 'eight';
		case 9: return 'nine';
		default: return 'not a digit';
	}
} 

console.log(printDigitAsWord(2));
console.log(printDigitAsWord(1));
console.log(printDigitAsWord(0));
console.log(printDigitAsWord(5));
console.log(printDigitAsWord(-0.1));
console.log(printDigitAsWord('hi'));
console.log(printDigitAsWord(9));
console.log(printDigitAsWord(10));

// Write a script that asks for a digit (0-9), and depending on the input, shows the digit as a word
// (in English). Print not a digit in case of invalid input. Use a switch statement.

// Input

// The input will consist of an array containing a single string
// Output

// The output should be a single line
// Constraints

// Time limit: 0.2s
// Memory limit: 16MB
// Sample tests

// Input	Output
// 2		two
// 1		one
// 0		zero
// 5		five
// -0.1		not a digit
// hi		not a digit
// 9		nine
// 10		not a digit