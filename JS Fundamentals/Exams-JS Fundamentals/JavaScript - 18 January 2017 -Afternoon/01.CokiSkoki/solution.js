/*jshint esversion: 6 */

function solve(params) {
    let numbers = params.map(Number),
        lenghtArray = numbers.shift(),
        sum = 0,        
        currIndex = 0;

    const module = 1024;

    while(currIndex < lenghtArray){
        let currNum = numbers[currIndex];

        if (currNum % 2 === 1) {
            if (currIndex === 0) {
                sum = 1;
            }
            sum *= currNum;
            currIndex += 1;
        } else {
            sum += currNum;
            currIndex += 2;
        }

        sum = sum % module;
    }

    console.log(sum);

}

solve([
        '10',
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9',
        '0'
          ]);

solve([
      '9',
      '9',
      '9',
      '9',
      '9',
      '9',
      '9',
      '9',
      '9',
      '9'
        ]);