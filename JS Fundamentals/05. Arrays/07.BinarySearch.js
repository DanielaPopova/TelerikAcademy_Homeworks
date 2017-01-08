// doesn't work if searchedNum occurs more than once in the sequence 90/100
function solve(arr) {
    var input = arr.map(Number),
        find, len, i, j, left, right, found;

    input.splice(0, 1);
    len = input.length;
    find = input.splice(len - 1, 1);
    len -= 1;

    input.sort(function (a, b) {
        if (+a < +b) {
            return -1;
        } else if (+a > +b) {
            return 1;
        } else {
            return 0;
        }
    });

    left = 0;
    right = len - 1;

    function binarySearch(leftarg, rightarg) {
        var leftIndex = +leftarg;
        var rightIndex = +rightarg;

        var mid = ((rightIndex - leftIndex) / 2 + leftIndex) | 0;

        if (leftIndex === rightIndex) {
            found = -1;
            return;
        }

        if (+find === input[mid]) {
            found = mid;
            return;
        } else if (+find < input[mid]) {
            binarySearch(leftIndex, mid);
        } else {
            binarySearch(mid + 1, rightIndex);
        }
    }

    binarySearch(left, right);

    console.log(found);
}

// function binarySearch(args) {
//     let numbers = args.map(Number),
//         length = numbers.shift(),
//         searchedNum = numbers.pop(),
//         firstMet = false,
//         startIndex = 0,
//         endIndex = length - 1,
//         middleIndex;

//     // just in case
//     numbers.sort(function(a, b) {
//         return a - b;
//     });
        
//     while (startIndex <= endIndex) {
//         middleIndex = (startIndex + endIndex) / 2 | 0;
        
//         if (numbers[middleIndex] === searchedNum) {

//             for (let i = 0; i < middleIndex; i++) {
//                 if (numbers[i] === searchedNum) {
//                     return i;
//                 }
//             }

//             return middleIndex;            
//         }

//         if (numbers[startIndex] > searchedNum || numbers[endIndex] < searchedNum) {
//            return -1;
//         }

//         if (numbers[middleIndex] < searchedNum) {
//             startIndex = middleIndex + 1;
//         } else if (numbers[middleIndex] > searchedNum) {
//             endIndex = middleIndex - 1;
//         }        
//     }   
// }

solve(['10', '1', '2', '4', '8', '16', '31', '32', '64', '77', '99', '32']);
solve(['11', '1', '2', '4', '8', '31', '31', '31', '64', '77', '99', '100','31']);
solve(['11', '1', '2', '4', '8', '29', '30', '31', '31', '77', '99', '100','31']);
solve(['11', '1', '2', '4', '31', '31', '32', '33', '34', '77', '99', '100','31']);
solve(['10', '1', '2', '4', '8', '31', '31', '31', '64', '77', '99', '31']);
solve(['10', '1', '2', '4', '8', '30', '31', '31', '64', '77', '99', '31']);
solve(['10', '32', '32', '32', '32', '32', '32', '32', '32', '32', '32', '32']);
solve(['2', '3', '3', '3']);
solve(['1', '1', '1']);
solve(['1', '1', '2']);



/*
Write a program that finds the index of given element X in a sorted array of N integers by using the Binary search algorithm.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
On the last line you will receive the number X
Output

Print the index where X is in the array
If there is more than one occurence print the first one
If there are no occurences print -1
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input
['10', '1', '2', '4', '8', '16', '31', '32', '64', '77', '99', '32']

Output
6

*/