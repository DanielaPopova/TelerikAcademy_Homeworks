/*jshint esversion: 6 */
function solve(params) {
      const fieldSize = params[0].split(' ').map(Number),
            rows = fieldSize[0],
            cols = fieldSize[1],
            field = [];
      params.shift();

      for (let i = 0, len = params.length; i < len; i += 1) {
          field[i] = params[i].split(' ').map(Number);
      }

      const visited = 0;            
      let positionRow = rows / 2 | 0,
          positionCol = cols / 2 | 0;         

      while(positionRow >= 0 && positionRow < rows &&
            positionCol >= 0 && positionCol < cols){

          let currNum = field[positionRow][positionCol],
                bitOne = getBitAtPosition(currNum, 0),
                bitTwo = getBitAtPosition(currNum, 1),
                bitThree = getBitAtPosition(currNum, 2),
                bitFour = getBitAtPosition(currNum, 3);

          field[positionRow][positionCol] = visited;
          
          if (bitOne === 1 && positionRow - 1 >= 0 && field[positionRow - 1][positionCol] !== visited) {
              positionRow -= 1;
          } else if (bitTwo === 1 && positionCol + 1 < cols && field[positionRow][positionCol + 1] !== visited) {
              positionCol += 1;
          } else if (bitThree === 1 && positionRow + 1 < rows && field[positionRow + 1][positionCol] !== visited) {
              positionRow += 1;
          } else if (bitFour === 1 && positionCol - 1 >= 0 && field[positionRow][positionCol - 1] !== visited) {
              positionCol -= 1;
          } else {              
              return `No JavaScript, only rakiya ${positionRow} ${positionCol}`;
          }

          if (positionRow - 1 < 0 || positionRow + 1 >= rows ||
              positionCol + 1 >= cols || positionCol - 1 < 0) {

              return `No rakiya, only JavaScript ${positionRow} ${positionCol}`;
          }      
      } 

      function getBitAtPosition(currNum, position) {
          return (currNum >> position) & 1;
      }
}

console.log(solve([
    '5 7',
    '9 5 3 11 9 5 3',
    '10 11 10 12 4 3 10',
    '10 10 12 7 13 6 10',
    '12 4 3 9 5 5 2',
    '13 5 4 6 13 5 6'
      ]));

console.log(solve([
    '7 5',
    '9 3 11 9 3',
    '10 12 4 6 10',
    '12 3 13 1 6',
    '9 6 11 12 3',
    '10 9 6 13 6',
    '10 12 5 5 3',
    '12 5 5 5 6'
      ]));




// for (let row = 0; row < rows; row += 1) {
      //     for (let col = 0; col < cols; col += 1) {

            
      //         //console.log(field[row][col]);
      //     }
          
      // }