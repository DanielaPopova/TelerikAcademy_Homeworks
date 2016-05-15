using System;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int len = int.Parse(Console.ReadLine());

        string[] inputNum = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[len];

        for (int i = 0; i < len; i++)
        {
            numbers[i] = int.Parse(inputNum[i]);
        }

        int index = FindFirstLarger(numbers);
        Console.WriteLine(index);
    }

    static int FindFirstLarger(int[] numbers) 
    {
        int index = numbers[0];
        for (int i = 1; i < numbers.Length - 1; i++)
        {
            int currNum = numbers[i];
            if (currNum > numbers[i - 1] && currNum > numbers[i + 1])
            {
                index = i;
                break;
            }
            else
            {
                index = -1;
            }
        }
        return index;
    }
}

/*
First larger than neighbours
Description

Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there is no such element.

Input

On the first line you will receive the number N - the size of the array
On the second line you will receive N numbers sepated by spaces - the array
Output

Print the index of the first element that is larger than its neighbours or -1 if none are
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                Output
6
-26 -25 -28 31 2 27	    1
*/

