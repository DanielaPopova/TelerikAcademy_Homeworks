// with sieve, time limit!
function eratosthenesPrimes(number) {
  var i, j, len,
    array = [],
    primeArray = [],
    upperLimit = Math.sqrt(number);

  for (i = 0; i <= number; i += 1) {
    array.push(true);
  }

  for (i = 2; i <= upperLimit; i += 1) {
    if (array[i]) {
      for (j = i * i; j <= number; j += i) {
        array[j] = false;
      }
    }
  }

  for (i = 2; i <= number; i += 1) {
    if (array[i]) {
      primeArray.push(i);
    }
  }

  return primeArray[primeArray.length - 1];
}

// normal
function maxPrime(number) {
  var i, divider, maxPrime = 2;

  for (i = number; i >= 2; i -= 1) {

    var isPrime = true;
    for (divider = 2; divider * divider <= number; divider += 1) {
      if (i % divider === 0) {
        isPrime = false;
        break;
      }
    }

    if (isPrime) {
      maxPrime = i;
      break;
    }
  }

  return maxPrime | 0;
}

console.log(maxPrime(13.6));
console.log(maxPrime(126));
console.log(maxPrime(26));

/*
Write a program that finds all prime numbers in the range [1 ... N]. Use the Sieve of Eratosthenes algorithm.
The program should print the biggest prime number which is <= N.

Input

On the first line you will receive the number N
Output

Print the biggest prime number which is <= N
Constraints

2 <= N <= 10 000 000
Time limit: 0.3s
Memory limit: 64MB
Sample tests

Input   Output
13      13
126     113
26      23
*/
 // for (i = 0; i <= number; i += 1) {
 //        array.push(true);
 //    }

 //    for (i = 2; i <= upperLimit; i += 1) {
 //        if (array[i]) {
 //          for (j = i * i; j <= number; j += i) {
 //              array[j] = false;
 //          }
 //        }
 //    }

 //    for (i = number; i >= 2 ; i -= 1) {
 //        if (array[i]) {
 //          primeArray.push(i);
 //          break;
 //        }
 //    }    

 //    return primeArray[primeArray.length - 1];