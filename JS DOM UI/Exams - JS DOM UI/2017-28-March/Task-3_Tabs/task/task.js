function solve() {

	var template = [
            '<div class="tabs-control">',
            '<ul class="list list-titles">',
                '{{#each titles}}',
                    '<li class="list-item">',
                        '<label for="{{link}}" class="title">{{text}}</label>',
                    '</li>',                
                '{{/each}}',
            '</ul>',
            '<ul class="list list-contents">',
                '{{#each contents}}',
                    '<li class="list-item">',
                        '<input class="tab-content-toggle" id="{{link}}" name="tab-toggles" checked="checked/" type="radio">',
                        '<div class="content">',
                            '{{{text}}}',
                        '</div>',
                    '</li>',
                '{{/each}}',                
            '</ul>',
        '</div>'
        ].join('\n');

	return template;
}

if(typeof module !== 'undefined') {
	module.exports = solve;
}
