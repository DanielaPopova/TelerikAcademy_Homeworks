function solve(args) {
    var size = args[0].split(' ').map(Number),
        rows = size[0],
        cols = size[1];

    var matrix = args.slice(1)
        .map(function(line) {
            return line.split(' ');
        }),

        row = 0,
        col = 0,
        sum = 0,
        direction,
        deltas = {
            u: -1,
            d: +1,
            l: -1,
            r: +1
        },
        leftRight,
        upDown;

    while (true) {
        if (row < 0 || row >= rows || col < 0 || col >= cols) {
            return 'successed with ' + sum;
        }

        if (matrix[row][col] === 'x') {
            return 'failed at (' + row + ', ' + col + ')';
        }

        sum += Math.pow(2, row) + col;

        direction = matrix[row][col];
        upDown = direction[0];
        leftRight = direction[1];

        matrix[row][col] = 'x';
        row += deltas[upDown];
        col += deltas[leftRight];
    }
}

var test1 = [
'3 5',
'dr dl dr ur ul',
'dr dr ul ur ur',
'dl dr ur dl ur'
];

var test2 = [
'3 5',
'dr dl dl ur ul',
'dr dr ul ul ur',
'dl dr ur dl ur'
];

console.log(solve(test1));
console.log(solve(test2));
