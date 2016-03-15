/*
Write a program that gets two numbers from the console and prints the greater of them.
Try to implement this without if statements.
Examples:

a	    b	    greater
5	    6	    6
10	    5	    10
0	    0	    0
-5	    -2	    -2
1.5	    1.6	    1.6
*/

using System;

class NumberComparer
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double firstNum = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double secondNum = double.Parse(Console.ReadLine());

        double greater = (firstNum > secondNum) ? firstNum : secondNum;
        Console.WriteLine(greater + " is greater");

        //Second solution
        //double greater1 = Math.Max(firstNum, secondNum);
        //Console.WriteLine(greater1 + " is greater");
    }
}

