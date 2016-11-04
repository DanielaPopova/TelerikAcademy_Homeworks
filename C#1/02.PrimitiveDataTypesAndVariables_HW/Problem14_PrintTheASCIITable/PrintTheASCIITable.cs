/*
Find online more information about ASCII (American Standard Code for Information Interchange) 
and write a program that prints the entire ASCII table of characters on the console (characters from 0 to 255).
Note: Some characters have a special purpose and will not be displayed as expected. You may skip them or display them differently.

Note: You may need to use for-loops (learn in Internet how).
*/

using System;
using System.Text;

class PrintTheASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        //Using Lucida Console from Console -> Properties -> Font

        for (int i = 0; i < 256; i++)
        {
            char symbol = (char)i;
            if (i >= 0 && i < 33 || i >= 127 && i <=160)
            {
                Console.WriteLine("{0} -> \u263A", i);
            }
            else
            {
                Console.WriteLine("{0} -> {1}", i, symbol);
            }               
        }
    }
}

