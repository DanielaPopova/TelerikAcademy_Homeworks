function solve(args) {
    var count = 1;
    args = args.map(Number);

    for (var i = 2, len = args.length; i < len; i += 1) {
        if (args[i - 1] > args[i]) {
            count += 1;
        }
    }

    return count;
}

console.log(solve(['7', '1', '2', '-3', '4', '4', '0', '1']));
console.log(solve(['6', '1', '3', '-5', '8', '7', '-6']));
console.log(solve(['9', '1', '8', '8', '7', '6', '5', '7', '7', '6']));

