using System;

class GetLargestNumber
{
    static void Main()
    {

        string[] inputNumbers = Console.ReadLine().Split(' ');
        int[] numbers = new int[inputNumbers.Length];

        for (int i = 0; i < inputNumbers.Length; i++)
        {
            numbers[i] = int.Parse(inputNumbers[i]);            
        }

        int maxNum = GetMax(numbers);
        Console.WriteLine(maxNum);
    }

    static int GetMax(int[] numbers)
    {
        int biggestNum = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            biggestNum = Math.Max(biggestNum, numbers[i]);
        }

        return biggestNum;
    }
}

/*
using System;

class Program
{
    static void Main()
    {
        string[] numbers = Console.ReadLine().Split(' ');
        long maxNum = long.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            maxNum = GetMax(maxNum, long.Parse(numbers[i].ToString()));
        }

        Console.WriteLine(maxNum);
    }

    static long GetMax(long firstNum, long secondNum)
    { 
        if (firstNum >= secondNum)
        {
            return firstNum;
        }
        else
        {
            return secondNum;
        }
    }
}
*/

