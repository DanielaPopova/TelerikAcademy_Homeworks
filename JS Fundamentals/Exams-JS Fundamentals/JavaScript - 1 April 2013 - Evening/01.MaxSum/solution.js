function solve(args) {
    var input = args.map(Number),
        i, j, len, scurrSum = 0;
    input.shift();
    var sum = Math.max.apply(null, input);

    for (i = 0, len = input.length; i < len; i += 1) {
        currSum = input[i];
        for (j = i + 1; j < len; j += 1) {
            currSum += input[j];
            if (currSum >= sum) {
                sum = currSum;
            }
        }
    }

    return sum;
}

console.log(solve(['8', '1', '6', '-9', '4', '4', '-2', '10', '-1']));
console.log(solve(['6', '1', '3', '-5', '8', '7', '-6']));
console.log(solve(['9', '-9', '-8', '-8', '-7', '-6', '-5', '-1', '-7', '-6']));

