function calculateAreaPerimeter(args) {
    var width = parseFloat(args[0]),
        height = parseFloat(args[1]);

    var area = (width * height).toFixed(2);

    var perimeter = (2 * height + 2 * width).toFixed(2);

    console.log(area + ' ' + perimeter);
}

calculateAreaPerimeter(['2.5', '3']);
calculateAreaPerimeter(['5', '5']);
calculateAreaPerimeter(['3', '4']);

// Implement a javascript function that takes an argument array as a parameter and calculates rectangle’s
// area and perimeter by given width and height. The width and height will both be passed in the argument array.

// Input

// The array that will be passed as argument will always have exactly 2 elements:
// The first element - a floating-point number that will represent the width of the rectangle.
// The second element - another floating-point number that will represent the height of the rectangle.
// Output

// Output a single line - the rectangle's area and perimeter, separated by a whitespace.
// Print the area and perimeter values with exactly 2-digits precision after the floating point.
// You can use console.log to print the results or you can use return to return the answer. Both are correct.
// Constraints

// The width and height will always be valid floating-point numbers.
// Time limit: 0.2s
// Memory limit: 16MB
// Sample tests

// Input	Output
// 2.5		7.50 11.00
// 3	
// 5		25.00 20.00
// 5		
// 3		12.00 14.00
// 4		