using System;
using System.Numerics;

class TRES4Numbers
{
    static void Main()
    {
        BigInteger number = BigInteger.Parse(Console.ReadLine());
        string result = string.Empty;

        if (number == 0)
        {
            result = "LON+";
        }


        while (number > 0)
        {
            string word = (number % 9).ToString();
            number /= 9;

            switch (word)
            {
                case "0": word = "LON+"; break;
                case "1": word = "VK-"; break;
                case "2": word = "*ACAD"; break;
                case "3": word = "^MIM"; break;
                case "4": word = "ERIK|"; break;
                case "5": word = "SEY&"; break;
                case "6": word = "EMY>>"; break;
                case "7": word = "/TEL"; break;
                case "8": word = "<<DON"; break;
            }

            result = word + result;
        }

        Console.WriteLine(result);
    }
}

