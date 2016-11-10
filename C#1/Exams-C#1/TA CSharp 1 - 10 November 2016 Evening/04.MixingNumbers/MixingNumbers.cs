using System;
using System.Collections.Generic;

class MixingNumbers
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        int[] allNumbers = new int[length];
        List<int> mixedNumbers = new List<int>();
        List<int> subtractedNumbers = new List<int>();

        for (int i = 0; i < length; i++)
        {
            allNumbers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < allNumbers.Length - 1; i++)
        {
            int mixed = 0;
            int subtracted = 0;

            int currNumber = allNumbers[i];
            int nextNum = allNumbers[i + 1];

            if (currNumber < 0)
            {
                currNumber *= -1;
            }

            int currSecondDigit = currNumber % 10;
            int currFirstDigit = (currNumber / 10) % 10;

            int nextSecondDigit = nextNum % 10;
            int nextFirstDigit = (nextNum / 10) % 10;

            mixed = currSecondDigit * nextFirstDigit;
            subtracted = Math.Abs(currNumber - nextNum);

            mixedNumbers.Add(mixed);
            subtractedNumbers.Add(subtracted);
        }

        Console.WriteLine(String.Join(" ", mixedNumbers));
        Console.WriteLine(String.Join(" ", subtractedNumbers));
    }
}

