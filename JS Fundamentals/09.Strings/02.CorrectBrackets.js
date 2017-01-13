function solve(args) {
    let expression = args[0],
        countOpen = 0,
        countClose = 0;

    for (let i = 0, len = expression.length; i < len; i += 1) {
        if (expression[i] === '(') {
            countOpen += 1;
        } else if(expression[i] === ')'){
            countClose += 1;
        }
    }

    if (countOpen === countClose) {
        console.log('Correct');
    } else {
        console.log('Incorrect');
    }
}

// solves some special cases
// function solve(args) {
//     let expression = args[0],
//         firstOpenIndex, firstCloseIndex,
//         openBracketCount = 0,
//         closeBracketCount = 0,
//         isClosed = false;

//     for (let i = 0, len = expression.length; i < len; i += 1) {
//         let symbol = expression[i];

//         if (symbol === '(') {
//             openBracketCount += 1;
//             isClosed = false;
//             if (openBracketCount === 1) {
//                 firstOpenIndex = i;
//             }
//         } else if (symbol === ')') {
//             closeBracketCount += 1;
//             isClosed = true;
//             if (closeBracketCount === 1) {
//                 firstCloseIndex = i;
//             }
//         }
//     }

//     if (openBracketCount === closeBracketCount && isClosed && firstOpenIndex < firstCloseIndex) {
//         console.log('Correct');
//     } else {
//         console.log('Incorrect');
//     }
// }

solve(['((a+b)/5-d)']);  //correct
solve([')(a+b))']);  //incorrect
solve([')(a+b)(']);  //correct - obviously not
solve([')((a+b)']);  //correct - obviously not
solve(['))a + b((']);  //correct - obviously not
solve(['(a+b)+d+)(b( * c)']);  //correct - obviously not
solve([')(a+b))']);  //incorrect
solve(['(a+b+(b*c)+(d/s) + (-5)) + ()()']); //correct
solve(['((a + (b * c))*(())']); // incorrect

/*
Write a JavaScript function to check if in a given expression the brackets are put correctly.

Input

The input will consist of an array containing a string
Output

The output should be consisted of one line
Correct or Incorrect
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample Test 1

Input
[ '((a+b)/5-d)' ]

Output
Correct

Sample Test 2

Input
[ ')(a+b))' ]

Output
Incorrect
*/