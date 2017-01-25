let result = function solve() {
    
  return function findPrimes(start, end) {

        if (arguments.length < 2) {
            throw new Error('Both parameters should be present!');
        }

        if (isNaN(start) || isNaN(end)) {
            throw new Error('Both parameters should be numbers!');
        }

        let primeNums = [];

        for (let i = +start; i <= +end; i += 1) {
            if (isPrime(i)) {
                primeNums.push(i);
            }
        }

        return primeNums;

        function isPrime(number) {

            if (number < 2) {
                return false;
            }

            let maxDivisor = Math.floor(Math.sqrt(number));

            for (let i = 2; i <= maxDivisor; i += 1) {
                if (number % i === 0) {
                    return false;
                }
            }

            return true;
        }
    };
}();


console.log(result(1, 5));
console.log(result(1));
console.log(result());

//module.exports = findPrimes;
