function maximalSequence(params) {
    let length = +params.shift(),
        sequence = params.map(Number),
        count = 1,
        maxCount = 0;

    for (let i = 0; i < sequence.length - 1; i += 1) {
        if (sequence[i] === sequence[i + 1]) {
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

console.log(maximalSequence(['10', '2', '1', '1', '2', '3', '3', '2', '2', '2', '1']));

/*
Write a program that finds the length of the maximal sequence of equal elements in an array of N integers.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the length of the maximal sequence
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input   
['10', '2', '1', '1', '2', '3', '3', '2', '2', '2', '1']

Output
3

*/