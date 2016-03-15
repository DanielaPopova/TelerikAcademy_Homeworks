/*
Write an if-statement that takes two double variables a and b and exchanges their values if the first one is greater than the second one.
As a result print the values a and b, separated by a space.
Examples:

a	    b	    result
5	    2	    2 5
3	    4	    3 4
5.5	    4.5	    4.5 5.5
*/

using System;

class ExchangeIfGreater
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers, each on a separate line");
        double firstNum = double.Parse(Console.ReadLine());
        double secondNum = double.Parse(Console.ReadLine());

        double smallerNum = firstNum;

        if (firstNum >= secondNum)
        {
            smallerNum = secondNum;
            Console.WriteLine("{0} {1}", secondNum, firstNum);
        }
        else
        {
            Console.WriteLine("{0} {1}", firstNum, secondNum);
        }
    }
}

