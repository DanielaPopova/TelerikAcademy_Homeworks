<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png" />

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 07 Dec 2016_

# Task 2: Cards

## Description
You partied way too hard last night and now you wake up in a dimly lit room in Drujbai. You're wearing a suit and a tie and have a glass of whiskey in front of you. 
All around you there are all sorts of **usual suspects** - mutri, futbolisti, kleknali slavyani, kradci, mafioti and their beautiful wives. 
They like to play **Kent Kupe** and **Poker**. They want you to deal cards for them, but first they want to see how good you are with cards, so they gave you a small task. 
They also want to see how **fast** you will manage the task. 
If you fail it - you're in the bop. So don't. Fortunately, they don't know that you know how to write a program that knows what to do with the cards.

## The test
You will be given **N** hands of cards, which will contain distinct cards, but not more than 52 cards in each hand. 
You task is to take all hands and determine whether you can build at least a single full deck of 52 cards using cards from the hands you're given.
Additionally, since the **usual suspects** need to see if you keep track of the cards, you will need to print which cards occur an **odd** number of times in all **N** hands.

## Cards and hands
Each hand will be given to you as an **64-bit integer**(signed or unsigned makes no difference, only the bits are important). The set bits(i.e. 1's) in such a number represent which cards are present. 
The positions of the bits are **counted from right to left**. If a bit at position **K** is set, then the card at position **K** is present in the hand.

- The card signs are marked as letters (for output convenience)

| clubs ♣ | diamonds ♦ | hearts ♥ | spades ♠ |
|:-------:|:----------:|:--------:|:--------:|
| c       | d          | h        | s        |

- The cards in the deck are positioned as following:

| 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  | 8  | 9  | 10 | 11 | 12 |
|----|----|----|----|----|----|----|----|----|----|----|----|----|
| 2c | 3c | 4c | 5c | 6c | 7c | 8c | 9c | Tc | Jc | Qc | Kc | Ac |

| 13 | 14 | 15 | 16 | 17 | 18 | 19 | 20 | 21 | 22 | 23 | 24 | 25 |
|----|----|----|----|----|----|----|----|----|----|----|----|----|
| 2d | 3d | 4d | 5d | 6d | 7d | 8d | 9d | Td | Jd | Qd | Kd | Ad |

| 26 | 27 | 28 | 29 | 30 | 31 | 32 | 33 | 34 | 35 | 36 | 37 | 38 |
|----|----|----|----|----|----|----|----|----|----|----|----|----|
| 2h | 3h | 4h | 5h | 6h | 7h | 8h | 9h | Th | Jh | Qh | Kh | Ah |

| 39 | 40 | 41 | 42 | 43 | 44 | 45 | 46 | 47 | 48 | 49 | 50 | 51 |
|----|----|----|----|----|----|----|----|----|----|----|----|----|
| 2s | 3s | 4s | 5s | 6s | 7s | 8s | 9s | Ts | Js | Qs | Ks | As |

## Input
- On the first line, you will receive an integer number **N** - the number of hands.
- On each of the next **N** lines, you will receive an unsigned 64-bit integer value - the current hand.

## Output
- The output consists of **2** lines .
    - If you can form at least one whole deck of 52 cards from the hands, print "Full deck" on the first line. Otherwise, print "Wa wa!".
    - On the second line, print all cards that occurred an odd number of times, in ascending order, separated by a whitespace " ". Look at the examples to get a better idea of how the output should look like.

## Constraints
- **The input will always be in the described format - there is no need to verify it explicitly in your program.**
- Time limit: **0.10 sec**
- Memory limit: **24.00 MB**
- **N** will always be in the range of [2..100000]
- in 70% of the tests **N** will be below **50**

## Example
- Consider the input:

| Input                                  | Hands in binary                                                                                                       |
|:-------------------------------------- | ---------------------------------------------------------------------------------------------------------------------:|
| 3<br>4503599560261632<br>67108863<br>1 | <br>1111111111111111111111111100000000000000000000000000<br>0000000000000000000000000011111111111111111111111111<br>1 |

- **3** means you'll get 3 hands as input.
- The first hand contains the cards from **2h** to **As**, inclusive.
- The second hand contains the cards from **2c** to **Ad**, inclusive.
- The third hand contains only **2c**.
- Combining the three hands forms a full deck in which every card occurs exactly once, except for **2c**, which occurs twice - once in the second hand and once in the third.

## Hint
- Bitwise card dealers are the quickest ;)

## Sample tests
| Input                                                                             | Output                                                                                                                                                                |
|:--------------------------------------------------------------------------------- |:--------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 3<br>4503599560261632<br>67108863<br>1                                            | Full deck<br>3c 4c 5c 6c 7c 8c 9c Tc Jc Qc Kc Ac 2d 3d 4d 5d 6d 7d 8d 9d Td Jd Qd Kd Ad 2h 3h 4h 5h 6h 7h 8h 9h Th Jh Qh Kh Ah 2s 3s 4s 5s 6s 7s 8s 9s Ts Js Qs Ks As |
| 5<br>8796093284353<br>274878169096<br>1168365322240<br>8650760<br>285873023221888 | Wa wa!<br>2c 9c 7d Qd 3h Qh Ah 3s 5s 6s Js                                                                                                                            |
| 3<br>17607757447185<br>2287053528105506<br>291989056920832                        | Wa wa!<br>2c 3c 6c 7c Tc Jc Qc Kc Ac 3d 4d 7d Kd 2h 7h 8h 9h 2s 3s 6s 7s 8s Js As                                                                                     |
| 3<br>272661674162173<br>2814457708837951<br>4204527946760119                      | Full deck<br>2c 4c 6c 7c 8c Qc Ac 2d 3d 4d 5d 7d 9d Td Jd Kd Ad 4h 5h 6h 7h 9h Th Jh Qh Kh 2s 3s 4s 5s 8s 9s Ts Js Qs Ks                                              |