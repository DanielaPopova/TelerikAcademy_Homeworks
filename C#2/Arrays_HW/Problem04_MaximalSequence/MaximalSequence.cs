using System;

class MaximalSequence
{
    static void Main()
    {
        //char[] delimiters = { ',', ' ' };

        //Console.WriteLine("Enter sequence of numbers in a row:");
        // string[] input = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        //Console.WriteLine("Lenght = {0}", input.Length);

        int lenght = int.Parse(Console.ReadLine());
        int[] numbers = new int[lenght];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
            //Console.WriteLine(numbers[i]);
        }

        int bestSequenceLength = 1;
        int sequenceLength = 1;

        //int[] numbers = {1,1,1,1,2,3 };

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] == numbers[i + 1])
            {
                sequenceLength++;
                if (sequenceLength >= bestSequenceLength)
                {
                    bestSequenceLength = sequenceLength;
                }
            }
            else
            {
                sequenceLength = 1;
            }
        }
        Console.WriteLine(bestSequenceLength);
    }
}

