// doesn't work if searchedNum occurs more than once in the sequence 90/100
function binarySearch(args) {
    let numbers = args.map(Number),
        length = numbers.shift(),
        searchedNum = numbers.pop(),
        firstMet = false,
        startIndex = 0,
        endIndex = length - 1,
        middleIndex;

    while (startIndex <= endIndex) {
        middleIndex = (startIndex + endIndex) / 2 | 0;
        
        if (numbers[middleIndex] === searchedNum) {            
            return middleIndex;            
        }

        if (numbers[startIndex] > searchedNum || numbers[endIndex] < searchedNum) {
           return -1;
        }

        if (numbers[middleIndex] < searchedNum) {
            startIndex = middleIndex + 1;
        } else if (numbers[middleIndex] > searchedNum) {
            endIndex = middleIndex - 1;
        }        
    }   
}

console.log(binarySearch(['10', '1', '2', '4', '5', '16', '31', '32', '64', '77', '99', '32']));

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