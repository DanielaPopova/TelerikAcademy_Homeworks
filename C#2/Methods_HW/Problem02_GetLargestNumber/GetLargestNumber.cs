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
Get largest number
Description

Write a method GetMax() with two parameters that returns the larger of two integers.
Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().

Input

On the first line you will receive 3 integers separated by spaces
Output

Print the largest of them
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
8 3 6	    8
7 19 19	    19
*/

