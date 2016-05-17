using System;

class HexadecimalTodecimal
{
    static void Main()
    {
        string hexNum = Console.ReadLine();
        Console.WriteLine(ConvertHexToDec(hexNum));
    }

    static long ConvertHexToDec(string hexNum)
    {
        long decNum = 0;
        int digit = 0;
        for (int i = 0; i < hexNum.Length; i++)
        {
            char bit = hexNum[i];
            if (Char.IsLetter(bit))
            {
                switch (bit)
                {
                    case 'A': digit = 10; break;
                    case 'B': digit = 11; break;
                    case 'C': digit = 12; break;
                    case 'D': digit = 13; break;
                    case 'E': digit = 14; break;
                    case 'F': digit = 15; break;
                }
            }
            else
            {
                digit = int.Parse(bit.ToString());
            }

            decNum = decNum + digit * (long)Math.Pow(16, hexNum.Length - 1 - i);  
        }

        return decNum;
    }
}

/*
Hexadecimal to decimal
Description

Write a program that converts a hexadecimal number N to its decimal representation.

Input

On the only line you will receive a hexadecimal number - N
There will not be leading zeros
Letters will be uppercase
Output

Print the decimal representation of N on a single line
There should not be leading zeros
Constraints

1 <= N <= 1018 = DE0B6B3A7640000(16)
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
13	    19
*/
