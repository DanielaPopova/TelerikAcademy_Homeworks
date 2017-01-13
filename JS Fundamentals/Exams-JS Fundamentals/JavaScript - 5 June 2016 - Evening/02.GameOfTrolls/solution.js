/*jshint esversion: 6 */
function solve(argument) {
    let fieldSize = argument.shift().split(' ').map(Number),
        rows = fieldSize[0],
        cols = fieldSize[1];

    let startCoordinates = argument.shift().split(';'),
        trollWposition = getPositions(startCoordinates[0]),
        trollNposition = getPositions(startCoordinates[1]),
        princessPosition = getPositions(startCoordinates[2]);

    let commands = argument.slice(0);

    let field = fillField(rows, cols);

    let isTrappedW = false,
        isTrappedN = false,
        hasEscaped = false;

    for (let i = 0; i < commands.length; i += 1) {

        let currCommands = commands[i].split(' ');

        if (currCommands[0] === 'mv') {

            switch (currCommands[1]) {

                case 'Wboup':
                    if (!isTrappedW) {
                        trollWposition = moveToPosition(trollWposition, currCommands[2]);
                    }
                    break;
                case 'Nbslbub':
                    if (!isTrappedN) {
                        trollNposition = moveToPosition(trollNposition, currCommands[2]);
                    }
                    break;
                case 'Lsjtujzbo':
                    princessPosition = moveToPosition(princessPosition, currCommands[2]);
                    break;
            }

            //trapping the trolls 
            if (field[trollWposition.R][trollWposition.C] === -1) {
                isTrappedW = true;
            }

            if (field[trollNposition.R][trollNposition.C] === -1) {
                isTrappedN = true;
            }

            //saving trolls from trap
            if (isTrappedW && trollNposition.R === trollWposition.R && trollNposition.C === trollWposition.C) {
                isTrappedW = false;
                field[trollNposition.R][trollNposition.C] = 0;
            }

            if (isTrappedN && trollWposition.R === trollNposition.R && trollWposition.C === trollNposition.C) {
                isTrappedN = false;
                field[trollWposition.R][trollWposition.C] = 0;
            }

            //if both trolls are trapped and no troll is around
            if (!isPrincessCaught() && (isTrappedW && isTrappedN)) {
                hasEscaped = true;
                break;
            }
            
            // princess reaches bottom right corner of the field
            if (princessPosition.R === rows - 1 && princessPosition.C === cols - 1) {
                hasEscaped = true;
                break;
            }

            // standing on the same cell/cell around- princess is caught!
            if (isPrincessCaught()) {
                hasEscaped = false;
                break;
            }

        } else if (currCommands[0] === 'lay') {
            field[princessPosition.R][princessPosition.C] = -1;
        }
    }

    if (hasEscaped) {
        console.log(`Lsjtujzbo is saved! ${trollWposition.R} ${trollWposition.C} ${trollNposition.R} ${trollNposition.C}`);
    } else {
        console.log(`The trolls caught Lsjtujzbo at ${princessPosition.R} ${princessPosition.C}`);
    }
    
    function fillField() {
        let field = [];
        for (let row = 0; row < rows; row += 1) {
            field[row] = [];
            for (let col = 0; col < cols; col += 1) {
                field[row][col] = 0;
            }
        }

        return field;
    }

    function getPositions(pair) {
        let coords = pair.split(' ').map(Number);

        return {
            R: coords[0],
            C: coords[1]
        };
    }

    function moveToPosition(unitCurrPosition, direction) {

        switch (direction) {
            case 'd':
                unitCurrPosition.R += 1;
                break;
            case 'u':
                unitCurrPosition.R -= 1;
                break;
            case 'l':
                unitCurrPosition.C -= 1;
                break;
            case 'r':
                unitCurrPosition.C += 1;
                break;
        }

        if (unitCurrPosition.R > rows - 1) {
            unitCurrPosition.R = rows - 1;
        }

        if (unitCurrPosition.R < 0) {
            unitCurrPosition.R = 0;
        }

        if (unitCurrPosition.C > cols - 1) {
            unitCurrPosition.C = cols - 1;
        }

        if (unitCurrPosition.C < 0) {
            unitCurrPosition.C = 0;
        }

        return {
            R: unitCurrPosition.R,
            C: unitCurrPosition.C
        };
    }

    function isPrincessCaught() {

        if (trollWposition.R === princessPosition.R && trollWposition.C === princessPosition.C ||
            trollNposition.R === princessPosition.R && trollNposition.C === princessPosition.C) {
            return true;
        }

        if (Math.abs(trollWposition.R - princessPosition.R) <= 1 && Math.abs(trollWposition.C - princessPosition.C) <= 1 ||
            Math.abs(trollNposition.R - princessPosition.R) <= 1 && Math.abs(trollNposition.C - princessPosition.C) <= 1) {
            return true;
        }

        return false;
    }
}

