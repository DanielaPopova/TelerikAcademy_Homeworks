using System;

class LargerThanNeighbours
{
    static void Main()
    {
        int len = int.Parse(Console.ReadLine());
        string[] inputNums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] numbers = new int[len];
        for (int i = 0; i < len; i++)
        {
            numbers[i] = int.Parse(inputNums[i]);
        }

        int count = CountLargerThanNeighbours(numbers);
        Console.WriteLine(count);
    }

    static int CountLargerThanNeighbours(int[] numbers)
    {
        int count = 0;
        for (int i = 1; i < numbers.Length - 1; i++)
        {
            int currNum = numbers[i];
            if (currNum > numbers[i - 1] && currNum > numbers[i + 1])
            {
                count++;
            }
        }
        return count;

    }
}

/*
Larger than neighbours
Description

Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist). Write program that reads an array of numbers and prints how many of them are larger than their neighbours.

Input

On the first line you will receive the number N - the size of the array
On the second line you will receive N numbers separated by spaces - the array
Output

Print how many numbers in the array are larger than their neighbours
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                Output
6
-26 -25 -28 31 2 27	    2
*/

