/*
Problem 8. Square Root

Create a console application that calculates and prints the square root of the number 12345.
Find in Internet “how to calculate square root in C#”.
*/

using System;

class SquareRoot
{
    static void Main(string[] args)
    {
        double a = 12345;
        double sqrRoot = Math.Sqrt(a);
        Console.WriteLine(sqrRoot);
    }
}

