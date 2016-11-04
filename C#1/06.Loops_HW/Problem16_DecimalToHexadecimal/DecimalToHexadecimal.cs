/*
Using loops write a program that converts an integer number to its hexadecimal representation.
The input is entered as long. The output should be a variable of type string.
Do not use the built-in .NET functionality.
Examples:

decimal	        hexadecimal
254	            FE
6883	        1AE3
338583669684	4ED528CBB4
*/

using System;

class DecimalToHexadecimal
{
    static void Main()
    {
        Console.WriteLine("Enter integer number:");
        long decNum = long.Parse(Console.ReadLine());

        string hexNum = string.Empty;

        do
        {
            string reminder = (decNum % 16).ToString();
            decNum = decNum / 16;
            switch (reminder)
            {
                case "10": reminder = "A"; break;
                case "11": reminder = "B"; break;
                case "12": reminder = "C"; break;
                case "13": reminder = "D"; break;
                case "14": reminder = "E"; break;
                case "15": reminder = "F"; break;                
            }
            hexNum = reminder + hexNum;
        }
        while (decNum % 16 > 0);
        
        Console.WriteLine(hexNum);
    }
}

