using System;
using System.Text;

class BinaryToHexadecimal
{
    static void Main()
    {
        string binaryNum = Console.ReadLine();
        long decimalNum = BinaryToDecimal(binaryNum);
        Console.WriteLine(DecimalToHexadecimal(decimalNum));
    }

    static long BinaryToDecimal(string binaryNum)
    {
        long decimalNum = 0;
        for (int i = 0; i < binaryNum.Length; i++)
        {
            decimalNum = decimalNum + int.Parse(binaryNum[i].ToString()) * (long)Math.Pow(2, binaryNum.Length - 1 - i);
        }

        return decimalNum;
    }

    static StringBuilder DecimalToHexadecimal(long decimalNum)
    {
        char hexDigit = ' ';
        StringBuilder hexRep = new StringBuilder();

        while (decimalNum > 0)
        {
            long remainder = decimalNum % 16;
            decimalNum /= 16;

            switch (remainder)
            {
                case 0: hexDigit = '0'; break;
                case 1: hexDigit = '1'; break;
                case 2: hexDigit = '2'; break;
                case 3: hexDigit = '3'; break;
                case 4: hexDigit = '4'; break;
                case 5: hexDigit = '5'; break;
                case 6: hexDigit = '6'; break;
                case 7: hexDigit = '7'; break;
                case 8: hexDigit = '8'; break;
                case 9: hexDigit = '9'; break;
                case 10: hexDigit = 'A'; break;
                case 11: hexDigit = 'B'; break;
                case 12: hexDigit = 'C'; break;
                case 13: hexDigit = 'D'; break;
                case 14: hexDigit = 'E'; break;
                case 15: hexDigit = 'F'; break;
            }
            hexRep.Append(hexDigit);
        }

        StringBuilder reversedHexRep = new StringBuilder();
        for (int i = 0; i < hexRep.Length; i++)
        {
            reversedHexRep.Append(hexRep[hexRep.Length - 1 - i]);
        }

        return reversedHexRep;
    }
}

/*
Binary to hexadecimal
Description

Write a program to convert binary numbers to hexadecimal numbers (directly).

Input

On the only line you will receive a decimal number - N
There will not be leading zeros
Output

Print the its binary representation on a single line
There should not be leading zeros
Use uppercase letters
Constraints

1 <= N <= 1018 = 110111100000101101101011001110100111011001000000000000000000(2)
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
10011	13
*/

