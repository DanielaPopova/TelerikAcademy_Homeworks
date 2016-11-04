/*
Write a program that prints an isosceles triangle of 9 copyright symbols ©, something like this:
   ©

  © ©

 ©   ©

© © © ©
Note: The © symbol may be displayed incorrectly at the console so you may need to change the
 console character encoding to UTF-8 and assign a Unicode-friendly font in the console.

Note: Under old versions of Windows the © symbol may still be displayed incorrectly, regardless of how much effort you put to fix it.
*/

using System;
using System.Text;

class IsoscelesTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        char crSymbol = '\u00A9';

        Console.WriteLine("      " + crSymbol);
        Console.WriteLine();
        Console.WriteLine("     " + crSymbol + " " + crSymbol);
        Console.WriteLine();
        Console.WriteLine("    " + crSymbol + "   " + crSymbol);
        Console.WriteLine();
        Console.WriteLine("   " + crSymbol + " " + crSymbol + " " + crSymbol + " " + crSymbol);

        //Another way of printing the triangle 
        Console.WriteLine("\n\n\n");
        Console.WriteLine("{0, 6}\n", crSymbol);
        Console.WriteLine("{0, 5} {0, 1}\n", crSymbol);
        Console.WriteLine("{0, 4} {0, 3}\n", crSymbol);
        Console.WriteLine("{0, 3} {0, 1} {0, 1} {0, 1}", crSymbol);

    }
}

