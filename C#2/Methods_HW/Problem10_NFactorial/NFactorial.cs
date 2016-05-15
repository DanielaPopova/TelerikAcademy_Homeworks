using System;
using System.Numerics;


class NFactorial
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        BigInteger factorial = FindFactorial(number);
        Console.WriteLine(factorial);
    }

    static BigInteger FindFactorial(int number)
    {
        BigInteger nFactorial = 1;
        for (int i = 1; i <= number; i++)
        {
            nFactorial *= i;
        }

        return nFactorial;
    }
}

/*
N Factorial
Description

Write a method that multiplies a number represented as an array of digits by a given integer number.
Write a program to calculate N!.

Input

On the first line you will receive the number N
Output

Print N!
Constraints

0 <= N <= 100
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
5	    120
*/

