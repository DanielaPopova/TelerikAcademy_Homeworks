using System;

class SortingArray
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        string[] inputNums = Console.ReadLine().Split(' ');

        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = int.Parse(inputNums[i]);
        }

        SortArray(array);
  
    }

    static int FindMaxElementInRange(int[] array, int startIndex)
    {
        int maxElement = array[startIndex];
        for (int i = startIndex; i < array.Length; i++)
        {
            if (array[i] > maxElement)
            {
                maxElement = array[i];
            }
            startIndex++;
        }

        return maxElement;
    }

    static int FindMaxIndex(int[] array) 
    {
        int maxIndex = 0;
        int maxElement = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maxElement )
            {
                maxElement = array[i];
                maxIndex = i;
            }
        }

        return maxIndex;
    }

    static void SortArray(int[] array)
    {
        int[] sortedArray = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            int maxIndex = FindMaxIndex(array);
            sortedArray[sortedArray.Length - 1 - i] = FindMaxElementInRange(array, 0);
            array[maxIndex] = 0;
        }

        for (int i = 0; i < sortedArray.Length; i++)
        {
            Console.Write(sortedArray[i] + " ");
        }
    }
}

/*
Sorting array
Description

Write a method that returns the maximal element in a portion of array of integers starting at given index. Using it write another method that sorts an array in ascending / descending order. Write a program that sorts a given array.

Input

On the first line you will receive the number N - the size of the array
On the second line you will receive N numbers separated by spaces - the array
Output

Print the sorted array
Elements must be separated by spaces
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                        Output
6
3 4 1 5 2 6	                    1 2 3 4 5 6
10
36 10 1 34 28 38 31 27 30 20	1 10 20 27 28 30 31 34 36 38
*/
