/*
Write a program that enters 3 real numbers and prints them sorted in descending order.
Use nested if statements.
Note: Don’t use arrays and the built-in sorting functionality.

Examples:

a	    b	    c	    result
5	    1	    2	    5 2 1
-2	    -2	    1	    1 -2 -2
-2	    4	    3	    4 3 -2
0	    -2.5	5	    5 0 -2.5
-1.1	-0.5	-0.1	-0.1 -0.5 -1.1
10	    20	    30	    30 20 10
1	    1	    1	    1 1 1
*/

using System;

class SortThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter three real numbers each on a separate line");

        double firstNum = double.Parse(Console.ReadLine());
        double secondNum = double.Parse(Console.ReadLine());
        double thirdNum = double.Parse(Console.ReadLine());

        double biggestNum = firstNum;

        if (firstNum >= secondNum && firstNum >= thirdNum)
        {
            if (secondNum >= thirdNum)
            {
                Console.WriteLine("{0} {1} {2}", firstNum, secondNum, thirdNum);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", firstNum, thirdNum, secondNum);
            }
        }
        else if (secondNum >= firstNum && secondNum >= thirdNum)
        {
            if (firstNum >= thirdNum)
            {
                Console.WriteLine("{0} {1} {2}", secondNum, firstNum, thirdNum);
            }
            else
            {
                Console.WriteLine("{0} {1} {2} ", secondNum, thirdNum, firstNum);
            }
        }
        else if (thirdNum >= firstNum && thirdNum >= secondNum)
        {
            if (firstNum >= secondNum)
            {
                Console.WriteLine("{0} {1} {2}", thirdNum, firstNum, secondNum);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", thirdNum, secondNum, firstNum);
            }
        }
    }
}

