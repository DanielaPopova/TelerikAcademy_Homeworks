function solve() {
    return function (selector, tabs) {
        var container = document.querySelector(selector);

        var navigation = document.createElement('ul');
            navigation.className = 'tabs-nav';
        var navigationLi = document.createElement('li'); 
        var link = document.createElement('a');
            link.className ='tab-link';
            link.href = '#';

        var content = document.createElement('ul');
            content.className ='tabs-content';        
        var contentLi = document.createElement('li');
            contentLi.className = 'tab-content';        
        var paragraph = document.createElement('p');
        var button = document.createElement('button');
            button.className ='btn-edit';
            button.innerHTML = 'Edit';
        
        for(var i = 0, len = tabs.length; i < len; i += 1){
            var info = tabs[i],
                currNavLi = navigationLi.cloneNode(true),
                currLink = link.cloneNode(true),
                currContentLi = contentLi.cloneNode(true),
                currP = paragraph.cloneNode(true),
                currButton = button.cloneNode(true);

            currLink.innerHTML = info.title;
            currNavLi.setAttribute('data-index', i);
            currNavLi.appendChild(currLink);
            navigation.appendChild(currNavLi);

            currP.innerHTML = info.content;
            if(i == 0){
                currContentLi.className += ' visible';
            }
            currContentLi.setAttribute('data-index', i);
            currContentLi.appendChild(currP);
            currContentLi.appendChild(currButton);
            content.appendChild(currContentLi);
        }

        container.appendChild(navigation);
        container.appendChild(content);
         
        navigation.addEventListener('click', function(ev){
            var target = ev.target;
           
            if(target.tagName === 'A'){                
                var allLis = content.getElementsByClassName('tab-content');            
                                
                Array.from(allLis).forEach(function(li){
                    if(+target.parentElement.getAttribute('data-index') == +li.getAttribute('data-index')){                        
                        li.className = 'tab-content visible';
                    } else {
                        li.className = 'tab-content';
                    }
                });        
            }
        });
        
        var textarea = document.createElement('textarea');
        
        content.addEventListener('click', function(ev){
            var target = ev.target;
            if(target.tagName == 'BUTTON'){

                if(target.innerHTML === 'Edit'){
                    target.innerHTML = 'Save';
                    textarea.className = 'edit-content';
                    textarea.value = target.previousSibling.innerHTML;

                    target.parentElement.appendChild(textarea);
                } else if(target.innerHTML === 'Save'){
                    target.previousSibling.innerHTML = textarea.value;
                    console.log(target.previousSibling);
                    target.parentElement.removeChild(textarea);
                    target.innerHTML = 'Edit';                    
                }                
            }
        });
    }
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}