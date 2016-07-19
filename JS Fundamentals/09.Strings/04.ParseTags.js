function solve(args) {
  var i, len, up = false, low = false, org = false,  doNothing = false,
      result = '',
      input = args[0],
      inTag = false,
      currSymbol;

      input = input.replace(/\\/g, '');
      //console.log(input);

  for (i = 0, len = input.length; i < len; i += 1) {
      currSymbol = input[i];

      if (currSymbol == '<') {
        inTag = true;

        if (input[i + 1] == '/') {
            inTag = true;
            doNothing = true;
            continue;
        }

        if (input[i + 1] == 'u') {
            up = true;
            low = false;
            org = false;
        } else if (input[i + 1] == 'l') {
            low = true;
            up = false;
            org = false;
        } else if (input[i + 1] == 'o') {
          org = true;
          up = false;
          low = false;
        }
        continue;
      } else if (currSymbol == '>') {
        inTag = false;
        if (doNothing) {
          up = false;
          low = false;
          org = false;
        }
        doNothing = false;
        continue;
      } 

      if (inTag) {
        continue;
      } else{
        if (up) {
          result += currSymbol.toUpperCase();
        } else if (low) {
          result += currSymbol.toLowerCase();
        } else if (org) {
          result += currSymbol;
        } else {
          result += currSymbol;
        }
      }
  }

  return result;
}

console.log(solve(['We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.']));
console.log(solve(['<upcase><lowcase>MAMA<orgcase>hIhII</orgcase></lowcase></upcase>']));
/*
You are given a text. Write a function that changes the text in all regions:

<upcase>text</upcase> to uppercase.
<lowcase>text</lowcase> to lowercase
<orgcase>text</orgcase> does not change casing
Note: Regions can be nested.

Input

The input will consist of an array containing one string
Output

The output should be consisted of one line
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input

[ 'We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.' ]
Output

We are liViNg in a YELLOW SUBMARINE. We doN't have anything else.
*/