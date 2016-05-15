using System;

class SumIntegers
{
    static void Main()
    {
        string[] inputNums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[inputNums.Length];

        for (int i = 0; i < inputNums.Length; i++)
        {
            numbers[i] = int.Parse(inputNums[i].ToString());
        }

        Console.WriteLine(SumNumbers(numbers));

    }

    static int SumNumbers(int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }
}

/*
Description

You are given a sequence of positive integer values written into a string, separated by spaces.
Write a function that reads these values from given string and calculates their sum.

Input

On the only line you will receive a string consisted of positive integers
Output

Print the sum of the integers
Constraints

Each number will be in the interval [ 1, 1000 ]
There will not be more than 1000 numbers
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	            Output
43 68 9 23 318	    461
*/

