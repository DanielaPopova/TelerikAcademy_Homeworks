function solveRegex(args) {
    let output = '',
        match = /<.*?>/ig;

    for (var line of args) {
        output += line.replace(match, '').trim();
    }

    console.log(output);
}

solveRegex(['<html>',
            '  <head>',
            '    <title>Sample site</title>',
            '  </head>', '  <body>', '    <div>text',
            '      <div>more text</div>',
            ' and more...',
            '    </div>',
            '    in body',
            '  </body>',
            '</html>']);

function solve(args) {
    let input = args,
        result = '',
        startTag = false;

    for (let i = 0, len = input.length; i < len; i += 1) {
        let currString = input[i].trim();

        for (let j = 0; j < currString.length; j += 1) {
            let currSymbol = currString[j];

            if (currSymbol === '<') {
                startTag = true;
                continue;
            } else if (currSymbol === '>') {
                startTag = false;
                continue;
            }

            if (!startTag) {
                result += currSymbol;
            }
        }
    }

    console.log(result);
}

solve(['<html>', '  <head>', '    <title>Sample site</title>', '  </head>', '  <body>', '    <div>text', '      <div>more text</div>', ' and more...', '    </div>', '    in body', '  </body>', '</html>']);

/*
Write a function that extracts the content of a html page given as text.
The function should return anything that is in a tag, without the tags.

Input

The input will consist of an array of strings
Output

The output should be consisted of one line - text inside tags
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input
[
    '<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
]

Output
Sample sitetextmore textand more...in body
*/