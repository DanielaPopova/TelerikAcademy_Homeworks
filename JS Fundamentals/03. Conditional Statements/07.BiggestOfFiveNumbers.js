function printBiggestOfFive(args) {
	var firstNum = +args[0],
		secondNum = +args[1],
		thirdNum = +args[2],
		fourthNum = +args[3],
		fifthNum = +args[4],
		biggestNum = firstNum;

	if (secondNum >= firstNum) {
		biggestNum = secondNum;
	}
	if (thirdNum >= firstNum && thirdNum >= secondNum) {
		biggestNum = thirdNum;
	}
	if (fourthNum >= firstNum && fourthNum >= secondNum && fourthNum >= thirdNum ) {
		biggestNum = fourthNum;
	}
	if (fifthNum >= firstNum && fifthNum >= secondNum && fifthNum >= thirdNum && fifthNum >= fourthNum) {
		biggestNum = fifthNum;
	}

	return biggestNum;
}

console.log(printBiggestOfFive(['5', '2', '2', '4', '1']));
console.log(printBiggestOfFive(['-2', '-22', '1', '0', '0']));
console.log(printBiggestOfFive(['-2', '4', '3', '2', '0']));
console.log(printBiggestOfFive(['0', '-2.5', '0', '5', '5']));
console.log(printBiggestOfFive(['-3', '-0.5', '-1.1', '-2', '-0.1']));

// Write a script that finds the biggest of given 5 variables. Use nested if statements.

// Input

// The input will consist of an array containing five values represented as strings
// Output

// The output should be a single line containing the answer
// Constraints

// Time limit: 0.2s
// Memory limit: 16MB
// Sample tests

// Input	Output
// 5
// 2
// 2
// 4
// 1		5
// -2
// -22
// 1
// 0
// 0		1
// -2
// 4
// 3
// 2
// 0		4
// 0
// -2.5
// 0
// 5
// 5		5
// -3
// -0.5
// -1.1
// -2
// -0.1		-0.1