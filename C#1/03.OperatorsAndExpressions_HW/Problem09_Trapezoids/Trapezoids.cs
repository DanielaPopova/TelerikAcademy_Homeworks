/*
Write an expression that calculates trapezoid's area by given sides a and b and height h.
Examples:

a	    b	    h	    area
5	    7	    12	    72
2	    1	    33	    49.5
8.5	    4.3	    2.7	    17.28
100	    200	    300	    45000
0.222	0.333	0.555	0.1540125
*/

using System;
using System.Threading;

class Trapezoids
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        
        Console.WriteLine("Enter side a ");
        float a = float.Parse(Console.ReadLine());

        Console.WriteLine("Enter side b");
        float b = float.Parse(Console.ReadLine());

        Console.WriteLine("Enter height");
        float h = float.Parse(Console.ReadLine());

        float area = ((a + b) / 2) * h;
        Console.WriteLine("Area -> {0}", area);
    }
}

 