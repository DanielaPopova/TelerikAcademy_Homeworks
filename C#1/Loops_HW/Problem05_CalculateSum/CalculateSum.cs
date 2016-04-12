/*
Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/x^n.
Use only one loop. Print the result with 5 digits after the decimal point.
Examples:

n	x	S
3	2	2.75000
4	3	2.07407
5	-4	0.75781
*/

using System;

class CalculateSum
{
    static void Main()
    {
        Console.Write("Enter integer number n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter integer number x: ");
        int x = int.Parse(Console.ReadLine());

        int factorial = 1;
        double result = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;            
            double power = Math.Pow(x, i);
            result = result + (factorial / power);           
        }

        Console.WriteLine("result S = {0:F5}", result);
    }
}

