/*
Write a program that reads from the console a sequence of n integer numbers and returns the minimal,
the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
The output is like in the examples below.
Example 1:
input	output
3 
2 
5 
1	    min = 1 
        max = 5 
        sum = 8 
        avg = 2.67

Example 2:
input	output
2 
-1 
4	    min = -1 
        max = 4 
        sum = 3 
        avg = 1.50
*/

using System;

class MinMaxSumAverage
{
    static void Main()
    {
        Console.WriteLine("Enter count of the numbers");
        int numbersCount = int.Parse(Console.ReadLine());

        double max = double.MinValue;
        double min = double.MaxValue;
        double sum = 0;
        double average = 0;

        Console.WriteLine("Enter numbers:");
        for (int i = 1; i <= numbersCount; i++)
        {            
            double number = double.Parse(Console.ReadLine());

            min = Math.Min(number, min); 
            max = Math.Max(number, max);            
            sum += number;
            average = sum / numbersCount;
        }

        Console.WriteLine("min = {0}", min);
        Console.WriteLine("max = {0}", max);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("average = {0:0.00}", average);
    }
}

