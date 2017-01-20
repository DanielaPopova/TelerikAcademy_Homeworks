function solve(args) {
    var i, j, k,
        input = args.map(Number),
        money = args[0],
        costFirstCake = args[1],
        costSecondCake = args[2],
        costThirdCake = args[3],
        maxSum = 0,
        currSum;

    for (i = 0; i <= money / costFirstCake; i += 1) {
        for (j = 0; j <= money / costSecondCake; j += 1) {
            for (k = 0; k <= money / costThirdCake; k += 1) {
                currSum = costFirstCake * i + costSecondCake * j + costThirdCake * k;
                if (currSum > maxSum && currSum <= money) {
                    maxSum = currSum;
                }
            }
        }
    }

    return maxSum;
}

console.log(solve(['110', '13', '15', '17']));
console.log(solve(['20', '11', '200', '300']));
console.log(solve(['110', '19', '29', '39']));
