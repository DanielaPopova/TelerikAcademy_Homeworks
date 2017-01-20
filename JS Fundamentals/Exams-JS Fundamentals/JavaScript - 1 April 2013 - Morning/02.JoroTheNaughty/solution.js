function solve(args) {
    var i, len,
        info = args[0].split(' ').map(Number),
        rows = info[0],
        cols = info[1],
        jumpsCount = info[2],

        field = fillField(rows, cols),
        allJumpArr = allJumps(),

        startPosition = args[1].split(' ').map(Number),
        currentRow = startPosition[0],
        currentCol = startPosition[1],

        jumpsIndex = 0,
        escaped = false,
        sumOfNumbers = 0,
        totalJumps = 0;

    while (true) {
        if (currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols) {
            escaped = true;
            break;
        }

        if (field[currentRow][currentCol] === 'x') {
            escaped = false;
            break;
        }

        sumOfNumbers += field[currentRow][currentCol];
        totalJumps += 1;

        var currJump = allJumpArr[jumpsIndex++];
        if (jumpsIndex >= allJumpArr.length) {
            jumpsIndex = 0;
        }

        field[currentRow][currentCol] = 'x';

        currentRow += currJump.row;
        currentCol += currJump.col;
    }

    return escaped ? 'escaped ' + sumOfNumbers : 'caught ' + totalJumps;

    function fillField(rows, cols) {
        var i, len, counter = 1,
            field = [];

        for (i = 0; i < rows; i += 1) {
            field[i] = [];
            for (j = 0; j < cols; j += 1) {
                field[i][j] = counter;
                counter += 1;
            }
        }
        return field;
    }

    function allJumps() {
        var jumpsArray = [];
        for (i = 2, len = args.length; i < 2 + jumpsCount; i += 1) {
            var jumps = args[i].split(' ').map(Number);
            var jump = {
                row: jumps[0],
                col: jumps[1]
            };
            jumpsArray.push(jump);
        }
        return jumpsArray;
    }
}

console.log(solve(['6 7 3', '0 0', '2 2', '-2 2', '3 -1']));