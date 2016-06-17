function toDecimal(args) {
	var i, digitAsString = '', decNum = 0;	
	var hexNum = args[0];
	for (i = 0, len = hexNum.length; i < len; i += 1) {
		digitAsString = hexNum[i];
		
		switch(digitAsString){
			case 'A': digitAsString = '10'; break;
			case 'B': digitAsString = '11'; break;
			case 'C': digitAsString = '12'; break;
			case 'D': digitAsString = '13'; break;
			case 'E': digitAsString = '14'; break;
			case 'F': digitAsString = '15'; break;			
		}
		decNum = +digitAsString + decNum * 16;		
	}
	return decNum;
}

console.log(toDecimal(['FE']));
console.log(toDecimal(['1AE3']));
console.log(toDecimal(['4ED528CBB4']));

// js goodies
var decimalNum = parseInt('4ED528CBB4', 16);
console.log(decimalNum);
var decimalNumber = 254;
var hexNumber = decimalNumber.toString(16).toUpperCase();
console.log(hexNumber);
// Using loops implement a javascript function that converts a hex number number to its decimal representation.

// Input

// The input will consists of a single line containing a single hexadecimal number as string.
// Output

// The output should consist of a single line - the decimal representation of the number as string.
// Constraints

// All numbers will be valid 64-bit integers.
// Time limit: 0.1s
// Memory limit: 16MB
// Sample tests

// Input		Output
// FE			254
// 1AE3			6883
// 4ED528CBB4	338583669684