function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };
		
        var now = new Date();
        var dateNow = now.getDate() + ' ' + now.getMonthName() + ' ' + now.getFullYear();
        var monthNow = now.getMonthName() + ' ' + now.getFullYear();

        // Creating elements of the picker
        var $wrapper = $('<div/>').addClass('datepicker-wrapper').appendTo('div');        
        var $inputField = $('#date').appendTo($wrapper);

        var $picker = $('<div/>')
            .addClass('picker')
            .appendTo($wrapper);
        var $controls = $('<div/>')
            .addClass('controls')
            .appendTo($picker);
        var $controlButtonLeft = $('<button/>')
            .addClass('btn')
            .text('<')
            .appendTo($controls);
        var $currentMonth = $('<div/>')
            .addClass('current-month')
            .text(monthNow)
            .appendTo($controls);
        var $controlButtonRight = $('<button/>')
            .addClass('btn')
            .text('>')
            .appendTo($controls);
        var $calendar = $('<table>/')
            .addClass('calendar')
            .appendTo($picker);        
        var $currentDate = $('<div/>')
            .addClass('current-date')
            .appendTo($picker);
        var $currentDateLink = $('<a href="#" />')
            .addClass('current-date-link')
            .text(dateNow)
            .appendTo($currentDate);
		
        $inputField.on('click', function(){
            $picker.addClass('picker-visible');
        });

        $currentDate.on('click', '.current-date-link', function(){
            $inputField.val($currentDateLink.text());
        })

        return this;
    };
};
