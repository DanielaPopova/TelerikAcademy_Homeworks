using System;
using System.Linq;
using System.Numerics;

class EvenDifferences
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        BigInteger evenSum = 0;

        for (int i = 1; i < numbers.Length; i++)
        {
            long currNumber = numbers[i];
            long absoluteDiff = Math.Abs(currNumber - numbers[i - 1]);

            if (absoluteDiff % 2 == 0)
            {
                i++;
                evenSum += absoluteDiff;
            }           

            if (i >= numbers.Length)
            {
                break;
            }
        }

        Console.WriteLine(evenSum);
    }
}

