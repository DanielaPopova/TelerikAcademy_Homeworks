function planarSystem(args) {
  var i, len, pointA, pointB, line,
    linesArray = [],
    input = args.map(Number);


  for (i = 0, len = input.length; i < len; i += 4) {
    pointA = createPoint(input[i], input[i + 1]);
    pointB = createPoint(input[i + 2], input[i + 3]);

    line = createLine(pointA, pointB);
    console.log((line.length).toFixed(2));

    linesArray.push(line);
  }
  console.log(isTriangle(linesArray[0], linesArray[1], linesArray[2]));

  function createPoint(x, y) {
    return {
      x: x,
      y: y
    };
  }

  function createLine(pointA, pointB) {
    return {
      pointA: pointA,
      pointB: pointB,
      length: lineDistance(pointA, pointB)
    };
  }

  function lineDistance(pA, pB) {
    var length;
    length = Math.sqrt((pB.x - pA.x) * (pB.x - pA.x) + (pB.y - pA.y) * (pB.y - pA.y));

    return length;
  }

  function isTriangle(lineA, lineB, lineC) {

    if ((lineA.length + lineB.length) > lineC.length && (lineB.length + lineC.length) > lineA.length && (lineA.length + lineC.length) > lineB.length) {
      return 'Triangle can be built';
    } else {
      return 'Triangle can not be built';
    }
  }
}

planarSystem(['5', '6', '7', '8', '1', '2', '3', '4', '9', '10', '11', '12']);
planarSystem(['7', '7', '2', '2', '5', '6', '2', '2', '95', '-14.5', '0', '-0.123']);
/*
Write functions for working with shapes in standard Planar coordinate system.

Points are represented by coordinates
Lines are represented by two points, marking their beginning and ending.
You will be given three line segments. Calculate their length. Check if the line segments can form a triangle.
Input

The input will consist of an array containing twelve values
Line 1, Point 1 X
Line 1, Point 1 Y
Line 1, Point 2 X
Line 1, Point 2 Y
Line 2, Point 1 X
...
Output

The output should be consisted of four lines
Three lines showing the length of each line segment
Use 2 digits of precision
Fourth line should be one of:
Triangle can be formed
Triangle can't be formed
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample Test 1

Input
[
  '5', '6', '7', '8',
  '1', '2', '3', '4',
  '9', '10', '11', '12'
]

Output
2.83
2.83
2.83
Triangle can be built

Sample Test 2

Input
[
  '7', '7', '2', '2',
  '5', '6', '2', '2',
  '95', '-14.5', '0', '-0.123'
]

Output
7.07
5.00
96.08
Triangle can not be built
*/