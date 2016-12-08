using System;
using System.Numerics;
using System.Text;

class GoshoCode
{
    static string keyWord;

    static void Main()
    {
        keyWord = Console.ReadLine();

        StringBuilder wholeText = new StringBuilder();

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string currLine = Console.ReadLine();
            wholeText.Append(currLine + " ");
        }

        string text = wholeText.ToString().Trim();
        string[] allSentences = text.Split(new[] { '.', '!' }, StringSplitOptions.RemoveEmptyEntries);
        
        string substirng = string.Empty;
        BigInteger sum = 0;

        for (int i = 0; i < allSentences.Length; i++)
        {
            string sentence = allSentences[i].Trim();

            if (sentence.Contains(keyWord))
            {
                if (IsKeywordInStatement(text, sentence))
                {
                    substirng = FindSubstring(sentence, '.');
                    sum = CalculateSum(substirng);
                }
                else
                {
                    substirng = FindSubstring(sentence, '!');
                    sum = CalculateSum(substirng);
                }
            }     
        }       

        Console.WriteLine(sum);
    }
   
    public static bool IsKeywordInStatement(string text, string sentence)
    {
        if (text[text.IndexOf(sentence) + sentence.Length] == '.')
        {
            return true;
        }

        return false;
    }

    public static string FindSubstring(string sentence, char punctuation)
    {
        string substring = string.Empty;
      
        if (punctuation == '.')
        {
            int startIndex = sentence.IndexOf(keyWord) + keyWord.Length;
            substring = sentence.Substring(startIndex); 
        }
        else if (punctuation == '!')
        {
            int endIndex = sentence.IndexOf(keyWord) - 1;
            substring = sentence.Substring(0, endIndex);
        }        

        return substring;
    }

    public static BigInteger CalculateSum(string sentenceWithKeyword)
    {
        BigInteger sum = 0;

        foreach (var symbol in sentenceWithKeyword)
        {
            if (symbol != ' ')
            {
                sum += (int)symbol * keyWord.Length;
            }
        }

        return sum;
    }
}

