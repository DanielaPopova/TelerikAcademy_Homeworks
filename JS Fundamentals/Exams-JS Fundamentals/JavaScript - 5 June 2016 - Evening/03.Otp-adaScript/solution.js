//bgcoder - 60/100 - solution for fillValues
/*jshint esversion: 6 */
function solve(argument) {
    let input = removeEmptySpaces(argument),
        enums = [],
        sharedEnums = [],
        enumName,
        sharedEnumName,
        inEnum = false,
        inSharedEnum = false,
        matchEnums = /[a-zA-Z0-9]+/g;

    for (let i = 0, len = input.length; i < len; i += 1) {
        let currString = input[i].trim();           

        if (currString[0] === '<' && matchEnums.test(currString[1])) {
            enumName = extractEnumName(1, currString);
           
            inEnum = true;
            inSharedEnum = false;
            continue;
        }

        if (currString[0] === '<' && currString[1] === '@') {
            sharedEnumName = extractEnumName(2, currString);
            
            inSharedEnum = true;
            inEnum = false;
            continue;
        }

        if (currString[0] === '<' && currString[1] === '/') {
            continue;
        }

        let indexOfEqual = currString.indexOf('='),
            indexOfSemicolon = currString.indexOf(';'),
            constName = '',
            value = '';

        if (inEnum) {

            if (indexOfEqual !== -1) {
                constName = extractConstant(currString, indexOfEqual);              
                value = +currString.substring(indexOfEqual + 1, indexOfSemicolon);
            } else {
                constName = extractConstant(currString, indexOfSemicolon);                
            }

            enums.push({
                enumeration: enumName,
                name: constName,
                value: value
            });            
        }

        if (inSharedEnum) {

            if (indexOfEqual !== -1) {
                constName = extractConstant(currString, indexOfEqual);              
                value = +currString.substring(indexOfEqual + 1, indexOfSemicolon);
            } else {
                constName = extractConstant(currString, indexOfSemicolon);                
            }
                
            sharedEnums.push({
                enumeration: sharedEnumName,
                name: constName,
                value: value
            });
        }
    }

    let allValuesInEnums = extractValues(enums),
        allValuesInSharedEnums = extractValues(sharedEnums);    

    enums = fillValues(enums, allValuesInEnums);
    sharedEnums = fillValuesShared(sharedEnums, allValuesInSharedEnums);
    
    let allEnums = enums.concat(sharedEnums).map(function(x) {
        return `${x.name} = ${x.value} :: ${x.enumeration};`;
    }).sort();

    console.log(allEnums.join('\n'));

    function removeEmptySpaces(array) {
        let arrayWithoutEmptySpaces = [];

        for (let i = 0, len = array.length; i < len; i += 1) {
            let currString = array[i];
            let withoutSpaces = currString.replace(/\s+/g, '');
            arrayWithoutEmptySpaces.push(withoutSpaces);
        }

        return arrayWithoutEmptySpaces;
    }

    function extractEnumName(index, string) {

        let enumName = string.substring(index, string.length - 1);
        return enumName;
    }

    function extractConstant(string, indexOfSign) {

        let constName = string.substring(0, indexOfSign);
        return constName;
    }

    function extractValues(arrayOfObjects) {

        let allValues = [];

        for (let obj in arrayOfObjects) {
            if (arrayOfObjects[obj].value !== '') {
                allValues.push(arrayOfObjects[obj].value);
            }
        }

        return allValues;
    }

    // to be continued...
    function fillValues(arrayOfObjects, values) {
        let number = 0;

        for (let i = 0, len = arrayOfObjects.length; i < len; i += 1) {
            let currObj = arrayOfObjects[i];

            if (currObj.value === '') {

                while (values.includes(number)) {
                    number += 1;
                }

                currObj.value = number;
                number += 1;
            }
        }

        return arrayOfObjects;
    }

    function fillValuesShared(arrayOfObjects, values) {
        let number = 0;

        for (let i = 0, len = arrayOfObjects.length; i < len; i += 1) {
            let currObj = arrayOfObjects[i];

            if (currObj.value === '') {

                while (values.includes(number)) {
                    number += 1;
                }

                currObj.value = number;
                number += 1;
            }
        }

        return arrayOfObjects;
    }
}

solve(['<Fruit>',
       '  Apple;',
       '  Banana;',
       '  Pineapple;',
       '</>',
       '<Vegetable>',
       '  Cucumber = 1;',
       '  Cabage;',
       '</>']);

solve(['<@Languages>',
       '   CSharp;',
       '   JavaScript;',
       '   Haskell = 42;',
       '   Rust = 4;',
       '   CPP;',
       '</>',
       '<Result>',
       '   Failed;',
       '   Passed;',
       '   Excellence;',
       '</>',
       '<@Insects>',
       '   Ant;',
       '   Mosquito = 2;',
       '</>']);