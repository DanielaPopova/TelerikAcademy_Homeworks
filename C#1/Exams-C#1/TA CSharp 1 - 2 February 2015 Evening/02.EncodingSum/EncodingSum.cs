using System;

namespace _02.EncodingSum
{
    class EncodingSum
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
                else if (symbol >= 65 && symbol <= 90)
                {
                    result += (symbol - 'A');
                }
                else if (symbol >= 97 && symbol <= 122)
                {
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
