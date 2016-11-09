using System;

class NightmareOnCodeStreet
{
    static void Main()
    {
        string text = Console.ReadLine();

        int sum = 0;
        int count = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (Char.IsDigit(text[i]))
            {
                int currDigit = text[i] - '0';

                if (i % 2 == 1)
                {
                    count++;
                    sum += currDigit;
                }
            }            
        }

        Console.WriteLine("{0} {1}", count, sum);
    }
}

