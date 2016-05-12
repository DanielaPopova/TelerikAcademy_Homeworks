/*
Write a program that finds in given array of integers a sequence of given sum S (if present).
Example:

array	            S       result
4 3 1 4 2 5 8	    11	    4 2 5
*/
using System;

class FindSumInArray
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int sum = int.Parse(Console.ReadLine());

        int currSum = 0;

        int[] numbers = new int[input.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
            //Console.WriteLine(numbers[i] + " ");
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            currSum = numbers[i];
            for (int j= i + 1; j < numbers.Length; j++)
            {                
                currSum += numbers[j];
                if (currSum == sum)
                {
                    for (int k = i; k <= j; k++)
                    {
                        Console.Write(numbers[k] + " ");
                    }
                    Console.WriteLine(); //if there are two sequences with same sum: 1 2 3 5 1
                    //break;
                }
            }            
        }
    }
}

