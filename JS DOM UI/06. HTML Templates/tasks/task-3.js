function solve(){
  return function(){
    $.fn.listview = function(data){
        var template = $("#" + this.attr('data-template')).html(),
            listTemplate = handlebars.compile(template),
            i, 
            len;

        for (i = 0, len = data.length; i < len; i += 1) {
            this.append(listTemplate(data[i]));
        }

        return this;
    };
  };
}

module.exports = solve;