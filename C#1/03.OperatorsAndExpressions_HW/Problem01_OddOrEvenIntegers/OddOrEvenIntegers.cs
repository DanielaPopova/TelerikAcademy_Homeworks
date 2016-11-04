/*
Write an expression that checks if given integer is odd or even.
Examples:

n	Odd?
3	true
2	false
-2	false
-1	true
0	false
*/

using System;

class OddOrEvenIntegers
{
    static void Main()
    {
        Console.WriteLine("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Is {0} odd?", number);
        bool isOdd = true;
        if (number % 2 != 0)
        {
            Console.WriteLine(isOdd);
        }
        else if (number % 2 == 0)
        {
            Console.WriteLine(!isOdd);
        }
        else
        {
            Console.WriteLine(!isOdd);  //Checking if number = 0
        }
    }
}

