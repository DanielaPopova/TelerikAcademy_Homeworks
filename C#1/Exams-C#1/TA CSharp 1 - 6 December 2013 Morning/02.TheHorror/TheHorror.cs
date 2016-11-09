using System;

class TheHorror
{
    static void Main()
    {
        string text = Console.ReadLine();

        int count = 0;
        int sum = 0;

        for (int i = 0; i < text.Length; i++)
        {
            char symbol = text[i];

            if (Char.IsDigit(symbol) && i % 2 == 0)
            {
                sum += symbol - '0';
                count++;
            }
        }

        Console.WriteLine("{0} {1}", count, sum);
    }
}