solve(['5 5',
       '1 1;0 1;2 3',
       'mv Lsjtujzbo d',
       'lay trap',
       'mv Lsjtujzbo d',
       'mv Wboup r',
       'mv Wboup r',
       'mv Nbslbub d',
       'mv Nbslbub d',
       'mv Nbslbub d',
       'mv Nbslbub d',
       'mv Nbslbub d',
       'mv Wboup d',
       'mv Wboup d']);

solve(['7 7',
       '0 1;0 2;3 3',
       'mv Lsjtujzbo l',
       'lay trap',
       'mv Lsjtujzbo r',
       'lay trap',
       'mv Lsjtujzbo r',
       'lay trap',
       'mv Lsjtujzbo d',
       'mv Lsjtujzbo r',
       'mv Lsjtujzbo r',
       'mv Lsjtujzbo r',
       'mv Lsjtujzbo r',
       'mv Wboup d',
       'mv Wboup d',
       'mv Wboup l',
       'mv Wboup l',
       'mv Nbslbub r',
       'mv Nbslbub r',
       'mv Nbslbub r',
       'mv Nbslbub d',
       'mv Lsjtujzbo d',
       'mv Lsjtujzbo l',
       'mv Lsjtujzbo l',
       'mv Nbslbub l',
       'mv Nbslbub d',
       'mv Nbslbub d',
       'mv Wboup d',
       'mv Wboup d',
       'mv Wboup r',
       'mv Lsjtujzbo d',
       'mv Wboup d',
       'mv Wboup d',
       'mv Wboup r',
       'mv Lsjtujzbo r',
       'mv Lsjtujzbo r']);

solve(['8 8',
       '1 3;0 3;5 5',
       'mv Lsjtujzbo l',
       'mv Lsjtujzbo l',
       'lay trap',
       'mv Lsjtujzbo r',
       'lay trap',
       'mv Lsjtujzbo r',
       'lay trap',
       'mv Lsjtujzbo d',
       'lay trap',
       'mv Lsjtujzbo d',
       'lay trap',
       'mv Wboup r',
       'mv Wboup r',
       'mv Wboup d',
       'mv Wboup d',
       'mv Wboup d',
       'mv Wboup d',
       'mv Nbslbub d',
       'mv Nbslbub d',
       'mv Lsjtujzbo l',
       'mv Nbslbub d',
       'mv Nbslbub r',
       'mv Nbslbub r',
       'mv Nbslbub d',
       'mv Nbslbub d',
       'mv Nbslbub d']);

solve(['11 11',
       '10 10;9 9;0 0',
       'mv Lsjtujzbo d',
       'mv Lsjtujzbo d',
       'lay trap',
       'mv Lsjtujzbo r',
       'mv Lsjtujzbo r',
       'lay trap',
       'mv Lsjtujzbo r',
       'lay trap',
       'mv Lsjtujzbo u',
       'lay trap',
       'mv Lsjtujzbo u',
       'lay trap',
       'mv Lsjtujzbo l',
       'mv Lsjtujzbo d',
       'mv Lsjtujzbo l',
       'lay trap',
       'mv Lsjtujzbo u',
       'mv Lsjtujzbo r',
       'mv Nbslbub l',
       'mv Nbslbub l',
       'mv Nbslbub l',
       'mv Nbslbub l',
       'mv Nbslbub l',
       'mv Nbslbub u',
       'mv Nbslbub u',
       'mv Nbslbub u',
       'mv Nbslbub u',
       'mv Nbslbub l',
       'mv Nbslbub l',
       'mv Nbslbub u',
       'mv Nbslbub u',
       'mv Nbslbub u',
       'mv Wboup u',
       'mv Wboup u',
       'mv Wboup u',
       'mv Wboup u',
       'mv Wboup u',
       'mv Wboup u',
       'mv Wboup u',
       'mv Wboup u',
       'mv Wboup u',
       'mv Wboup l',
       'mv Wboup l',
       'mv Wboup l',
       'mv Wboup l',
       'mv Wboup d',
       'mv Wboup l',
       'mv Wboup l',
       'mv Wboup l']);