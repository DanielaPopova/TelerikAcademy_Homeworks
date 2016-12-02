// Niki solution
using System;

class FeaturingWithGrisko
{
    static void Main()
    {
        string input = Console.ReadLine();
        char[] inputAsCharArray = input.ToCharArray();

        Array.Sort(inputAsCharArray);

        int count = 0;

        do
        {
            if (IsMatch(inputAsCharArray))
            {
                count++;
            }
        }
        while (NextPermutation(inputAsCharArray));

        Console.WriteLine(count);
    }

    public static bool NextPermutation(char[] array) 
    {
        for (int index = array.Length - 2; index >= 0; index--)
        {
            if (array[index] < array[index + 1])
            {
                int swapWithIndex = array.Length - 1;
                while (array[index] >= array[swapWithIndex])
                {
                    swapWithIndex--;
                }

                // Swap i-th and j-th elements
                var tmp = array[index];
                array[index] = array[swapWithIndex];
                array[swapWithIndex] = tmp;

                Array.Reverse(array, index + 1, array.Length - index - 1);
                return true;
            }
        }

        // No more permutations
        return false;
    }

    public static bool IsMatch(char[] word)
    {
        for (int i = 1; i < word.Length; i++)
        {
            if (word[i] == word[i - 1])
            {
                return false;
            }
        }

        return true;
    }
}
// bgcoder 10/100
//using System;
//using System.Collections.Generic;
//using System.Text;

//class FeaturingWithGrisko
//{
//    static void Main()
//    {
//        string word = Console.ReadLine();
//        int countWords = 0;

//        for (int i = 0; i < word.Length; i++)
//        {
//            char currSymbol = word[i];
//            List<char> lettersToCompare = LettersToCompare(word, i);

//            StringBuilder currWord = new StringBuilder(currSymbol.ToString());
            
//            int index = 0;

//            while (lettersToCompare.Count > 0 && index < lettersToCompare.Count)
//            {
//                char compareLetter = lettersToCompare[index];

//                if (currSymbol != compareLetter)
//                {
//                    currWord.Append(lettersToCompare[index]);
//                    currSymbol = lettersToCompare[index];
//                    lettersToCompare.RemoveAt(index);
//                    index = 0;
//                }
//                else
//                {
//                    index++;
//                }
//            }

//            if (currWord.Length == word.Length)
//            {
//                countWords++;
//            }
//        }

//        Console.WriteLine(countWords);
//    }

//    static List<char> LettersToCompare(string word, int indexLetter)
//    {
//        var compareLetters = new List<char>();

//        for (int i = 0; i < word.Length; i++)
//        {
//            char currLetter = word[i];

//            if (i != indexLetter)
//            {
//                compareLetters.Add(currLetter);
//            }
//        }

//        return compareLetters;
//    }
//}

