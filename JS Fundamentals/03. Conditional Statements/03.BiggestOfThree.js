function findBiggest(args) {
	var firstNum = +args[0],
		secondNum = +args[1],
		thirdNum = +args[2],
		biggestNum = firstNum;

	if (firstNum >= secondNum) {
		if (firstNum >= thirdNum) {
			biggestNum = firstNum;
		} else {
			biggestNum = thirdNum;
		}			
	} else if (firstNum <= secondNum) {
		if (secondNum >= thirdNum) {
			biggestNum = secondNum;
		} else {
			biggestNum = thirdNum;
		}
	} 

	return biggestNum;
}

console.log(findBiggest(['5', '2', '2']));
console.log(findBiggest(['-2', '-2', '1']));
console.log(findBiggest(['-2', '4', '3']));
console.log(findBiggest(['0', '-2.5', '5']));
console.log(findBiggest(['-0.1', '-0.5', '-1.1']));

// Write a script that finds the biggest of three numbers. Use nested if statements.

// Input

// The input will consist of an array containing three values represented as strings
// Output

// The output should be a single line containing a number
// Constraints

// Time limit: 0.2s
// Memory limit: 16MB
// Sample tests

// Input	Output
// 5
// 2
// 2		5
// -2
// -2
// 1		1
// -2
// 4
// 3		4
// 0
// -2.5
// 5		5
// -0.1
// -0.5
// -1.1		-0.1