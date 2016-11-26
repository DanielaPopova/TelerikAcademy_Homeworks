using System;

class SubstringInText
{
    static void Main()
    {
        string pattern = Console.ReadLine().ToLower();
        string text = Console.ReadLine().ToLower();

        int count = 0;  

        for (int i = 0; i < text.Length - pattern.Length + 1; i++)
        {
            if (text.Substring(i, pattern.Length) == pattern)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}

/*
using System;

class Program
{
    static void Main()
    {
        string pattern = Console.ReadLine().ToLower();
        string text = Console.ReadLine().ToLower();

        int indexPattern = text.IndexOf(pattern);
        int count = 0;

        while (indexPattern != -1)
        {
            count++;
            indexPattern = text.IndexOf(pattern, (indexPattern + pattern.Length));
        }

        Console.WriteLine(count);
    }
}
*/

