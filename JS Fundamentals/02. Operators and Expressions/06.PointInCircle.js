function isPointInCircle(args) {
	var x = parseFloat(args[0]),
		y = parseFloat(args[1]),
		radius = 2;
	var condition = (Math.sqrt((x - 0)*(x - 0) + (y - 0)*(y - 0)));	
	if (condition <= radius) {
		return 'yes' + ' ' + condition.toFixed(2);
	}
	else {
		return 'no' + ' ' + condition.toFixed(2);
	}
}

console.log(isPointInCircle(['-2', '0']));
console.log(isPointInCircle(['-1', '2']));
console.log(isPointInCircle(['1.5', '-1']));
console.log(isPointInCircle(['-1.5', '-1.5']));
console.log(isPointInCircle(['100', '-30']));
console.log(isPointInCircle(['0', '0']));


// Implement a javascript function that by given coordinates of a point x and y and using an expression checks
// if given point (x, y) is inside a circle K({0, 0}, 2) - the center has coordinates (0, 0) and the circle has radius 2.
// The program should then print "yes DISTANCE" if the point is inside the circle or "no DISTANCE" if the point is outside the circle.

// In place of DISTANCE print the distance from the beginning of the coordinate system - (0, 0) - to the given point.
// Input

// You will receive an array as a parameter. The array will contain exactly 2 string elements, the first being the x coordinate and the second - the y coordinate.
// Output

// Output a single line in the format described above. The distance should always be printed with 2-digits of precision after the floating point.
// You can use console.log to print the results or you can use return to return the answer. Both are correct.
// Constraints

// The numbers x and y will always be valid floating point numbers in the range (-1000, 1000)
// Time limit: 0.1s
// Memory limit: 16MB
// Sample tests

// Input	Output
// -2
// 0		yes 2.00
// -1
// 2		no 2.24
// 1.5
// -1		yes 1.80
// -1.5
// -1.5		no 2.12
// 100
// -30		no 104.40
// 0
// 0		yes 0.00
// 0.2
// -0.8		yes 0.82
// 0.9
// -1.93	no 2.13
// 1
// 1.655	yes 1.93
// 0
// 1		yes 1.00