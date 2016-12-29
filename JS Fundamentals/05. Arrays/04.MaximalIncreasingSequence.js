function maxIncreaseSequence(args) {
    let length = +args.shift(),
        numbers = args.map(Number),
        count = 1,
        maxCount = 0;

    for (let i = 0; i < numbers.length - 1; i += 1) {
        if (numbers[i] < numbers[i + 1]) {
            count += 1;
            if (count > maxCount) {
                maxCount = count;
            }
        } else {
            count = 1;
        }
    }
    return maxCount;
}

console.log(maxIncreaseSequence(['8', '7', '3', '2', '3', '4', '2', '2', '4']));

/*
Write a program that finds the length of the maximal increasing sequence in an array of N integers.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the length of the maximal increasing sequence
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input 
['8', '7', '3', '2', '3', '4', '2', '2', '4']

Output
3

*/