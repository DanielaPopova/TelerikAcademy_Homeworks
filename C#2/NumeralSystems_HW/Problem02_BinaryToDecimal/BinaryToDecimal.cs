using System;

class BinaryToDecimal
{
    static void Main(string[] args)
    {
        string binary = Console.ReadLine();
        Console.WriteLine(ConvertBinaryToDecimal(binary));
    }

    static long ConvertBinaryToDecimal(string binaryNum)
    {
        long decimalNum = 0;
        for (int i = 0; i < binaryNum.Length; i++)
        {
            decimalNum = decimalNum + int.Parse(binaryNum[i].ToString()) * (long)Math.Pow(2, binaryNum.Length - 1 - i);
        }

        return decimalNum;
    }
}

/*
Binary to decimal
Description

Write a program that converts a binary number N to its decimal representation.

Input

On the only line you will receive a binary number - N
There will not be leading zeros
Output

Print the decimal representation of N on a single line
There should not be leading zeros
Constraints

1 <= N <= 1018 = 110111100000101101101011001110100111011001000000000000000000(2)
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
10011	19
*/

