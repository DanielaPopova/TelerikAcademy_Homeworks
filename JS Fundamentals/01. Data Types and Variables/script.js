// Problem 01 JS literals
var floatLiteral = 2.5;
var integerLiteral = 10;
var hexaNumLiteral = 0xF1;
var stringLiteral = 'hello';
var boolLiteral = true;
var arrayLiteral = [1, 2, 3];
var objectLiteral = {planet: "Saturn"};

// Problem 02 Quoted text
var quotedText = '"How you doin\'", Joey said';
console.log(quotedText);

// Problem 03 Typeof variables
console.log(typeof(floatLiteral));
console.log(typeof(integerLiteral));
console.log(typeof(hexaNumLiteral));
console.log(typeof(stringLiteral));
console.log(typeof(boolLiteral));
console.log(typeof(arrayLiteral));
console.log(typeof(objectLiteral));

// Problem 04 Typeof null
var undefinedLiteral;
var nullLiteral = null;
console.log(undefinedLiteral);
console.log(nullLiteral);

// Problem 05 Parsing numbers
var firstString = '1234',
    secondString = '1238abc';
    thirdString = '0.15',
    fourthString = '3.14ivan',
    fifthString = 'Infinity',
    sixthString = '99999999999999999999';

console.log(parseInt(firstString));
console.log(parseInt(secondString));
console.log(parseInt(thirdString));
console.log(parseInt(fourthString));
console.log(parseInt(fifthString));
console.log(parseInt(sixthString));

console.log(parseFloat(firstString));
console.log(parseFloat(secondString));
console.log(parseFloat(thirdString));
console.log(parseFloat(fourthString));
console.log(parseFloat(fifthString));
console.log(parseFloat(sixthString));

console.log(Number(firstString));
console.log(Number(secondString));
console.log(Number(thirdString));
console.log(Number(fourthString));
console.log(Number(fifthString));
console.log(Number(sixthString));

console.log(+firstString);
console.log(+secondString);
console.log(+thirdString);
console.log(+fourthString);
console.log(+fifthString);
console.log(+sixthString);

console.log(firstString | 0);
console.log(secondString | 0);
console.log(thirdString | 0);
console.log(fourthString | 0);
console.log(fifthString | 0);
console.log(sixthString | 0);