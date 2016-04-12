/*
In combinatorics, the number of ways to choose k different members out of a group of n different elements
(also known as the number of combinations) is calculated by the following formula: n! / (k! * (n - k)!). For example,
there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops.
Examples:

n	k	    n! / (k! * (n-k)!)
3	2	    3
4	2	    6
10	6	    210
52	5	    2598960
*/

using System;
using System.Numerics;

class NumberOfCombinations
{
    static void Main()
    {
        Console.Write("Enter integer number n: ");
        ushort n = ushort.Parse(Console.ReadLine());
        Console.Write("Enter integer number k: ");
        ushort k = ushort.Parse(Console.ReadLine());

        BigInteger nFactorial = 1;
        BigInteger nkFactorial = 1;
        BigInteger result = 1;

        if (n >= 1 && n <= 100)
        {
            if (k > n)
            {
                Console.WriteLine("k must be smaller than n!");
            }
            else
            {
                for (int i = n; i > k; i--)
                {
                    nFactorial *= i;
                }
                for (int i = (n - k); i >= 1; i--)
                {
                    nkFactorial *= i;
                }
                result = nFactorial / nkFactorial;
                Console.WriteLine("Number of combinations --> {0}", result);
            }
        }
        else
        {
            Console.WriteLine("The numbers n and k should be in range [1...100]!");
        }
    }
}

