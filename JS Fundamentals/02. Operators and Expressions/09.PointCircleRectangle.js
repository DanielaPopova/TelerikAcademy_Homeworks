function inCircleOutRectangle(args) {
	var x = +args[0],
		y = +args[1];
	var xCircle = 1,
		yCircle = 1,
		radius = 1.5;
	var result;
	var circleDistance = Math.sqrt((x - xCircle)*(x - xCircle) + (y - yCircle)*(y - yCircle));
	var inCircle = circleDistance <= radius;
	var inRectangle = (-1 <= x && x <= 5) && (-1 <= y && y <= 1);

	if (inCircle) {
		result = 'inside circle' + ' ' + (inRectangle ? 'inside rectangle' : 'outside rectangle');
	} else {
		result = 'outside circle' + ' ' + (inRectangle ? 'inside rectangle' : 'outside rectangle');		
	}

	return result;
}

console.log(inCircleOutRectangle(['2.5', '2']));
console.log(inCircleOutRectangle(['0', '1']));
console.log(inCircleOutRectangle(['2.5', '1']));
console.log(inCircleOutRectangle(['1', '2']));

// Implement a javascript function that accepts an array with a pair of coordinates x and y
// and uses an expression to checks for given point (x, y) if it is within the circle K({1, 1}, 1.5)
// and out of the rectangle R(top=1, left=-1, width=6, height=2).

// Input

// You will receive the pair of coordinates as two elements of an array - the first element will be x, and the second - y.
// Output

// Print inside circle if the point is inside the circle and outside circle if it's outside.
// Then print a single whitespace followed by inside rectangle if the point is inside the rectangle and outside rectangle otherwise.
// See the sample tests for a visual description.
// You can use console.log to print the results or you can use return to return the answer. Both are correct.
// Constraints

// The coordinates x and y will always be valid floating-point numbers in the range [-1000, 1000].
// Time limit: 0.1s
// Memory limit: 16MB
// Sample tests

// Input	Output
// 2.5
// 2		outside circle outside rectangle
// 0
// 1		inside circle inside rectangle
// 2.5
// 1		inside circle inside rectangle
// 1
// 2		inside circle outside rectangle