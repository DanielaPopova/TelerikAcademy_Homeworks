﻿using System;

class FrequentNumber
{
    static void Main()
    {
        //char[] delimiters = { ',', ' ' };

        //Console.WriteLine("Insert a sequence of numbers");
        //string[] inputNumbers = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        //int[] sequence = new int[inputNumbers.Length];

        //for (int i = 0; i < inputNumbers.Length; i++)
        //{
        //    sequence[i] = int.Parse(inputNumbers[i]);            
        //}

        int length = int.Parse(Console.ReadLine());
        int[] sequence = new int[length];
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = int.Parse(Console.ReadLine());
        }

        //int[] sequence = { 4, 5, 6, 7, 7, 7, 8, 9, 9, 9 };

        int maxCount = 1;
        int tempCount = 1;

        int bestNum = sequence[0];
        int currNum = sequence[0];

        for (int i = 0; i < sequence.Length - 1; i++)
        {
            for (int j = i + 1; j < sequence.Length; j++)
            {
                if (currNum == sequence[j])
                {
                    tempCount++;
                    if (tempCount >= maxCount)
                    {
                        maxCount = tempCount;
                        bestNum = currNum;
                    }
                }
            }
            tempCount = 1;
            currNum = sequence[i + 1];
        }
        Console.WriteLine("{0} ({1} times)", bestNum, maxCount);
    }
}

