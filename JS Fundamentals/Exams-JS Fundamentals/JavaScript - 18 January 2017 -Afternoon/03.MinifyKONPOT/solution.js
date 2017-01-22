/*jshint esversion: 6 */
function solve(params) {
    let allInOne = params.join().replace(/\s+/g, ''),
        count = 0;               
    const patternFirstSymbol = /[a-zA-Z0-9_]+/g;

    //TODO:
    
    
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