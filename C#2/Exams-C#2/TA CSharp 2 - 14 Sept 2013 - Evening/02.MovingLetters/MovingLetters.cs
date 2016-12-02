using System;
using System.Text;

class MovingLetters
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(' ');

        StringBuilder sequence = new StringBuilder();

        int length = MaxLength(words);

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < words.Length; j++)
            {
                string currWord = words[j];

                if (i < currWord.Length)
                {
                    char currLetter = currWord[currWord.Length - 1 - i];
                    sequence.Append(currLetter);                    
                }                
            }
        }

        int position = 0;
        int steps = 0;
        
        for (int i = 0; i < sequence.Length; i++)
        {
            char letter = sequence[i];

            steps = Char.ToLower(sequence[i]) - 'a' + 1;
            position = (i + steps) % sequence.Length;            

            sequence.Remove(i, 1);
            sequence.Insert(position, letter);            
        }

        Console.WriteLine(sequence);
    }

    public static int MaxLength(string[] words)
    {
        int maxLength = words[0].Length;

        foreach (var word in words)
        {
            if (word.Length > maxLength)
            {
                maxLength = word.Length;
            }
        }

        return maxLength;
    }
}

