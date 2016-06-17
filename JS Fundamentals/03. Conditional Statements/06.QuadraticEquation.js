function calculateRoots(args) {
	var discriminant,
		x1,
		x2,
		a = +args[0],
		b = +args[1],
		c = +args[2];
	discriminant = (b * b) - (4 * a * c);

	if (discriminant < 0) {
		return 'no real roots';
	} else if (!discriminant) {
		x1 = -b / (2 * a);
		return 'x1=x2=' + x1.toFixed(2);
	} else {
		x1 = (-b - Math.sqrt(discriminant)) / (2 * a);
		x2 = (-b + Math.sqrt(discriminant)) / (2 * a);

		return 'x1=' + x1.toFixed(2) + ';' + ' x2=' + x2.toFixed(2);		
	}
}

console.log(calculateRoots(['2', '5', '-3']));
console.log(calculateRoots(['-1', '3', '0']));
console.log(calculateRoots(['-0.5', '4', '-8']));
console.log(calculateRoots(['5', '2', '8']));
console.log(calculateRoots(['0.2', '9.572', '0.2']));

// Write a script that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0
// and solves it (prints its real roots). Calculates and prints its real roots.

// Note: Quadratic equations may have 0, 1 or 2 real roots.

// Input

// The input will consist of an array containing three values - a, b and c represented as strings
// Output

// The output should be a single line containing the real roots (see sample tests)
// Print numbers with two digits of precision after the floating point
// If there are two roots then x1 < x2
// Constraints

// Time limit: 0.2s
// Memory limit: 16MB
// Sample tests

// Input	Output
// 2
// 5
// -3		x1=-3.00; x2=0.50
// -1
// 3
// 0		x1=0.00; x2=3.00
// -0.5
// 4
// -8		x1=x2=4.00
// 5
// 2
// 8		no real roots
// 0.2
// 9.572
// 0.2		x1=-47.84; x2=-0.02				