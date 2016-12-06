using System;
using System.Numerics;

class DeCatCoding
{
    static void Main()
    {
        string[] catWords = Console.ReadLine().Split(' ');


        for (int i = 0; i < catWords.Length; i++)
        {
            string currWord = catWords[i];
            BigInteger base22number = 0;

            for (int j = 0; j < currWord.Length; j++)
            {
                char symbol = currWord[j];
                int digit = symbol - 'a';
                base22number = digit + base22number * 21;
            }

            string base26word = string.Empty;

            do
            {
                char symbol = (char)((base22number % 26) + 'a');
                base22number /= 26;
                base26word = symbol + base26word;
            }
            while (base22number > 0);

            Console.Write(base26word + " ");
        }
    }
}

