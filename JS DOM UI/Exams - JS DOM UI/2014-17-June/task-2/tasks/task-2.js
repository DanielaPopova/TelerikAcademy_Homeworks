function solve() {
  return function () {
    /* globals $ */
    $.fn.gallery = function (columnCount) {		
		columnCount = columnCount || 4;

		var $this = this.addClass('gallery');    

		var $selected = $this.children('.selected').hide();
		var $galleryList = $this.children('.gallery-list');
		var $imageContainers = $galleryList
			.children('.image-container')
			.each(function (index, element) {
				if (index % columnCount == 0) {
					$(element).addClass('clearfix');
				}
			})
		
		$galleryList.on('click', 'img', function(){
			$selected.show();
		});
		return $this;
    };
	
  };
}

module.exports = solve;