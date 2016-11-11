<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 / C# Fundamentals Exam - 10 November 2016_
# Task 2: Jump, Jump

## Description
You're at a hiphop party in [Schmedeswurtherwesterdeich](https://de.wikipedia.org/wiki/Schmedeswurth) in Germany, 
you're probably very drunk(hopefully you passed your C# Fundamentals exam at least) and [DJ Tomekk](https://en.wikipedia.org/wiki/DJ_Tomekk) is on the scene. 
Since DJ Tomekk is in the house, your task is to **[Jump, jump!](https://www.youtube.com/watch?v=kI6dGJt-fNg)**. 
Unfortunately, since you've never been at a German hiphop party with DJ Tomekk in the town of Schmedeswurtherwesterdeich, you'll probably need to learn how to **jump**. Fortunately, you know a bit of programming,
so you can follow the instructions from a single string value.

### The instructions
As mentioned above, the instructions are a single string. The instructions can contain digits(0-9) and the party symbol **'^'**.
- You will start jumping from the first symbol of the instructions(at position 0).
- If you jump on an **even** digit, do the following:
    - Take it's value **P** as a number('2' is 2, '4' is 4 and so on)
    - Jump **P** positions forward
- If you jump on an **odd** digit
    - Take it's value **P** as a number('1' is 1, '3' is 3 and so on)
    - Jump **P** positions backwards
- If you jump on a **'0'**(zero), you pass out because you've drank too much alchohol
    - Print `Too drunk to go on after POSITION!`, where **POSITION** is the index at which you jumped on the **'0'**
    - Stop jumping
- If you jump on **'^'**(party symbol), you did some good jumping
    - Print `Jump, Jump, DJ Tomekk kommt at POSITION!`, where **POSITION** is the index at which you jumped on the party symbol **'^'**
    - Stop jumping
- If you jump outside the boundaries of the instructions, you fall off the dancefloor
    - Print `Fell off the dancefloor at POSITION!`, where **POSITION** is the index at which you jumped you're out of the instructions
    - Stop jumping

## Input
- The input will consist of a single line - the instructions how to jump.

## Output
- Your output should always be a single line. The content of that line is described in the section **The instructions** above.

## Constraints
- The instructions string will never contain more than 100 symbols.
- The instructions string will always only digits and party symbols **'^'**.
- You will never jump in loops. Two examples of loops:
    - `211` - **2** -> **1** -> **1** -> **2** -> **1** -> **1** -> **2** ... and so on forever
    - `212^3^` - **2** -> **2** -> **3** -> **1** -> **2** -> ... and so forever

## Sample tests
| Input         | Output                                   |
|:--------------|:-----------------------------------------|
| 44^632^283    | Jump, Jump, DJ Tomekk kommt at 6!        |
| 8^1231111     | Jump, Jump, DJ Tomekk kommt at 1!        |
| 2^1           | Jump, Jump, DJ Tomekk kommt at 1!        |
| 4^^02734      | Too drunk to go on after 3!              |
| 201           | Too drunk to go on after 1!              |
| 4444444444451 | Fell off the dancefloor at 14!           |
| 203           | Fell off the dancefloor at -1!           |
