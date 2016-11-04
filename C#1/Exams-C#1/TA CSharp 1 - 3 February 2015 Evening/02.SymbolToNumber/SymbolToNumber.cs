using System;

namespace _02.SymbolToNumber
{
    class SymbolToNumber
    {
        static void Main()
        {
            int secret = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            double encodedValue = 0;
            double result = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (symbol == '@')
                {
                    break;
                }
                else if (Char.IsLetter(symbol))
                {
                    encodedValue = (int)symbol * secret + 1000;
                }
                else if (Char.IsDigit(symbol))
                {
                    encodedValue = (int)symbol + secret + 500;
                }
                else
                {
                    encodedValue = (int)symbol - secret;
                }

                if (i % 2 == 0)
                {
                    result = encodedValue / 100D;
                    Console.WriteLine(result.ToString("F2"));
                }
                else
                {
                    result = encodedValue * 100;
                    Console.WriteLine(result);
                }
            }
        }
    }
}
