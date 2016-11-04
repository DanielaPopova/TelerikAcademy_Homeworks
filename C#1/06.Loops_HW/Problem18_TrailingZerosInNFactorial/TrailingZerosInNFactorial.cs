/*
Write a program that calculates how many zeroes the factorial of a given number n has at its end.
Your program should work well for very big numbers, e.g. n=100000.
Examples:

n	    trailing zeroes of n!	explaination
10	    2	                    3628800
20	    4	                    2432902008176640000
100000	24999	                think why
*/

using System;
using System.Numerics;

class TrailingZerosInNFactorial
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        BigInteger numFactorial = 1;
        int trailingZeros = 0;

        for (int i = 1; i <= number; i++)
        {
            numFactorial = numFactorial * i;
        }
                
        for (int i = 5; i <= number; i *= 5)
        {
            trailingZeros += number / i;
        }      
        
        Console.WriteLine("Zeroes --> {0}\n{1}! --> {2}", trailingZeros, number, numFactorial);
    }
}

