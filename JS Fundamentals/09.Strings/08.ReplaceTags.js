// 0/100 - time limit
function solveWithoutRegex(args) {
  var i, len, startIndex, endIndex,
      indexArr = [],
      editArray = [],
      toReplace = '',
      betweenTags = '',
      replaced = '',      
      input = args[0];      

  for (i = 0, len = input.length; i < len; i += 1) {
    if (input[i] === '<' && input[i + 1] === 'a') {
      startIndex = i;      
      indexArr.push(startIndex);
    }

    if (input[i] === 'a' && input[i + 1] === '>') {
      endIndex = i + 1;      
      indexArr.push(endIndex);
    }
  }

  for (i = 0, len = indexArr.length; i < len; i += 2) {
    toReplace = input.substring(indexArr[i], indexArr[i + 1] + 1);    
    betweenTags = '[' + toReplace.substring(toReplace.indexOf('>') + 1, toReplace.lastIndexOf('<')).trim() + ']';    
    replaced = toReplace.slice(0, toReplace.indexOf('>')).replace('<a href=', betweenTags).replace('"', '(').replace('"', ')');
    
    editArray.push(toReplace);
    editArray.push(replaced);
  }

  for (i = 0, len = editArray.length; i < len; i += 2) {
      input = input.replace(editArray[i], editArray[i + 1]);
  }

console.log(input);
}

solveWithoutRegex(['<p>Please visit <a href="http://academy.telerik.com"> our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);

// 40/100 - time limit
function solveRegex(args) {
  var match, betweenTags, link,
    text = args[0],
    matchesArr = [],
    allTogetherArr = [],
    regex = new RegExp('<a href="(.*?)">(.*?)</a>', "g");

  while ((matchesArr = regex.exec(text)) !== null) {
    match = matchesArr[0];    
    link = matchesArr[1];    
    betweenTags = matchesArr[2];
    allTogetherArr.push(match);
    allTogetherArr.push(link);
    allTogetherArr.push(betweenTags);
  }

  for (var i = 0, len = allTogetherArr.length; i < len; i += 3) {
      text = text.replace(allTogetherArr[i], '[' + allTogetherArr[i + 2] + ']' + '(' + allTogetherArr[i + 1] + ')');
  }
  console.log(text);
}

solveRegex(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);

// 100/100
function solveFinal(args) {
    var regExTag = new RegExp('<a href="(.*?)">(.*?)</a>', "g");

    var newText = args[0].replace(regExTag, function (none, href, content) {

        return '[' + content + '](' + href + ')';
    });

    console.log(newText);
}
/*
Write a JavaScript function that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
Example:

input                                                       output
<p>Please visit <a href="http://academy.telerik.com">       
our site</a> to choose a training course.                    
Also visit <a href="www.devbg.org">our forum</a>            
to discuss the courses.</p>   
*/

//<p>Please visit [our site](http://academy.telerik.com) to choose a training course. Also visit [our forum](www.devbg.org) to discuss the courses.</p>