/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(start, end) {
	 if (arguments.length < 2) {
      throw new Error('Both parameters should be present!');
   }

   if (isNaN(start) || isNaN(end)) {
      throw new Error('Both parameters should be numbers!');
   }

   var primeNums = [];

   for (var i = start; i <= end; i += 1) {
       if (isPrime(i)) {
          primeNums.push(i);
       }
   }

   return primeNums;

   function isPrime(number) {

      if (number < 2) {
          return false;
       }

       var maxDivisor = Math.floor(Math.sqrt(number));

       for (var i = 2; i <= maxDivisor; i += 1) {
           if (number % i === 0) {
              return false;
           }
       }

       return true;       
   }

}

console.log(findPrimes(1, 5));
console.log(findPrimes());

module.exports = findPrimes;
