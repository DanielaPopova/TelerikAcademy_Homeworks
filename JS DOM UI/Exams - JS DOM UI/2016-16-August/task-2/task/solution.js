function solve() {
    return function (fileContentsByName) {
        var $fileExplorer = $('.file-explorer'),
            $input = $('input');        
        
        $fileExplorer.on('click', function(ev){
            var $target = $(ev.target); //anchor element
            
            if($target.hasClass('item-name')){
                $('.file-content').text(fileContentsByName[$target.html()]);
            }

            if($target.parent().hasClass('dir-item')){
                $target.parent().toggleClass('collapsed');
            }

            if($target.hasClass('del-btn')){
                $target.parent().remove();
            }

            if($target.hasClass('add-btn')){
                $target.removeClass('visible');
                $input.addClass('visible').focus();
            }
        });

        $input.on('keydown', function(ev){
            if(ev.keyCode == 13) {                
                var inputText = $(this).val();
                var slashIndex = inputText.indexOf('/');               
                var $allFoldersNames = $('.dir-item').children('.item-name');
                     
                if(slashIndex !== -1){
                    var dirName = inputText.substring(0, slashIndex);
                    var fileName = inputText.substring((slashIndex + 1), (inputText.length));
                     
                    for (var i = 0, len = $allFoldersNames.length; i < len; i += 1) {
                        var $currAnchor = $($allFoldersNames[i]);
                        var $currName = $currAnchor.html();
                        
                        if ($currName == dirName) {
                            var $list = $currAnchor.next();

                            var $newLi = $('<li/>').addClass('file-item item');
                            $('<a/>').addClass('item-name').html(fileName).appendTo($newLi);
                            $('<a/>').addClass('del-btn').appendTo($newLi);

                            fileContentsByName[fileName] = '';
                            $newLi.appendTo($list);
                        }
                    }
                } else {
                    var $rootDirectory = $fileExplorer.find('.items').first();
                    var $newLi = $('<li/>').addClass('file-item item');
                    $('<a/>').addClass('item-name').html(inputText).appendTo($newLi);
                    $('<a/>').addClass('del-btn').appendTo($newLi);

                    fileContentsByName[inputText] = '';
                    $newLi.appendTo($rootDirectory);
                }

                $input.removeClass('visible');
                $('.add-btn').addClass('visible');
                $input.val('');
            } 
        });
    }
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}