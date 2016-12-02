using System;
using System.Collections.Generic;
using System.Linq;

class RelevanceIndex
{
    static void Main()
    {
        string searchWord = Console.ReadLine().ToLower().Trim();
        int countParagraph = int.Parse(Console.ReadLine());

        char[] delimiters = {' ', ',', '.', '(', ')', ';', '-', '!', '?' };

        int[] matchesPerParagraph = new int[countParagraph];
        List<string> allParagraphs = new List<string>();

        for (int i = 0; i < countParagraph; i++)
        {
            int countMatch = 0;
           
            string paragraph = Console.ReadLine().Trim();
            string[] paragraphWords = paragraph.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            
            for (int j = 0; j < paragraphWords.Length; j++)
			{
                string word = paragraphWords[j].ToLower().Trim();
               
                if (word == searchWord)
                {
                    countMatch++;
                    paragraphWords[j] = word.ToUpper();
                }
			}

            matchesPerParagraph[i] = countMatch;

            string paragraphWithoutPunct = String.Join(" ", paragraphWords);
            allParagraphs.Add(paragraphWithoutPunct);
        }

        int maxCount = matchesPerParagraph[0];

        for (int i = 0; i < matchesPerParagraph.Length; i++)
        {
            maxCount = matchesPerParagraph.Max();

            int indexMaxCount = Array.IndexOf(matchesPerParagraph, maxCount);
            
            Console.WriteLine(allParagraphs[indexMaxCount]);

            matchesPerParagraph[indexMaxCount] = 0;
            maxCount = matchesPerParagraph[i];
        }
    }
}

