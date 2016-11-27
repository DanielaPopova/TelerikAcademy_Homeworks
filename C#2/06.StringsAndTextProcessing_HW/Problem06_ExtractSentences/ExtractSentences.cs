using System;
using System.Linq;

class ExtractSentences
{
    static void Main()
    {
        string searchedWord = Console.ReadLine(); //"in";
        string text = Console.ReadLine();  //"We are living in a yellow in submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days."; 

        string[] sentences = text.Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
        char[] delimiters = text.Where(symbol => !char.IsLetter(symbol)).Distinct().ToArray();

        for (int i = 0; i < sentences.Length; i++)
        {
            string sentence = sentences[i].Trim();
            string[] words = sentence.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < words.Length; j++)
            {
                if (searchedWord == words[j].Trim())
                {
                    Console.Write(sentence + ". ");
                    break;                              //if a sentence contains twice searchedWord => twice printed sentence, hence "break;"
                }
            }
        }
    }
}

/*
using System;

class Program
{
    static void Main()
    {
        string word = Console.ReadLine();
        string text = Console.ReadLine();

        string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

        for (int j = 0; j < sentences.Length; j++)
        {
            string sentence = sentences[j].Trim();
            
            int index = sentence.IndexOf(word);

            while (index != -1)
            {
                int indexBefore = index - 1;
                int indexAfter = index + word.Length;

                if (indexBefore == -1 && indexAfter == sentence.Length)
                {
                    Console.Write(sentence + ". ");
                    break;
                }

                if ((indexBefore == -1 && Char.IsLetter(sentence[indexAfter])) ||
                    (indexAfter == sentence.Length && Char.IsLetter(sentence[indexBefore])))
                {
                    index = sentence.IndexOf(word, index + 1);
                    if (index == -1)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                if ((indexBefore == -1 && !Char.IsLetter(sentence[indexAfter])) ||
                    (indexAfter == sentence.Length && !Char.IsLetter(sentence[indexBefore])) ||
                    (!Char.IsLetter(sentence[indexBefore]) && !Char.IsLetter(sentence[indexAfter])))
                {
                    Console.Write(sentence + ". ");
                    break;
                }

                index = sentence.IndexOf(word, index + 1);
            }            
        }
    }
}                                   
*/
