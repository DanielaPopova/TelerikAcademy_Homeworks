using System;

class OneSystemToAnyOther
{
    static void Main()
    {
        int numberRadix = int.Parse(Console.ReadLine());
        string number = Console.ReadLine().ToUpper();
        int toBase = int.Parse(Console.ReadLine());

        long resultDec = ConvertAnyToDec(number, numberRadix);
        //Console.WriteLine(resultDec);
        string resultToBase = ConvertDecToAny(resultDec, toBase);
        Console.WriteLine(resultToBase);      

    }

    static long ConvertAnyToDec(string number, int radix)
    {
        long resultDec = 0;
        int digit = 0;
        for (int i = 0; i < number.Length; i++)
        {
            char bit = number[i];            
            switch (bit)
            {
                case '0': digit = 0; break;
                case '1': digit = 1; break;
                case '2': digit = 2; break;
                case '3': digit = 3; break;
                case '4': digit = 4; break;
                case '5': digit = 5; break;
                case '6': digit = 6; break;
                case '7': digit = 7; break;
                case '8': digit = 8; break;
                case '9': digit = 9; break;
                case 'A': digit = 10; break;
                case 'B': digit = 11; break;
                case 'C': digit = 12; break;
                case 'D': digit = 13; break;
                case 'E': digit = 14; break;
                case 'F': digit = 15; break;
            }          

            resultDec = digit + resultDec * radix;
        }

        return resultDec;
    }

    static string ConvertDecToAny(long number, int toBase)
    {
        string resultToBase = String.Empty;
        char digit = ' ';

        while (number > 0)
        {
            long remainder = number % toBase;
            number /= toBase;

            switch (remainder)
            {
                case 0: digit = '0'; break;
                case 1: digit = '1'; break;
                case 2: digit = '2'; break;
                case 3: digit = '3'; break;
                case 4: digit = '4'; break;
                case 5: digit = '5'; break;
                case 6: digit = '6'; break;
                case 7: digit = '7'; break;
                case 8: digit = '8'; break;
                case 9: digit = '9'; break;
                case 10: digit = 'A'; break;
                case 11: digit = 'B'; break;
                case 12: digit = 'C'; break;
                case 13: digit = 'D'; break;
                case 14: digit = 'E'; break;
                case 15: digit = 'F'; break;
            }
            resultToBase = digit.ToString() + resultToBase;
        }

        return resultToBase;
    }   
}

/*
One system to any other
Description

Write a program to convert the number N from any numeral system
of given base s to any other numeral system of base d.

Input

On the first line you will receive the number s
On the second line you will receive a number in base s - N
There will not be leading zeros
On the third line you will receive the number d
Output

Print N in base d
There should not be leading zeros
Use uppercase letters
Constraints

2 <= s, d <= 16
1 <= N <= 1018
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
13
16      21
9	
*/

