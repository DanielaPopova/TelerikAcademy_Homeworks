function compareArrays(args) {
    var firstWord = args[0],
        secondWord = args[1];

    if (Array.isArray(firstWord)) {
        firstWord = firstWord.join('');
    }

    if (Array.isArray(secondWord)) {
        secondWord = secondWord.join('');
    }

    if (firstWord > secondWord) {
        return '>';
    } else if (firstWord < secondWord) {
        return '<';
    } else {
        return '=';
    }    
}

function compareArrays(args) {
   

    return '=';
}

console.log(compareArrays([['h', 'e', 'l', 'l', 'o']]));
console.log(compareArrays(['food', 'food']));
console.log(compareArrays(['', 'b']));

/*
Write a program that compares two char arrays lexicographically (letter by letter).

Input

On the first line you will receive the first char array as a string
On the second line you will receive the second char array as a string
Output

Print < if the first array is lexicographically smaller
Print > if the second array is lexicographically smaller
Print = if the arrays are equal
Constraints

1 <= size of arrays <= 128
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input               Output
['hello', 'halo']   >
['food', 'food']    =
 
*/