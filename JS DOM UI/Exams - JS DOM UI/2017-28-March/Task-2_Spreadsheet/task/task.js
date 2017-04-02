function solve() {

	return function(selector, rows, columns) {
		var $root = $(selector);

		var $table = $('<table />')
			.addClass('spreadsheet-table')
			.appendTo($root);

		var $row = $('<tr />');
		var $col = $('<td />')
			.addClass('spreadsheet-cell spreadsheet-item');
		var $colH = $('<th />')
			.addClass('spreadsheet-header spreadsheet-item');
		
		var $span = $('<span />').appendTo($col);
		var $inputField = $('<input />').appendTo($col);

		// filling the table with rows/cols
		for(var row = 0; row < rows + 1; row += 1){
			var $currRow = $row
				.clone(true)
				.appendTo($table);
			var letterCode = 65;

			for(var col = 0; col < columns + 1; col += 1){
				var $currColH = $colH.clone(true);
				var $currCol = $col.clone(true);				

				if(row == 0 && col != 0){
					$currColH.text(String.fromCharCode(letterCode)).appendTo($currRow);
					letterCode += 1;					
				} else if(col == 0 && row != 0){
					$currColH.text(row).appendTo($currRow);
				} else if(row == 0 && col == 0) {
					$currColH.appendTo($currRow);
				} else {
					$currCol.appendTo($currRow);
				}
			}
		}
	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if(typeof module !== 'undefined') {
	module.exports = solve;
}
