/*
Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
Use only one loop.
Examples:

n	k	n! / k!
5	2	60
6	5	6
8	3	6720
*/

using System;
using System.Numerics;

class CalculateFactorialDivision
{
    static void Main()
    {
        Console.Write("Enter number n: ");
        ushort n = ushort.Parse(Console.ReadLine());
        Console.Write("Enter number k: ");
        ushort k = ushort.Parse(Console.ReadLine());
        BigInteger result = 1;
        BigInteger nFactorial = 1;

        if (n >= 1 && n <= 100 )
        {
            if (k > n)
            {
                Console.WriteLine("n must be bigger than k!");
            }
            else
            {
                for (int i = n; i > k; i--)
                {
                    nFactorial *= i;                    
                } 
               
                Console.WriteLine("n! / k! = {0}", nFactorial);
            }
        }
        else
        {
            Console.WriteLine("n and k must be in range [1...100]");
        }

    }
}

