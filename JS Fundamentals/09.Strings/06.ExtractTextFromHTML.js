function solveRegex(args) {
    var output = '';
    var match = /<.*?>/ig;

    for (var line of args) {
        output += line.replace(match, '').trim();
    }

    console.log(output);
}

solveRegex(['<html>', '  <head>', '    <title>Sample site</title>', '  </head>', '  <body>', '    <div>text', '      <div>more text</div>', ' and more...', '    </div>', '    in body', '  </body>', '</html>']);

function solve(args) {
  var i, j, len, currString, currSymbol,
      input = args,
      result = '',
      startTag = false;      
  
  for (i = 0, len = input.length; i < len; i += 1) {
      currString = input[i].trim();

    for (j = 0; j < currString.length; j += 1) {
      currSymbol = currString[j];

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