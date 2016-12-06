using System;
using System.Linq;

class IncreasingAbsoluteDifferences
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());      

        for (int i = 0; i < count; i++)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] absDiffSeq = CalculateAbsDiff(sequence);
           
            bool isAbsDiffSeqIncreasing = IsAbsDiffSeqIncreasing(absDiffSeq);

            if (isAbsDiffSeqIncreasing)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }

    public static int[] CalculateAbsDiff(int[] sequence)
    {
        int[] absDiffSeq = new int[sequence.Length - 1];

        for (int i = 0; i < sequence.Length - 1; i++)
        {
            int currDiff = Math.Abs(sequence[i] - sequence[i + 1]);
            absDiffSeq[i] = currDiff;
        }

        return absDiffSeq;
    }

    public static bool IsAbsDiffSeqIncreasing(int[] sequence)
    {
        bool isIncreasing = true;
        for (int i = 0; i < sequence.Length - 1; i++)
        {
            if (sequence[i] > sequence[i + 1] || Math.Abs(sequence[i] - sequence[i + 1]) >= 2)
            {
                isIncreasing = false;
                break;
            }
        }

        return isIncreasing;
    }
}

