using System;

class MaximalSum
{
    static void Main()
    {
        //char[] delimiters = { ',', ' ' };

        //Console.WriteLine("Enter a sequence of numbers:");
        //string[] inputNumbers = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        //int[] sequence = new int[inputNumbers.Length];
        //for (int i = 0; i < inputNumbers.Length; i++)
        //{
        //    sequence[i] = int.Parse(inputNumbers[i]);            
        //}


        int length = int.Parse(Console.ReadLine());
        int[] numbers = new int[length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        //int[] numbers = {2,3,-6,-1,2,-1,6,4,-8,8 };

        int tempSum = 0;
        int maxSum = 0;

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            tempSum = numbers[i];
            for (int j = i + 1; j < numbers.Length; j++)
            {
                tempSum += numbers[j];
                if (tempSum > maxSum)
                {
                    maxSum = tempSum;
                }
            }
            tempSum = 0;
            
        }
        Console.WriteLine(maxSum);
    }
}

