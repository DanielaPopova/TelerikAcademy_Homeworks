/*
Write an expression that checks if given positive integer number n (n ≤ 100) is prime (i.e. it is divisible without remainder only to itself and 1).
Note: You should check if the number is positive
Examples:

n	Prime?
1	false
2	true
3	true
4	false
9	false
97	true
51	false
-3	false
0	false
*/

using System;

class PrimeNumberCheck
{
    static void Main()
    {
        Console.WriteLine("Enter intiger number <= 100");
        int number = int.Parse(Console.ReadLine());

        double sqrt = Math.Sqrt(number);

        if (number <= 0 || number == 1)
        {
            Console.WriteLine("Prime -> " + false);
        }
        else
        {
            for (int i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    Console.WriteLine("Prime -> " + false);
                    return;
                }
            }
            Console.WriteLine("Prime -> " + true);
        }
    }
}

