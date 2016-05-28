using System;
using System.Globalization;
using System.Text;
using System.Threading;

class UnicodeCharacters
{
    static void Main()
    {
        //Console.OutputEncoding = Encoding.Unicode;
       Console.InputEncoding = Encoding.Unicode;   //to read cyrillic, but bgcoder doesn't like it
      
        string input = Console.ReadLine();
        //input = input.Replace(@"\", String.Empty);     //doesn't make difference
        //byte[] bytes = Encoding.Unicode.GetBytes(input);
        //input = Encoding.Unicode.GetString(Encoding.Convert(Encoding.UTF8, Encoding.Unicode, bytes));
        //Console.WriteLine(input);

        for (int i = 0; i < input.Length; i++)
        {
            char symbol = input[i];
            Console.Write("\\u{0:X4}", (ushort)symbol);
        }
    }
}

/*
Description

Write a program that converts a string to a sequence of C# Unicode character literals.

Input

On the only input line you will receive a string
Output

Print the string in C# Unicode character literals on a single line
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
Hi!	        \u0048\u0069\u0021
*/

