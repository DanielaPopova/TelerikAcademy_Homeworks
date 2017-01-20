function solve(args) {
    var size = args[0].split(' ').map(Number),
        rows = size[0],
        cols = size[1],
        directions = args.slice(1),
        valueMatrix = fillValueMatrix(),
        currRow = rows - 1,
        currCol = cols - 1,

        points = 0,
        moves = 0;

    while (true) {
        if (currRow < 0 || currRow >= rows || currCol < 0 || currCol >= cols) {
            return 'Go go Horsy! Collected ' + points + ' weeds';
        }

        if (valueMatrix[currRow][currCol] === 'x') {
            return 'Sadly the horse is doomed in ' + moves + ' jumps';
        }
        points += valueMatrix[currRow][currCol];
        moves += 1;
        var currPosition = directions[currRow][currCol];

        valueMatrix[currRow][currCol] = 'x';

        switch (+currPosition) {
            case 1:
                currRow -= 2;
                currCol += 1;
                break;
            case 2:
                currRow -= 1;
                currCol += 2;
                break;
            case 3:
                currRow += 1;
                currCol += 2;
                break;
            case 4:
                currRow += 2;
                currCol += 1;
                break;
            case 5:
                currRow += 2;
                currCol -= 1;
                break;
            case 6:
                currRow += 1;
                currCol -= 2;
                break;
            case 7:
                currRow -= 1;
                currCol -= 2;
                break;
            case 8:
                currRow -= 2;
                currCol -= 1;
                break;
        }
    }

    function fillValueMatrix() {
        var matrix = [],
            i, j, counter = Math.pow(2, 0);
        for (i = 0; i < rows; i += 1) {
            matrix[i] = [];
            for (j = 0; j < cols; j += 1) {
                matrix[i][j] = counter--;
            }
            counter = Math.pow(2, i + 1);
        }
        return matrix;
    }
}

var test1 = [
'3 5',
'54561',
'43328',
'52388',
];

var test2 = [
'3 5',
'54361',
'43326',
'52188',
];

console.log(solve(test1));
console.log(solve(test2));
