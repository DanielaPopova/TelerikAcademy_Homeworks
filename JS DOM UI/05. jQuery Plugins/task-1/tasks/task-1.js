function solve() {
  return function (selector) {

    var $container = $('<div />')
      .addClass('dropdown-list')
      .appendTo('body');

    var $select = $(selector)
      .css('display', 'none')
      .appendTo($container);

    var $options = $select.find('option');

    var $currentDiv = $('<div />')
      .addClass('current')
      .attr('data-value', '')
      .text($($options[0]).text())
      .appendTo($container);

    var $optionsContainerDiv = $('<div />')
      .addClass('options-container')
      .css({
        'position': 'absolute',
        'display': 'none'
      })
      .appendTo($container);

    $currentDiv.on('click', function () {
      var $content = $('.options-container')
        .css('display', 'inline-block');      
    });

    $optionsContainerDiv.on('click', function (ev) {
      var $clicked = $(ev.target);
      var $divToDisplay = $('.current');
      
      $divToDisplay.text($clicked.text());
      $select.val($clicked.attr('data-value'));

      var $container = $(this).hide();
    });

    for (var i = 0; i < $options.length; i += 1) {
      var $div = $('<div />')
        .addClass('dropdown-item')
        .attr('data-value', $($options[i]).val())
        .attr('data-index', i)
        .text($($options[i]).text())
        .appendTo($optionsContainerDiv);
    }
  };
}

module.exports = solve;

