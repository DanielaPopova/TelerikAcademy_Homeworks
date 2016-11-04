using System;

namespace _02.Decoding
{
    class Decoding
    {
        static void Main()
        {
            int salt = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            double encodedResult = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (symbol == '@')
                {
                    break;
                }
                else if (Char.IsLetter(symbol))
                {
                    encodedResult = ((int)symbol * salt) + 1000;
                }
                else if (Char.IsDigit(symbol))
                {
                    encodedResult = ((int)symbol + salt) + 500;
                }
                else
                {
                    encodedResult = (int)symbol - salt;
                }

                if (i % 2 == 0)
                {
                    encodedResult = encodedResult / 100D;
                    Console.WriteLine("{0:F2}", encodedResult);
                }
                else
                {
                    encodedResult = encodedResult * 100D;
                    Console.WriteLine(encodedResult);
                }
            }
        }
    }
}
