using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


class CountWords
{
    static void Main()
    {
        string pathWords = "../../words.txt";
        string pathText = "../../test.txt";
        string pathResult = "../../result.txt";

        int countWords = 0;
        string matchWord = string.Empty;
        List<string> wordNcount = new List<string>();

        try
        {
            using (StreamReader readWords = new StreamReader(pathWords))
            {
                char[] delimitersWords = {' ', ','};
                string[] words = readWords.ReadLine().Split(delimitersWords, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];

                    using (StreamReader readText = new StreamReader(pathText))
                    {
                        string delimitersTextWords = "[\\W\\s\t\n\r]+";
                        string wholeText = readText.ReadToEnd();
                        string[] wordsInText = Regex.Split(wholeText, delimitersTextWords, RegexOptions.IgnoreCase);

                        //bool isMatch = false;     //only matching words, count is at least 1

                        for (int j = 0; j < wordsInText.Length; j++)
                        {
                            string textWord = wordsInText[j];

                            if (word.Equals(textWord, StringComparison.OrdinalIgnoreCase))
                            {
                                matchWord = word;
                                countWords++;
                                //isMatch = true;
                            }
                            else
                            {
                                matchWord = words[i];
                            }
                        }

                        //if (isMatch)
                        //{
                            wordNcount.Add(matchWord);
                            wordNcount.Add(countWords.ToString());
                            
                        //TODO: learn Dictionary key - value/ learn hash table 
                            
                            using (StreamWriter writeToFile = new StreamWriter(pathResult, false))   //true = appends, false = overwrite
                            {
                                                              
                                for (int k = 0; k < wordNcount.Count; k++)       //overwrites everytime, so at the end I check a list of 12 elements (7 wors + 7 countWords)
                                {
                                    if (k > 0 && k % 2 == 0)
                                    {
                                        writeToFile.WriteLine();                                        
                                    }
                                    writeToFile.Write(wordNcount[k] + " ");
                                }
                                //writeToFile.Write(Environment.NewLine);  
                            }
                        //}

                        countWords = 0;
                        //wordNcount.Clear();              //if I dont Clear(), at the end I'll work with wordsNcount with 14 elements;
                    }
                }

                List<string> sortedWords = new List<string>();
                int count = int.MinValue;
                int index = 0;
                
                string wordMatch = string.Empty;
                for (int i = 0; i < wordNcount.Count; i = 0)
                {
                    for (int j = 1; j < wordNcount.Count; j += 2)
                    {
                        
                        int currCount = int.Parse(wordNcount[j]);
                        int currIndex = j;

                        if (count < currCount)
                        {
                            count = currCount;
                            index = j;
                            wordMatch = wordNcount[j - 1];                            
                        }
                            
                    }
                    sortedWords.Add(wordMatch);
                    sortedWords.Add(count.ToString());
                    wordNcount.Remove(wordNcount[index - 1]);
                    wordNcount.Remove(wordNcount[index - 1]);
                    count = int.MinValue;                    
                }

                //Print sorted pairs
                Console.WriteLine("Sorted words:");

                for (int i = 0; i < sortedWords.Count; i++)
                {
                    if (i > 0 && i % 2 == 0 && i < sortedWords.Count)
                    {
                        Console.WriteLine();
                    }
                    Console.Write(sortedWords[i] + " ");
                }
                Console.WriteLine();
            }

            //Console.WriteLine("Done! Check result.txt");
        }
        catch (DirectoryNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (FileLoadException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (EndOfStreamException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}

/*
Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file test.txt.
The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order.
Handle all possible exceptions in your methods.
*/