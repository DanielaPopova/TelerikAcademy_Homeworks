using System;
using System.Linq;
using System.Numerics;

class Messages
{
    static void Main()
    {
        string firstBase10 = Console.ReadLine();
        string operation = Console.ReadLine();
        string secondBase10 = Console.ReadLine();

        BigInteger first = ConvertToDec(firstBase10);
        BigInteger second = ConvertToDec(secondBase10);

        BigInteger result = 0;

        if (operation == "+")
        {
            result = first + second;
        }
        else if (operation == "-")
        {
            result = first - second;
        }

        Console.WriteLine(ConvertToBase10(result));
    }

    static BigInteger ConvertToDec(string number)
    {
        BigInteger decNumber = 0;
        
        for (int i = 0; i < number.Length; i += 3)
        {
            string word = number.Substring(i, 3);
            
            switch (word)
            {
                case "cad": word = "0"; break;
                case "xoz": word = "1"; break;
                case "nop": word = "2"; break;
                case "cyk": word = "3"; break;
                case "min": word = "4"; break;
                case "mar": word = "5"; break;
                case "kon": word = "6"; break;
                case "iva": word = "7"; break;
                case "ogi": word = "8"; break;
                case "yan": word = "9"; break;
            }

            decNumber = int.Parse(word) + decNumber * 10;
        }

        return decNumber;
    }

    static string ConvertToBase10(BigInteger number)
    {
        string base10 = string.Empty;

        do
        {
            string digit = (number % 10).ToString();

            switch (digit)
            {
                case "0": digit = "cad"; break;
                case "1": digit = "xoz"; break;
                case "2": digit = "nop"; break;
                case "3": digit = "cyk"; break;
                case "4": digit = "min"; break;
                case "5": digit = "mar"; break;
                case "6": digit = "kon"; break;
                case "7": digit = "iva"; break;
                case "8": digit = "ogi"; break;
                case "9": digit = "yan"; break;
            }

            base10 = digit + base10;

            number /= 10;
        }
        while (number > 0);

        return base10;
    }
}

