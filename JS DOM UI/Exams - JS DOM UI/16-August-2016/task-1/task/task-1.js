/* globals document, window, console */
function solve() {
    return function(selector, initialSuggestions) {

        initialSuggestions = initialSuggestions || [];
        var container = document.querySelector(selector);

        var suggestionsUl = document.getElementsByClassName('suggestions-list')[0];        
        suggestionsUl.innerHTML = '';
        
        var suggestionLi = document.createElement('li');
        suggestionLi.className = 'suggestion';
        suggestionLi.style.display = 'none';

        if(initialSuggestions.length !== 0){
            for(var i = 0, len = initialSuggestions.length; i < len; i += 1){
                var suggestion = initialSuggestions[i];

                if(checkIfUnique(suggestion, suggestionsUl)){                    
                    suggestionsUl = addSuggestion(suggestion);                    
                }
            }
        }

        var input = document.getElementsByClassName('tb-pattern')[0];
        input.addEventListener('input', function(ev){            
            var inputValue = ev.target.value;
            var allLinks = suggestionsUl.getElementsByClassName('suggestion-link');
            Array.from(allLinks).forEach(function(a){
                suggestionsUl.style.display = '';

                if(a.innerHTML.toLowerCase().includes(inputValue.toLowerCase())){
                    a.parentElement.style.display = '';
                } else {
                    a.parentElement.style.display = 'none';
                }

                if(!inputValue){
                    a.parentElement.style.display = 'none';
                }
            });            
        });      

        suggestionsUl.addEventListener('click', function(ev){
            var target = ev.target;
            if(target.tagName === 'A'){
                input.value = target.innerHTML;
            }
        }); 

        var button = document.getElementsByClassName('btn-add')[0];
        button.addEventListener('click', function(ev){
            var newSuggestion = ev.target.previousElementSibling.value;
            if(newSuggestion !== ''){
                if(checkIfUnique(newSuggestion, suggestionsUl)){
                    suggestionsUl = addSuggestion(newSuggestion);
                }
            }
            
            ev.target.previousElementSibling.value = '';
            suggestionsUl.style.display = 'none';
        });

        function addSuggestion(text){
            var clonedLi = suggestionLi.cloneNode(true);
            var link = document.createElement('a');
                link.href = '#';
                link.className = 'suggestion-link';
                link.innerHTML = text;

            clonedLi.appendChild(link);
            suggestionsUl.appendChild(clonedLi);

            return suggestionsUl;
        }

        function checkIfUnique(suggestion, ulElement){   
            var allLis = ulElement.getElementsByTagName('li');                  
            for(var i = 0, len = allLis.length; i < len; i += 1){
                var currLi = allLis[i];
                var currSuggesiton = currLi.firstElementChild.innerHTML;
                
                if(suggestion.toLowerCase() === currSuggesiton.toLowerCase()){
                    return false;
                }
            }

            return true;
        }        
    };
}

module.exports = solve;