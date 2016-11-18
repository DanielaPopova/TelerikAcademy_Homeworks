using System;
using System.Numerics;

class SortingArray
{
    static void Main()
    {
        int radix = int.Parse(Console.ReadLine());
        string number = Console.ReadLine();
        int toBase = int.Parse(Console.ReadLine());

        BigInteger resultToDec = ConvertAnyToDec(number, radix);
        Console.WriteLine(ConvertDecToAny(resultToDec, toBase));
    }

    static BigInteger ConvertAnyToDec(string number, int radix)
    {
        BigInteger decimalNum = 0;

        for (int i = 0; i < number.Length; i++)
        {
            string currSymbol = number[i].ToString();

            switch (currSymbol)
            {
                case "A": currSymbol = "10"; break;
                case "B": currSymbol = "11"; break;
                case "C": currSymbol = "12"; break;
                case "D": currSymbol = "13"; break;
                case "E": currSymbol = "14"; break;
                case "F": currSymbol = "15"; break;
                case "G": currSymbol = "16"; break;
                case "H": currSymbol = "17"; break;
                case "I": currSymbol = "18"; break;
                case "J": currSymbol = "19"; break;
                case "K": currSymbol = "20"; break;
                case "L": currSymbol = "21"; break;
                case "M": currSymbol = "22"; break;
                case "N": currSymbol = "23"; break;
                case "O": currSymbol = "24"; break;
                case "P": currSymbol = "25"; break;
                case "Q": currSymbol = "26"; break;
                case "R": currSymbol = "27"; break;
                case "S": currSymbol = "28"; break;
                case "T": currSymbol = "29"; break;
                case "U": currSymbol = "30"; break;
                case "V": currSymbol = "31"; break;
                case "W": currSymbol = "32"; break;
                case "X": currSymbol = "33"; break;
                case "Y": currSymbol = "34"; break;
                case "Z": currSymbol = "35"; break;
            }

            decimalNum = int.Parse(currSymbol) + decimalNum * radix;
        }

        return decimalNum;
    }

    static string ConvertDecToAny(BigInteger decNumber, int toBase)
    {
        string numberToBase = string.Empty;

        if (decNumber == 0)
        {
            return "0";
        }

        while (decNumber > 0)
        {
            string remainder = ((int)(decNumber % toBase)).ToString();
            decNumber /= toBase;

            switch (remainder)
            {
                case "10": remainder = "A"; break;
                case "11": remainder = "B"; break;
                case "12": remainder = "C"; break;
                case "13": remainder = "D"; break;
                case "14": remainder = "E"; break;
                case "15": remainder = "F"; break;
                case "16": remainder = "G"; break;
                case "17": remainder = "H"; break;
                case "18": remainder = "I"; break;
                case "19": remainder = "J"; break;
                case "20": remainder = "K"; break;
                case "21": remainder = "L"; break;
                case "22": remainder = "M"; break;
                case "23": remainder = "N"; break;
                case "24": remainder = "O"; break;
                case "25": remainder = "P"; break;
                case "26": remainder = "Q"; break;
                case "27": remainder = "R"; break;
                case "28": remainder = "S"; break;
                case "29": remainder = "T"; break;
                case "30": remainder = "U"; break;
                case "31": remainder = "V"; break;
                case "32": remainder = "W"; break;
                case "33": remainder = "X"; break;
                case "34": remainder = "Y"; break;
                case "35": remainder = "Z"; break;
            }                           

            numberToBase = remainder + numberToBase;
        }

        return numberToBase;
    }
}

/*using System;

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
*/

