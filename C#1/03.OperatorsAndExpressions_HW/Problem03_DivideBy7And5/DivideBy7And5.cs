/*
Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 at the same time.
Examples:

n	Divided by 7 and 5?
3       false
0       true
5       false
7       false
35      true
140     true
*/

using System;

class DivideBy7And5
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int number = int.Parse(Console.ReadLine());
        bool isTrue = true;

        if (number % 5 == 0 && number % 7 == 0)
        {
            Console.WriteLine(isTrue);
        }
        else
        {
            Console.WriteLine(!isTrue);
        }
    }
}

