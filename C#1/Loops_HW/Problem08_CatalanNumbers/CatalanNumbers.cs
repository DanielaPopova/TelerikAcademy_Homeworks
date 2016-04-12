/*
In combinatorics, the Catalan numbers are calculated by the following formula: (2 * n)! / (n + 1)! * n!, n >= 0
Write a program to calculate the nth Catalan number by given n (0 ≤ n ≤ 100).
Examples:

n	Catalan(n)
0	1
5	42
10	16796
15	9694845
*/

using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter number n in range [0...100]");
        ushort n = ushort.Parse(Console.ReadLine());

        BigInteger twoNFactorial = 1;
        BigInteger nOneFactorial = 1;
        BigInteger nFactorial = 1;
        BigInteger nthCatalanNum = 1;
        

        if (n >= 0 && n <= 100)
        {
            for (int i = (2 * n); i >= 1; i--)
            {
                twoNFactorial *= i;
            }
            for (int i = (n + 1); i >= 1; i--)
            {
                nOneFactorial *= i;
            }
            for (int i = 1; i <= n; i++)
            {
                nFactorial *= i;
            }
            nthCatalanNum = twoNFactorial / (nOneFactorial * nFactorial);
            Console.WriteLine("{0}-Catalan number is --> {1}", n, nthCatalanNum);
        }
        else
        {
            Console.WriteLine("Wrong range!");
        }
    }
}

