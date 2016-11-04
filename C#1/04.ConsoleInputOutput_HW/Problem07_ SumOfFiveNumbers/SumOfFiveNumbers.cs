/*
 Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.
Examples:

numbers	            sum
1 2 3 4 5	        15
10 10 10 10 10	    50
1.5 3.14 8.2 -1 0	11.84
*/

using System;

class SumOfFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter 5 number in a row: ");
        string input = Console.ReadLine();
        string[] numbers = input.Trim().Split(' ');
        double sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            double number = double.Parse(numbers[i]);
            sum += number;
        }
        Console.WriteLine("Sum is {0}", sum);
    }
}

