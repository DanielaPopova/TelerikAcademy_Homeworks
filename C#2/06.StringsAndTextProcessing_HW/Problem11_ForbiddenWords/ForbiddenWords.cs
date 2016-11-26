using System;

class ForbiddenWords
{
    static void Main()
    {
        string text = Console.ReadLine();
        string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (text.Contains(word))
            {
                text = text.Replace(word, new string('*', word.Length));
            }
        }

        Console.WriteLine(text);
    }
}

/*
Microsoft announced its next generation PHP compiler today. PHP is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
PHP CLR Microsoft
*/