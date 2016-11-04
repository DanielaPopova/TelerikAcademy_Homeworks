/*
Write a program that reads 3 real numbers from the console and prints their sum.
Examples:

a	    b	    c	    sum
3	    4	    11	    18
-2	    0	    3	    1
5.5	    4.5	    20.1	30.1
*/

using System;

class SumOfThreeNumbers
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double firstNum = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double secondNum = double.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        double thirdNum = double.Parse(Console.ReadLine());

        double sum = firstNum + secondNum + thirdNum;
        Console.WriteLine("Sum = {0}", Math.Round(sum, 1));
        //Console.WriteLine("Sum = {0:0.0}", sum);
    }
}

