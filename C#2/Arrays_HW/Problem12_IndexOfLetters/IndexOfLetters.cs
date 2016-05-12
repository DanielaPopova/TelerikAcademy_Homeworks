using System;

class IndexOfLetters
{
    static void Main()
    {
        //char[] abc = new char[26];

        //for (char c = 'A'; c <= 'Z'; c++)
        //{
        //    abc[c - 'A'] = c;
        //    Console.WriteLine(abc[c - 'A'] + " ");
        //}

        char[] abc = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'}; //CTRL + U

        string word = Console.ReadLine().ToLower();

        for (int i = 0; i < word.Length; i++)
        {
            char letter = word[i];
            //Console.WriteLine(letter);

            for (int j = 0; j < abc.Length; j++)
            {
                if (word[i] == abc[j])
                {
                    Console.WriteLine(j);
                }
            }
        }
    }
}

