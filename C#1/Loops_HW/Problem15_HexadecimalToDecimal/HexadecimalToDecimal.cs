/*
Using loops write a program that converts a hexadecimal integer number to its decimal form.
The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality.
Examples:

hexadecimal	decimal
FE	        254
1AE3	    6883
4ED528CBB4	338583669684
*/

using System;

class HexadecimalToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter hexidecimal number");
        string hexNum = Console.ReadLine().ToUpper();
        int digit;
        long decNum = 0;
        double power = 0;

        for (int i = hexNum.Length - 1; i >= 0; i--)
        {           
            switch (hexNum[i])
            {
                case 'A': digit = 10; break;
                case 'B': digit = 11; break;
                case 'C': digit = 12; break;
                case 'D': digit = 13; break;
                case 'E': digit = 14; break;
                case 'F': digit = 15; break;
                default: digit = int.Parse(hexNum[i].ToString()); break;
            }

            decNum = decNum + (long)(digit * Math.Pow(16, power));
            power++;            
        }
        Console.WriteLine(decNum);
    }
}

