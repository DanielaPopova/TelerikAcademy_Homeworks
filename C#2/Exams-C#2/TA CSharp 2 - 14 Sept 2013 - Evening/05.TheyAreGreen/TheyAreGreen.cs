//ivaylo
using System;

class TheyAreGreen
{
    static void Main()
    {
        int countLetters = int.Parse(Console.ReadLine());
        int[] letters =new int[countLetters];

        for (int i = 0; i < countLetters; i++)
        {
            letters[i] = (int)(char.Parse(Console.ReadLine()));
        }

        Array.Sort(letters);

        int count = 0;

        if (IsValid(letters))
        {
            count++;
        }

        while (NextPermutation(letters))
        {
            if (IsValid(letters))
            {
                count++;                
            }
        }

        Console.WriteLine(count);
    }

    public static bool IsValid(int[] letters)
    {
        for (int i = 0; i < letters.Length - 1; i++)
        {
            if (letters[i] == letters[i + 1])
            {
                return false;
            }
        }

        return true;
    }

    public static bool NextPermutation(int[] letters)
    {       
        /*
         Knuths
         1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
         2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
         3. Swap a[j] with a[l].
         4. Reverse the sequence from a[j + 1] up to and including the final element a[n].

         */
        int largestIndex = -1;
        for (int i = letters.Length - 2; i >= 0; i--)
        {
            if (letters[i] < letters[i + 1])
            {
                largestIndex = i;
                break;
            }
        }

        if (largestIndex < 0) return false;

        int largestIndex2 = -1;
        for (int i = letters.Length - 1; i >= 0; i--)
        {
            if (letters[largestIndex] < letters[i])
            {
                largestIndex2 = i;
                break;
            }
        }

        int tmp = letters[largestIndex];
        letters[largestIndex] = letters[largestIndex2];
        letters[largestIndex2] = tmp;

        for (int i = largestIndex + 1, j = letters.Length - 1; i < j; i++, j--)
        {
            tmp = letters[i];
            letters[i] = letters[j];
            letters[j] = tmp;
        }

        return true;
    }    
}

