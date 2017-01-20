function solve(input) {
    var info = input[0].split(' ').map(Number),
        transCount = info[1];
    //console.log(transCount);
    var i, len;
    var numbers = input.slice(1)[0].split(' ').map(Number);
    var copy = numbers.slice(0);

    var newNum, currNum, leftNeighbor, rightNeighbor, sum = 0,
        finalKSum = 0;
    if (transCount === 0) {
        for (i = 0, len = numbers.length; i < len; i += 1) {
            finalKSum += numbers[i];
        }
    } else {
        while (transCount > 0) {
            var newNumArr = [];

            for (i = 0, len = copy.length; i < len; i += 1) {

                leftNeighbor = i === 0 ? copy[copy.length - 1] : copy[i - 1];
                rightNeighbor = i === copy.length - 1 ? copy[0] : copy[i + 1];

                currNum = copy[i];
                if (currNum === 0) {
                    newNum = Math.abs(leftNeighbor - rightNeighbor);
                } else if (currNum === 1) {
                    newNum = leftNeighbor + rightNeighbor;
                } else if (currNum % 2 === 0) {
                    newNum = Math.max(leftNeighbor, rightNeighbor);
                } else {
                    newNum = Math.min(leftNeighbor, rightNeighbor);
                }

                newNumArr.push(newNum);
            }

            for (i = 0, len = newNumArr.length; i < len; i += 1) {
                sum += newNumArr[i];
            }

            if (transCount === 1) {
                finalKSum = sum;
            } else {
                sum = 0;
            }

            copy = newNumArr.slice(0);

            transCount -= 1;
        }
    }
    console.log(finalKSum);
}

var test1 = ['5 1', '9 0 2 4 1'];
var test2 = ['10 3', '1 9 1 9 1 9 1 9 1 9'];
var test3 = ['10 10', '0 1 2 3 4 5 6 7 8 9'];

solve(test1);
solve(test2);
solve(test3);
