using System;
using System.Text;

class DecimalToHexadecimal
{
    static void Main(string[] args)
    {
        long decimalNum = long.Parse(Console.ReadLine());
        Console.WriteLine(ConvertDecToHex(decimalNum));
    }

    static StringBuilder ConvertDecToHex(long decimalNum)
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
using System;
using System.Numerics;

class SortingArray
{
    static void Main()
    {
        BigInteger decimalNumber = BigInteger.Parse(Console.ReadLine());
        Console.WriteLine(ConvertDecimalToHex(decimalNumber));
    }

    static string ConvertDecimalToHex(BigInteger decimalNumber)
    {
        string hexNumber = string.Empty;

        if (decimalNumber == 0)
        {
            return "0";
        }

        while (decimalNumber > 0)
        {
            string remainder = ((int)(decimalNumber % 16)).ToString();
            decimalNumber /= 16;

            switch (remainder)
            {
                case "10": remainder = "A";  break;
                case "11": remainder = "B"; break;
                case "12": remainder = "C"; break;
                case "13": remainder = "D"; break;
                case "14": remainder = "E"; break;
                case "15": remainder = "F"; break;
            }

            hexNumber = remainder + hexNumber;
        }

        return hexNumber;
    }
}
*/

