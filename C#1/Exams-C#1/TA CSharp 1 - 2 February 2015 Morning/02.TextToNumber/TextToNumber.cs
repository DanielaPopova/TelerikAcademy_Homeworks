using System;

namespace _02.TextToNumber
{
    class TextToNumber
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            long result = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (symbol == '@')
                {
                    break;
                }
                else if (Char.IsDigit(symbol))
                {
                    result *= (symbol - '0');
                }
                else if (Char.IsLetter(symbol))
                {
                    symbol = Char.ToLower(symbol);
                    result += (symbol - 'a');
                }
                else
                {
                    result %= number;
                }
            }
            Console.WriteLine(result);
        }
    }
}
