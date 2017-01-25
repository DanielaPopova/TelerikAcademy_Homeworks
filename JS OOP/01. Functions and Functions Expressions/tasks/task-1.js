let result = function solve() {

    return function sumNumbers(numbers) {

        if (numbers === undefined) {
            throw new Error('You should pass an argument!');
        }

        if (!numbers.length) {
            return null;
        }

        let sum = 0;

        for (let i = 0, len = numbers.length; i < len; i += 1) {
            let currEl = numbers[i];

            if (isNaN(currEl)) {
                throw new Error('All elements in the array should be numbers!');
            }

            sum += Number(currEl);
        }

        return sum;
    };

}();

console.log(result());
console.log(result([]));
console.log(result([1, 'john', 3]));
console.log(result([1, 2, 3]));
console.log(result([1, '2', 3]));
console.log(result([1, '2.23', 3]));
console.log(result([1.77, '2.23', 3]));

//module.exports = solve;