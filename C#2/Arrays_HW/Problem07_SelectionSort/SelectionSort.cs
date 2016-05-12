using System;

class SelectionSort
{
    static void Main()
    {
        //char[] delimiters = { ' ', ',' };

        //Console.WriteLine("Enter a sequence of integer numbers, each on the same row");
        //string[] inputNumbers = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        int length = int.Parse(Console.ReadLine());

        int[] numbers = new int[length];
        int minNum, tempNum;

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());       
        }

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            minNum = i;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[minNum])
                {
                    minNum = j;
                }
            }

            tempNum = numbers[minNum];
            numbers[minNum] = numbers[i];
            numbers[i] = tempNum;
        }

        //Console.WriteLine("Sorted array:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}

