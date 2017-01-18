/*jshint esversion: 6 */
function solve(params) {
    let allInOne = params.join().replace(/\s+/g, ''),
        count = 0,
        countStars = 0;        
    const patternFirstSymbol = /[a-zA-Z0-9_]+/g;

    let newAllInOne = allInOne.replace(patternFirstSymbol, '*');

    for (let i = 0, len = newAllInOne.length; i < len; i += 1) {
        let currSymbol = newAllInOne[i];

        if (currSymbol === '*') {
            countStars += 1;
        }        
    }
    
    count = countStars * 2;
    
    console.log(count);
}

solve([
    'hello;',
    '{this; is',
    ' ; an;;;example;',
    '}',
    'of;',
    '{',
    'KONPOT;',
    '{',
    'Some_numbers;',
    '42;5;3}',
    '_}'
    ]);