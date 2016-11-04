using System;

class DecimalToBinary
{
    static void Main(string[] args)
    {
        long decNum = long.Parse(Console.ReadLine());
        Console.WriteLine(ConvertDecimalToBinary(decNum));
    }

    static string ConvertDecimalToBinary(long number)
    {
        int systemBase = 2;
        string binaryRep = String.Empty;

        while (number > 0)
        {
            long remainder = number % systemBase;
            number /= systemBase;
            binaryRep = remainder.ToString() + binaryRep;            
        }

        return binaryRep;
    }
}

/*
Decimal to binary
Description

Write a program that converts a decimal number N to its binary representation.

Input

On the only line you will receive a decimal number - N
There will not be leading zeros
Output

Print the binary representation of N on a single line
There should not be leading zeros
Constraints

1 <= N <= 1018
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
19	    10011
*/

