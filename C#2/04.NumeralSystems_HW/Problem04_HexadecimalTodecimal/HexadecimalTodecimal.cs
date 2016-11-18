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
using System;
using System.Numerics;

class SortingArray
{
    static void Main()
    {
        string hexNumber = Console.ReadLine();
        Console.WriteLine(ConvertHexToDecimal(hexNumber));
    }

    static BigInteger ConvertHexToDecimal(string hexNumber)
    {
        BigInteger decimalNumber = 0;

        for (int i = 0; i < hexNumber.Length; i++)
        {
            string symbol = hexNumber[i].ToString();

            switch (symbol)
            {
                case "A": symbol = "10"; break;
                case "B": symbol = "11"; break;
                case "C": symbol = "12"; break;
                case "D": symbol = "13"; break;
                case "E": symbol = "14"; break;
                case "F": symbol = "15"; break;                
            }

            decimalNumber = int.Parse(symbol) + decimalNumber * 16;
        }

        return decimalNumber;
    }
}
*/
