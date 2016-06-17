function sortNumbers(args) {
	var firstNum = +args[0],
	 	secondNum = +args[1],
	 	thirdNum = +args[2];
	 	
 	if (firstNum >= secondNum && firstNum >= thirdNum) {
 		if (secondNum >= thirdNum) {
 			return firstNum + ' ' + secondNum + ' ' + thirdNum; 
 		} else {
 			return firstNum + ' ' + thirdNum + ' ' + secondNum;
 		}
 	} else if (secondNum >= firstNum && secondNum >= thirdNum) {
 		if (firstNum >= thirdNum) {
 			return secondNum + ' ' + firstNum + ' ' + thirdNum;
 		} else {
 			return secondNum + ' ' + thirdNum + ' ' + firstNum;

 		}
 	} else if (thirdNum >= firstNum && thirdNum >= secondNum) {
 		if (firstNum >= secondNum) {
 			return thirdNum + ' ' + firstNum + ' ' + secondNum;
 		} else {
 			return thirdNum + ' ' + secondNum + ' ' + firstNum;
 		}
 	}
}

console.log(sortNumbers(['5', '1', '2']));
console.log(sortNumbers(['-2', '-2', '1']));
console.log(sortNumbers(['-2', '4', '3']));
console.log(sortNumbers(['0', '-2.5', '5']));
console.log(sortNumbers(['-1.1', '-0.5', '-0.1']));
console.log(sortNumbers(['10', '20', '30']));
console.log(sortNumbers(['1', '1', '1']));

// Sort 3 real values in descending order. Use nested if statements.

// Note: Don’t use arrays and the built-in sorting functionality.

// Input

// The input will consist of an array containing three values represented as strings
// Output

// The output should be a single line containing three numbers separated by spaces
// Constraints

// Time limit: 0.2s
// Memory limit: 16MB
// Sample tests

// Input	Output
// 5
// 1
// 2		5 2 1
// -2
// -2
// 1		1 -2 -2
// -2
// 4
// 3		4 3 -2
// 0
// -2.5
// 5		5 0 -2.5
// -1.1
// -0.5
// -0.1		-0.1 -0.5 -1.1
// 10
// 20
// 30		30 20 10
// 1
// 1
// 1		1 1 1