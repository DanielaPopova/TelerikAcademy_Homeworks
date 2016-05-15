using System;

class IntegerCalculations
{
    static void Main()
    {
        string[] inputNums = Console.ReadLine().Split(' ');
        int length = 5;
        int[] numbers = new int[5];

        for (int i = 0; i < length; i++)
		{
            numbers[i] = int.Parse(inputNums[i]);
		}

        Console.WriteLine(FindSmallestNumber(numbers));
        Console.WriteLine(FindBiggestNumber(numbers));
        Console.WriteLine("{0:F2}", FindAverage(numbers));
        Console.WriteLine(FindSum(numbers));
        Console.WriteLine(FindProduct(numbers));

    }

    static int FindSmallestNumber(params int[] numbers)
    {
        int smallestNum = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            smallestNum = Math.Min(smallestNum, numbers[i]);
        }

        return smallestNum;
    }

    static int FindBiggestNumber(params int[] numbers)
    {
        int biggestNum = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            biggestNum = Math.Max(biggestNum, numbers[i]);
        }

        return biggestNum;
    }

    static double FindAverage(params int[] numbers)
    {
        double average = 0;
        long sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];            
        }       

        average = (double)sum / numbers.Length;

        return average;
    }

    static int FindSum(params int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    static long FindProduct(params int[] numbers)
    {
        long product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }

        return product;
    }     
}

/*
Integer calculations
Description

Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
Use variable number of arguments. Write a program that reads 5 elements and prints their minimum, maximum,
average, sum and product.

Input

On the first line you will receive 5 numbers separated by spaces
Output

Print their minimum, maximum, average, sum and product
Each on a new line
The average value should be printed with two digits of precision
Constraints

Each of the five numbers will be in the interval [ -1000, 1000 ]
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	        Output
3 7 9 18 0	    0
                18
                7.40
                37
                0
*/

