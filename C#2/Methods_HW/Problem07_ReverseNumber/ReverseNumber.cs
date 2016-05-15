using System;
using System.Text;

class ReverseNumber
{
    static void Main()
    {
        string number = Console.ReadLine();
        StringBuilder revNum = ReverseDecimalNumber(number);
        Console.WriteLine(revNum);
    }

    static StringBuilder ReverseDecimalNumber(string number) 
    {
        StringBuilder reversedNum = new StringBuilder();
        for (int i = number.Length - 1; i >= 0; i--)
        {
            char lastDigit = number[i];            
            reversedNum.Append(lastDigit);
        }

        return reversedNum;
    }
}

/*
Reverse number
Description

Write a method that reverses the digits of a given decimal number.

Input

On the first line you will receive a number
Output

Print the given number with reversed digits
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
256	        652
123.45	    54.321
*/

