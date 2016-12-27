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

| parseInt(str) |
|:-------------:|
| 1234          |
| 1238          |
| 0             |
| 3             |
| NaN           |
| 10^20         |

| parseFloat(str) |
|:---------------:|
| 1234            |
| 1238            |
| 0.15            |
| 3.14            |
| Infinity        |
| 10^20           |

| Number(str) |
|:-----------:|
| 1234        |
| NaN         |
| 0.15        |
| NaN         |
| Infinity    |
| 10^20       |

| +str     |
|:--------:|
| 1234     |
| NaN      |
| 0.15     |
| NaN      |
| Infinity |
| 10^20    |

| str | 0    |
|:----------:|
| 1234       |
| 0          |
| 0          |
| 0          |
| 0          |
| 1661992960 |