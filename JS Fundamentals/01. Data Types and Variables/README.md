# JavaScript literals

## Description
Assign all the possible JavaScript literals to different variables.

# Quoted text

## Description
Create a string variable with quoted text in it.
For example: `'How you doin'?', Joey said'.`

# Typeof variables

## Description
Try typeof on all variables you created.

# Typeof null

## Description
Create null, undefined variables and try typeof on them.

# Parsing numbers

## Description
Try parsing the following strings to numbers using `parseInt`, `parseFloat`, `Number`, `+` and `| 0`. Fill the answers for yourself in the table below.

| str                    |
|:----------------------:|
| '1234'                 |
| '1238abc'              |
| '0.15'                 |
| '3.14ivan'             |
| 'Infinity'             |
| '99999999999999999999' |

| parseInt(str) | parseFloat(str) | Number(str) | +str     | str OR 0   |
|:-------------:|:---------------:|:-----------:|:--------:|:----------:|
| 1234          | 1234            | 1234        | 1234     | 1234       |
| 1238          | 1238            | NaN         | NaN      | 0          |
| 0             | 0.15            | 0.15        | 0.15     | 0          |
| 3             | 3.14            | NaN         | NaN      | 0          |
| NaN           | Infinity        | Infinity    | Infinity | 0          |
| 10^20         | 10^20           | 10^20       | 10^20    | 1661992960 |
