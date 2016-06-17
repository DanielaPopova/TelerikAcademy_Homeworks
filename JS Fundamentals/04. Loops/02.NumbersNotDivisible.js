function printNumNotDivisible(number) {
	var i, 
		count = 1;
	for (i = 0; i < number; i +=1) {
		if (count % 21 !== 0) {
			console.warn(count);
		}
		count += 1;
	}
}

printNumNotDivisible(43);