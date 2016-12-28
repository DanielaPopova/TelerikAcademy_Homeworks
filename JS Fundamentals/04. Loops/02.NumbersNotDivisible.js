function printNumNotDivisible(number) {
    var i;

    for (i = 1; i <= number; i += 1) {

        if (i % 21 !== 0) {
            console.log(i);
        }
    }
}

printNumNotDivisible(43);

// Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time