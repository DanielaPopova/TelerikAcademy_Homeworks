function solve(argument) {
    let heights = argument[0].split(' ').map(Number),
        sumPocket = 0;

    for (let i = 2, len = heights.length - 2; i < len; i += 1) {
      let currHeight = heights[i],
          nextHeight = heights[i + 1],
          previousHeight = heights[i - 1];

        if (currHeight < nextHeight && currHeight < previousHeight) {
              if (nextHeight > heights[i + 2] && previousHeight > heights[i - 2]) {
                  sumPocket += currHeight;
              }
        }
    }

    return sumPocket;
}

console.log(solve(['53 20 1 30 2 40 3 10 1']));
console.log(solve(['53 20 1 30 30 2 40 3 10 1']));
console.log(solve(['53 20 1 30 2 40 3 3 10 1']));

