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
Description

Write a program that extracts from a given text all sentences containing given word.

Input

On the first line you will receive a string - the word
On the second line you will receive a string - the text
Output

Print only the sentences containing the word on a single line
Constraints

Sentences are separated by . and the words – by non-letter symbols
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                                                                Output
in
We are living in a yellow submarine. We don't have anything else.       We are living in a yellow submarine. 
Inside the submarine is very tight. So we are drinking all the day.     We will move out of it in 5 days.
We will move out of it in 5 days.	                                   
*/

/*
 for (int i = 0; i < sentences.Length; i++)
        {
            string sentence = sentences[i];
            string toLower = sentence.ToLower();
            int startIndex = toLower.IndexOf(word);
            
            for (int j = 0; j < toLower.Length; j++)
            {
                while (startIndex != -1)
                {
                    string foundMatch = toLower.Substring(startIndex, word.Length);

                    char symbolBefore = ' ';
                    char symbolAfter = ' ';

                    if ((startIndex - 1) < 0)
                    {
                        symbolBefore = toLower[startIndex];
                        if (!char.IsLetter(symbolBefore))
                        {
                            symbolBefore = 'a';
                        }
                    }
                    else if ((startIndex + word.Length + 1) > sentence.Length)
                    {
                        symbolAfter = toLower[startIndex + word.Length - 1];
                        if (!char.IsLetter(symbolAfter))
                        {
                            symbolAfter = 'a';
                        }
                    }
                    else if ((startIndex - 1) < 0 && (startIndex + word.Length + 1) > sentence.Length)
                    {
                        symbolBefore = toLower[startIndex];
                        symbolAfter = toLower[startIndex + word.Length - 1];
                        if (!char.IsLetter(symbolBefore) && !char.IsLetter(symbolAfter))
                        {
                            symbolBefore = 'a';
                            symbolAfter = 'a';
                        }
                    }
                    else
                    {
                        symbolBefore = toLower[startIndex - 1];
                        symbolAfter = toLower[startIndex + word.Length];                        
                    }

                    if (!char.IsLetter(symbolBefore) && !char.IsLetter(symbolAfter))
                    {
                        Console.Write(sentence + ".");
                    }
                    
                    startIndex = toLower.IndexOf(word, startIndex + 1);
                }
            }
        }
*/


