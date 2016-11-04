using System;
using System.Text;

class SeriesOfLetters
{
    static void Main()
    {
        string input =  Console.ReadLine();

        StringBuilder result = new StringBuilder();
        result.Append(input[0]);

        for (int i = 1; i < input.Length; i++)
        {
            char currSymbol = input[i];

            if (currSymbol == input[i - 1])
            {
                continue;
            }
            else
            {
                result.Append(currSymbol);
            }
        }
        Console.WriteLine(result);      
   }   
}

/*
Description

Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.

Input

On the only input line you will receive a string
Output

Print the string without consecutive identical letters
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                    Output
aaaaabbbbbcdddeeeedssaa	    abcdedsa
*/

