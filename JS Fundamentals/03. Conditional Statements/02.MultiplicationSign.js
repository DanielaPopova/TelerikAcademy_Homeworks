/*jshint esversion: 6 */
function printSign(arrayNumbers) {
    let a = +arrayNumbers[0],
        b = +arrayNumbers[1],
        c = +arrayNumbers[2],
        sign = '+';

    if (!a || !b || !c) {
        sign = '0';
    } else if (a > 0) {
        if ((b > 0 && c > 0) || (b < 0 && c < 0)) {
            sign = '+';
        } else if (b < 0 || c < 0) {
            sign = '-';
        }
    } else if (b > 0) {
        if ((a > 0 && c > 0) || (a < 0 && c < 0)) {
            sign = '+';
        } else if (a < 0 || c < 0) {
            sign = '-';
        }
    } else if (c > 0) {
        if ((a > 0 && b > 0) || (a < 0 && b < 0)) {
            sign = '+';
        } else if (a < 0 || b < 0) {
            sign = '-';
        }
    } else {
        sign = '-';
    }

    return sign;
}

console.log(printSign(['5', '2', '2']));
console.log(printSign(['-2', '-2', '1']));
console.log(printSign(['-2', '4', '3']));
console.log(printSign(['0', '-2.5', '4']));
console.log(printSign(['-1', '-0.5', '-5.1']));

// Other solution
// function printSign(args) {
//     var firstNum = +args[0],
//         secondNum = +args[1];
//         thirdNum = +args[2];

//     if (!firstNum || !secondNum || !thirdNum) {
//         return 0;
//     } else if (firstNum > 0 && secondNum > 0 && thirdNum > 0) {
//         return '+';
//     } else if (firstNum > 0 && secondNum > 0) {
//         if (thirdNum < 0) {
//             return '-';
//         }
//     } else if (firstNum > 0 && secondNum < 0) {
//         if (thirdNum > 0) {
//             return '-';
//         } else {
//             return '+';
//         }
//     } else if (firstNum < 0 && secondNum > 0) {
//         if (thirdNum > 0) {
//             return '-';
//         } else {
//             return '+';
//         }
//     } else if (firstNum < 0 && secondNum < 0) {
//         if (thirdNum > 0) {
//             return '+';
//         } else {
//             return '-';
//         }
//     }
// }

// Write a script that shows the sign (+, - or 0) of the product of three real numbers,
// without calculating it. Use a sequence of if operators.

// Input

// The input will consist of an array containing three values - a, b and c represented as strings
// Output

// The output should be a single line containing +, - or 0
// Constraints

// Time limit: 0.2s
// Memory limit: 16MB
// Sample tests

// Input	Output
// 5
// 2
// 2		+
// -2
// -2
// 1		+
// -2
// 4
// 3		-
// 0
// -2.5
// 4		0
// -1
// -0.5
// -5.1	-