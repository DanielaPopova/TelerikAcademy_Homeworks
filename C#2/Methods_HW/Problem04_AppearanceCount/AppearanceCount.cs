using System;

class AppearanceCount
{
    static void Main()
    {
        int len = int.Parse(Console.ReadLine());

        string[] inputNum = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[len];

        for (int i = 0; i < len; i++)
        {
            numbers[i] = int.Parse(inputNum[i]);
            //Console.WriteLine(numbers[i]);
        }

        int searchedNum = int.Parse(Console.ReadLine());

        int count = CountNumberAppereance(numbers, searchedNum);
        Console.WriteLine(count);
    }

    static int CountNumberAppereance(int[] numbers, int searchedNum)
    {
        int count = 0;
        
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == searchedNum)
            {
                count++;
            }
        }
        return count;
    }
}

/*
Appearance count
Description

Write a method that counts how many times given number appears in a given array. Write a test program to check if the method is working correctly.

Input

On the first line you will receive a number N - the size of the array
On the second line you will receive N numbers separated by spaces - the numbers in the array
On the third line you will receive a number X
Output

Print how many times the number X appears in the array
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                        Output
8
28 6 21 6 -7856 73 73 -56       2
73	
*/

