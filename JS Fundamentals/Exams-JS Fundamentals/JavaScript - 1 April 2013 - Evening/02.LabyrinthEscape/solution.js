function solve(args) {
    var rowsCols = args[0].split(' ').map(Number);
    var rows = rowsCols[0];
    var cols = rowsCols[1];

    var startPosition = args[1].split(' ').map(Number);
    var currRow = startPosition[0];
    var currCol = startPosition[1];

    var field = fillField();
    //console.log(field);
    var directions = initDirection();
    //console.log(directions);
    var sum = 0,
        cell = 0,
        isOut = false;


    while (true) {
        if (currRow < 0 || currRow >= rows || currCol < 0 || currCol >= cols) {
            isOut = true;
            break;
        }

        if (field[currRow][currCol] === 'x') {
            isOut = false;
            break;
        }

        sum += field[currRow][currCol];
        //console.log(sum);
        var currDirection = directions[currRow][currCol];
        //console.log(currDirection + ' direction');
        cell += 1;
        field[currRow][currCol] = 'x';

        switch (currDirection) {
            case 'l':
                currCol = currCol - 1;
                break;
            case 'r':
                currCol = currCol + 1;
                break;
            case 'd':
                currRow = currRow + 1;
                break;
            case 'u':
                currRow = currRow - 1;
                break;
        }
    }

    if (isOut) {
        return 'out ' + sum;
    } else {
        return 'lost ' + cell;
    }

    // function getValueAt(row, col, cols) {
    //   return row * cols + col + 1;
    // }

    function fillField() {
        var field = [],
            i, j, counter = 1;
        for (i = 0; i < rows; i += 1) {
            field[i] = [];
            for (j = 0; j < cols; j += 1) {
                field[i][j] = counter++;
            }
        }
        return field;
    }

    // var directionArr = args.slice(2);
    function initDirection() {
        var directionArr = [],
            i, j, len;
        for (i = 2, len = args.length; i < 2 + rows; i += 1) {
            var currDirections = args[i];
            directionArr.push(currDirections);
        }
        return directionArr;
    }
}

console.log(solve(["3 4", "1 3", "lrrd", "dlll", "rddd"]));
console.log(solve(["5 8", "0 0", "rrrrrrrd", "rludulrd", "durlddud", "urrrldud", "ulllllll"]));
console.log(solve(["5 8", "0 0", "rrrrrrrd", "rludulrd", "lurlddud", "urrrldud", "ulllllll"]));