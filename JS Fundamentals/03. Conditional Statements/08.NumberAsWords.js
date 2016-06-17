function convertNumberToWords(args) {
	var number = +args[0];
	var result = '';
	var onesLow = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
	var onesUp = ['Zero', 'One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine'];
	var tensLow = ['', 'ten', 'twenty', 'thirty', 'fourty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety',];
	var tensUp = ['', 'Ten', 'Twenty', 'Thirty', 'Fourty', 'Fifty', 'Sixty', 'Seventy', 'Eighty', 'Ninety',];
	var teensLow = ['ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];
	var teensUp = ['Ten', 'Eleven', 'Twelve', 'Thirteen', 'Fourteen', 'Fifteen', 'Sixteen', 'Seventeen', 'Eighteen', 'Nineteen'];

	var hundreds = number / 100 | 0;	
	var tens = (number / 10) % 10 | 0;	
	var ones = number % 10;
	
	if (hundreds === 0 && tens === 0) {
		result = onesUp[ones];
	} else if (hundreds === 0) {
		if (tens === 1) {
			result = teensUp[ones];
		} else {
			if (ones === 0) {
				result = tensUp[tens];
			}
			else {
				result = tensUp[tens] + ' ' + onesLow[ones];
			}	
		}
	} else {
		if (tens === 0 && ones === 0) {
			result = onesUp[hundreds] + ' hundred';
		} else if (ones === 0) {
			result = onesUp[hundreds] + ' hundred' + ' and ' + tensLow[tens];
		} else if (tens === 0){
			result = onesUp[hundreds] + ' hundred' + ' and ' + onesLow[ones];
		} else {
			if (tens === 1 && ones >= 1) {
				result = onesUp[hundreds] + ' hundred' + ' and ' + teensLow[ones];
			} else {
				result = onesUp[hundreds] + ' hundred' + ' and ' + tensLow[tens] + ' ' + onesLow[ones];
			}
		}
	}

	return result;
}

console.log(convertNumberToWords(['0']));
console.log(convertNumberToWords(['9']));
console.log(convertNumberToWords(['10']));
console.log(convertNumberToWords(['12']));
console.log(convertNumberToWords(['19']));
console.log(convertNumberToWords(['25']));
console.log(convertNumberToWords(['98']));
console.log(convertNumberToWords(['273']));
console.log(convertNumberToWords(['400']));
console.log(convertNumberToWords(['501']));
console.log(convertNumberToWords(['617']));
console.log(convertNumberToWords(['711']));
console.log(convertNumberToWords(['999']));

/*
Write a script that converts a number in the range [0…999] to words, corresponding to its English pronunciation.

Input

The input will consist of an array containing the number as a string
Output

The output should be a single line containing the answer
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input	Output
0		Zero
9		Nine
10		Ten
12		Twelve
19		Nineteen
25		Twenty five
98		Ninety eight
273		Two hundred and seventy three
400		Four hundred
501		Five hundred and one
617		Six hundred and seventeen
711		Seven hundred and eleven
999		Nine hundred and ninety nine
*/