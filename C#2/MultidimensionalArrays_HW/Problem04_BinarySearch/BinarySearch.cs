/*
Write a program, that reads from the console an array of N integers and an integer K,
sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
*/
using System;

class BinarySearch
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        int[] arr = new int[length];

        for (int i = 0; i < length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(arr);

        int largestNum = int.MinValue;
        int endIndex = Array.BinarySearch(arr, end);

        if (endIndex >= 0)
        {
            largestNum = arr[endIndex];
        }
        else
        {
            if (end >= arr[arr.Length - 1])
            {
                largestNum = arr[arr.Length - 1];
            }
            else
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (end >= arr[i] && end < arr[i + 1])
                    {
                        largestNum = arr[i];
                        break;
                    }
                }
            }
        }
        Console.WriteLine(largestNum);
    }
}

