/*jshint esversion: 6 */
function solve(params) {
  const heights = params[0].split(' ').map(Number);
  let maxSum = 0,
      allPeaksIndexes = [];     

  allPeaksIndexes.push(0);

  for (let i = 1, len = heights.length; i < len - 1; i += 1) {
        let currHeight = heights[i];

        if (currHeight > heights[i - 1] && currHeight > heights[i + 1]) {
            allPeaksIndexes.push(i);
        }
  }

  allPeaksIndexes.push(heights.length - 1);

  for (let i = 1, len = allPeaksIndexes.length; i < len; i += 1) {
      let currSum = allPeaksIndexes[i] - allPeaksIndexes[i - 1];
      if (currSum > maxSum) {
          maxSum = currSum;
      }
  }

  console.log(maxSum);
}

solve(['5 1 7 4 8']);
solve(['5 1 7 6 3 6 4 2 3 8']);
solve(['10 1 2 3 4 5 4 3 2 1 10']);
