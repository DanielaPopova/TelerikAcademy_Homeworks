using System;
using System.Text;

class SeriesOfLetters
{
    static void Main()
    {
        string input =  Console.ReadLine();

        StringBuilder result = new StringBuilder();
        result.Append(input[0]);

        for (int i = 1; i < input.Length; i++)
        {
            char currSymbol = input[i];

            if (currSymbol == input[i - 1])
            {
                continue;
            }
            else
            {
                result.Append(currSymbol);
            }
        }
        Console.WriteLine(result);      
   }   
}

/*
using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder text = new StringBuilder(Console.ReadLine());

        int startIndex = 0;
        char currSymbol = text[startIndex];

        while (startIndex < text.Length - 1)
        {
            if (currSymbol == text[startIndex + 1])
            {
                text = text.Remove(startIndex + 1, 1);
            }
            else
            {
                startIndex = startIndex + 1;
                currSymbol = text[startIndex];
            }
        }

        Console.WriteLine(text);
    }
}
*/

