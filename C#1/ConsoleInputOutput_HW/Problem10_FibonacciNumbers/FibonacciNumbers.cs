/*
Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence
(at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
Note: You may need to learn how to use loops.

Examples:

n	comments
1	0
3	0 1 1
10	0 1 1 2 3 5 8 13 21 34
*/

using System;

class FibonacciNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter number");
        int number = int.Parse(Console.ReadLine());
        
        if (number == 0)
        {
            Console.WriteLine("Wrong input!");
            return;
        }
        else if (number == 1)
        {
            Console.WriteLine(0);
            return;
        }

        int firstNum = 0;
        int secondNum = 1;

        Console.Write("{0}, {1}", firstNum, secondNum);
        
        for (int count = 2; count < number; count++)
        {
            int thirdNum = firstNum + secondNum;
            Console.Write(", {0}", thirdNum);
            firstNum = secondNum;
            secondNum = thirdNum;           
        }
    }
}

