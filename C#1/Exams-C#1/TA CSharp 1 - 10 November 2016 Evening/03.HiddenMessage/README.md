<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 / C# Fundamentals Exam - 10 November 2016_
# Task 3: Hidden Message

## Description
**Tzacky** has a great idea to hide messages in subtitles of movies. But his friend, just started to code and has difficulty decoding the messages. He knows that to do so, he needs to take the numbers that come before each subtitle and use them to decode the message. The first number **I** is the index of the symbol he should start decoding (**starting from 0**) and the second number **S** is the number of symbols he needs to skip to get every other symbol. If the starting index is larger than the length of the line, this means that the line should be skipped.
- example:

  | input               | result | explanation               |
  |---------------------|--------|---------------------------|
  | 4<br/>4<br/>add carbon additive<br/>end | codi<br/><br/><br/><br/> | add **c**arb**o**n a**d**dit**i**ve<br/>start from **c** (4th symbol counting from 0), then take every 4th -> **o**, **d** and **i**<br/><br/> |

To make things easy, when the subtitles finish **Tzacky** always adds **end** instead of the starting index **I** (see sample tests).

Sometimes **Tzacky** wants to be extra sure his message will be hidden, so he decided to add additional complexity.
- If **S** is negative your program should look for the next symbol to the left of the starting index (go backwards).
- If **I** is negative your program should take the symbol counting from the end of the line as starting index
  - example 1: for **I = -1**
    - line of code: "some random text that makes no senc**e**"
  - example 2: for **I = -6**
    - line of code: "some random text that makes no**_**sence" (the space)

## Input
- On the first line you can read the index of the first symbol `i`, if instead of a number you read `end` your program should print the hidden message so far and stop.
- On the second line you will get a number, that is the number of symbols to skip to reach the next symbol for the hidden message.
- On the third line you will get a line of text on witch you have to use the previously read numbers. 

## Output
- The output should consist of a single line containing the full hidden message.

## Constraints
- The starting symbol index **I** will be a valid integer number between `-100` and `100` inclusive.
- The number of skipped symbols **S** will be a valid integer number between `-100` and `100` inclusive, excluding `0`.
- The length of each line of text will be between `1` and `100` inclusive.
  - The text will contain only Latin letters and the symbols: **,** (comma), **.** (dot), **!** (exclamation mark) and **white space** (space)
  - **[',', '.', '!', ' ']**.
- The input will always be valid and in the described format. There is no need to check it explicitly.
- Memory limit: **32 MB**
- Time limit: **0.10 sec**

## Sample tests

| **input**                                                                    | **output**        |
|:-----------------------------------------------------------------------------|:------------------|
| 28<br/>4<br/>To molten steel you can add carbon additive.<br/>100<br/>1<br/>Carbon additive includes calcined petroleum coke, graphite petroleum coke,<br/>0<br/>8<br/>natural graphite etc.<br/>21<br/>4<br/>For the steel-making industry the<br/>3<br/>50<br/>sulfur in calcined petroleum coke<br/>7<br/>11<br/>is a crucial element<br/>end | coding is fun<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/> |

Explanation:<br/>
To molten steel you can add **c**arb**o**n a**d**dit**i**ve.<br/>
Carbon additive includes calcined petroleum coke, graphite petroleum coke,<br/>
**n**atural **g**raphite**_**etc.<br/>
For the steel-making **i**ndu**s**try**_**the<br/>
sul**f**ur in calcined petroleum coke<br/>
is a cr**u**cial eleme**n**t<br/>

| **input**                              | **output** |
|:---------------------------------------|:-----------|
| 0<br/>1<br/>oh no!<br/>end<br/>1<br/>some other text that should be ignored | oh no!<br/><br/><br/><br/><br/><br/> |

| **input**            | **output**        |  
|:---------------------|:------------------|
| -4<br/>1<br/>What is this<br/>4<br/>-1<br/>saw something!<br/>-4<br/>-1<br/>ysae tog<br/>end | thiss was easy<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/> | 
