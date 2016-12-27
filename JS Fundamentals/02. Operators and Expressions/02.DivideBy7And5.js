function isDivisibleBy35(args) {
    var number = +args[0];

    if (number % 35) {
        return false + ' ' + number;
    } else {
        return true + ' ' + number;
    }
}
console.log(isDivisibleBy35(['3']));
console.log(isDivisibleBy35(['0']));
console.log(isDivisibleBy35(['5']));
console.log(isDivisibleBy35(['7']));
console.log(isDivisibleBy35(['35']));
console.log(isDivisibleBy35(['140']));

// Implement a javascript function that does the following:

// Accepts an array containing a single integer number as string.
// Stores in a variable if the number can be divided by 7 and 5 without remainder.
// Prints on the console "true NUMBER" if the number is divisible without remainder by 7 and 5.
// Otherwise prints "false NUMBER". In place of NUMBER print the value of the input number.
// Input

// The input will consist of an array containing a single integer value as a string.
// Output

// The output must always follow the format specified in the description. See the sample tests.
// You can use console.log to print the results or you can use return to return the answer. Both are correct.
// Constraints

// The input will always consist of valid integers and follow the format in the description.
// Time limit: 0.2s
// Memory limit: 16MB
// Sample tests

// Input	Output
// 3		false 3
// 0		true 0
// 5		false 5
// 7		false 7
// 35		true 35
// 140		true 140