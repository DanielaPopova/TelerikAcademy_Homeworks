using System;
using System.Collections.Generic;

class ReverseSentence
{
    static void Main()
    {
        string text = Console.ReadLine();
        string[] allSentences = text.Split(new char[]{'!', '.', '?'}, StringSplitOptions.RemoveEmptyEntries);

        var endingsIndexes = FindSentenceEndingsAndIndexes(text);

        for (int i = 0; i < allSentences.Length; i++)
        {
            string currSentence = allSentences[allSentences.Length - 1 - i];

            string[] allWords = currSentence.Split(' ');

            for (int j = 0; j < allWords.Length; j++)
            {
                string currWord = allWords[allWords.Length - 1 - j];

                if (j == 0)
                {
                    currWord = MakeFirstLetterCapital(currWord);
                }

                if (j == allWords.Length - 1)
                {
                    currWord = MakeFirstLetterSmall(currWord);
                }
                
                Console.Write(j == allWords.Length - 1 ? currWord : currWord + " "); 
            }

            Console.Write(endingsIndexes[i].Key);
        }
    }

    static string MakeFirstLetterCapital(string word)
    {
        string result = string.Empty;

        for (int i = 0; i < word.Length; i++)
        {
            char currSymbol = word[i];

            if (Char.IsLetter(currSymbol) && i == 0)
            {
                result += Char.ToUpper(currSymbol);
            }
            else
            {
                result += currSymbol;
            }
        }

        return result;
    }

    static string MakeFirstLetterSmall(string word)
    {
        string result = string.Empty;

        for (int i = 0; i < word.Length; i++)
        {
            char currSymbol = word[i];

            if (Char.IsLetter(currSymbol) && i == 0)
            {
                result += Char.ToLower(currSymbol);
            }
            else
            {
                result += currSymbol;
            }
        }

        return result;
    }

    static List<KeyValuePair<char, int>> FindSentenceEndingsAndIndexes(string text)
    {
        var allPairs = new List<KeyValuePair<char, int>>();
        KeyValuePair<char, int> pair = new KeyValuePair<char, int>();

        for (int i = 0; i < text.Length; i++)
        {
            char currSymbol = text[i];
            int currIndex = i;

            if (currSymbol == '.' || currSymbol == '!' || currSymbol == '?')
            {
                pair = new KeyValuePair<char,int>(currSymbol, currIndex);
                allPairs.Add(pair);
            }
        }

        return allPairs;        
    }
}

//C# is not C++, not PHP and not Delphi! That's right to the point.