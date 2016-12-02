using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MagicWords
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var words = new List<string>();

        for (int i = 0; i < n; i++)
        {
            words.Add(Console.ReadLine());
        }

        List<string> wordsReordered = Reorder(words);
        Console.WriteLine(Print(wordsReordered));
    }

    static List<string> Reorder(List<string> list)
    {       
        int position = 0;

        for (int i = 0; i < list.Count; i++)
        {
            string word = list[i];
            position = word.Length % (list.Count + 1);

            list[i] = null;
            list.Insert(position, word);
            list.Remove(null);

            //if (position < i)
            //{
            //    list.RemoveAt(i + 1);

            //}
            //else
            //{
            //    list.RemoveAt(i);
            //}
        }

        return list;
    }

    static StringBuilder Print(List<string> words)
    {
        StringBuilder result = new StringBuilder();

        string longestWord = words.OrderByDescending(word => word.Length).First();

        for (int i = 0; i < longestWord.Length; i++)
        {
            foreach (var word in words)
            {
                if (i >= word.Length)
                {
                    continue;
                }
                else
                {
                    result.Append(word[i]);
                }
            }
        }

        return result;
    }
}

