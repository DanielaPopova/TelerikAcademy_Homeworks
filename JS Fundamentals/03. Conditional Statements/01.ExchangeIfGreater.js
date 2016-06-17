function exchangeNumbers(args) {
	var tempNum,
		firstNum = +args[0],
		secondNum = +args[1];
		
	if (firstNum > secondNum) {
		tempNum = firstNum;
		firstNum = secondNum;
		secondNum = tempNum;
	}
	return firstNum + ' ' + secondNum;
}

console.log(exchangeNumbers(['5', '2']));
console.log(exchangeNumbers(['3', '4']));
console.log(exchangeNumbers(['5.5', '4.5']));

// Write an if statement that takes two double variables a and b and exchanges their values
// if the first one is greater than the second. As a result print the values a and b, separated by a space.

// Input

// The input will consist of an array containing two values - a and b represented as strings
// Output

// The output should be a single line containing two numbers
// Constraints

// Time limit: 0.2s
// Memory limit: 16MB
// Sample tests

// Input	Output
// 5
// 2		2 5
// 3
// 4		3 4
// 5.5
// 4.5		4.5 5.5