/*
Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
Use the Euclidean algorithm (find it in Internet).
Examples:
a	    b	    GCD(a, b)
3	    2	    1
60	    40	    20
5	    -15	    5
*/

using System;

class CalculateGCD
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers, where a > b number: ");
        Console.Write("a = ");
        int firstNum = int.Parse(Console.ReadLine());
        Console.Write("b = ");
        int secondNum = int.Parse(Console.ReadLine());

        if (firstNum == 0 || secondNum == 0)
        {
            Console.WriteLine("None of the numbers should be zero!");
        }
        else if (firstNum >= secondNum)
        {
            do
            {
                firstNum = secondNum * (firstNum / secondNum) + firstNum % secondNum;
                int remainder = firstNum % secondNum;
                firstNum = secondNum;
                secondNum = remainder;
            }
            while (secondNum != 0);

            Console.WriteLine("GCD(a, b) = {0}", firstNum);
        }
        else 
        {
            Console.WriteLine("a should be bigger than b!");
        }
    }
}
    
    

