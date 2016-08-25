/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(numArray) {
  var i, len, currEl, sum = 0;
  
	if (numArray.length === 0) {  //!numArray.length
      return null;
  }

  if (numArray === undefined) {
      throw new Error('You should pass an argument!');
  }

  for (i = 0, len = numArray.length; i < len; i += 1) {
      currEl = numArray[i];

      if (isNaN(currEl)) {
          throw new Error('Elements in array should be all numbers!');
      } 

      sum += Number(currEl);      
  }

  // numArray.forEach(function (element) {
      
  //     if (isNaN(element)) {
  //         throw new Error('Elements in array should be all numbers!');
  //     }

  //     sum += Number(element);
  // });

  return sum;
}

// console.log(sum());
// console.log(sum([]));
// console.log(sum([1, 'john', 3]));
//console.log(sum([1, 2, 3]));
// console.log(sum([1, '2', 3]));
// console.log(sum([1, '2.23', 3]));
// console.log(sum([1.77, '2.23', 3]));

module.exports = sum;