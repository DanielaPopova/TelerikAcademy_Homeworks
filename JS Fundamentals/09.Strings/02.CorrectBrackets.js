function solve(args) {
    let expression = args[0],
        firstOpenIndex, firstCloseIndex,
        openBracketCount = 0,
        closeBracketCount = 0,
        isClosed = false;

    for (let i = 0, len = expression.length; i < len; i += 1) {
        let symbol = expression[i];

        if (symbol === '(') {
            openBracketCount += 1;
            isClosed = false;
            if (openBracketCount === 1) {
                firstOpenIndex = i;
            }
        } else if (symbol === ')') {
            closeBracketCount += 1;
            isClosed = true;
            if (closeBracketCount === 1) {
                firstCloseIndex = i;
            }
        }
    }

    if (openBracketCount === closeBracketCount && isClosed && firstOpenIndex < firstCloseIndex) {
        console.log('Correct');
    } else {
        console.log('Incorrect');
    }
}

solve(['((a+b)/5-d)']);
solve([')(a+b))']);
solve([')(a+b)(']);
solve([')((a+b)']);
solve(['))a + b((']);
solve(['(a+b)+d+)(b( * c)']);
solve([')(a+b))']);
solve(['(a+b+(b*c)+(d/s) + (-5)) + ()()']);


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