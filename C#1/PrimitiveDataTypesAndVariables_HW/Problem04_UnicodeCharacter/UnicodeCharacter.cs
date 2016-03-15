/*
Declare a character variable and assign it with the symbol that has Unicode code 42 (decimal) using the \u00XX syntax, and then print it.
Hint: first, use the Windows Calculator to find the hexadecimal representation of 42. The output should be *.
*/

using System;

class UnicodeCharacter
{
    static void Main()
    {
        //Using Windows Calculator
        char symbol = '\u002A';
        Console.WriteLine(symbol);

        //Alternative solution
        int unicode = 42;
        char symb = Convert.ToChar(unicode);
        Console.WriteLine(symb);
    }
}

