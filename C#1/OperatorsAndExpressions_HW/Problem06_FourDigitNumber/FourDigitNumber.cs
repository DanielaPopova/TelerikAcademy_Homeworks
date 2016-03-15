/*
Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
Prints on the console the number in reversed order: dcba (in our example 1102).
Puts the last digit in the first position: dabc (in our example 1201).
Exchanges the second and the third digits: acbd (in our example 2101).
The number has always exactly 4 digits and cannot start with 0.

Examples:

n	 sum of digits	reversed	last digit in front	   second and third digits exchanged
2011	4	        1102	        1201	                        2101
3333	12	        3333	        3333	                        3333
9876	30	        6789	        6987	                        9786
*/

using System;

class FourDigitNumber
{
    static void Main()
    {
        Console.WriteLine("Enter four-digit positive number: ");
        int number = int.Parse(Console.ReadLine());

        int firstDigit = number / 1000;
        int secondDigit = (number / 100) % 10;
        int thirdDigit = (number / 10) % 10;
        int fourthDigit = number % 10;        

        int digitSum = firstDigit + secondDigit + thirdDigit + fourthDigit;
        Console.WriteLine("Sum ot digits -> {0}", digitSum);

        string reversedNum = fourthDigit.ToString() + thirdDigit.ToString() + secondDigit.ToString() + firstDigit.ToString();
        Console.WriteLine("Reversed number -> {0}", reversedNum);

        string lastDigitToFront = fourthDigit.ToString() + firstDigit.ToString() + secondDigit.ToString() + thirdDigit.ToString();
        Console.WriteLine("Last digit in front -> {0}", lastDigitToFront);

        string secondThirdExchanged = firstDigit.ToString() + thirdDigit.ToString() + secondDigit.ToString() + fourthDigit.ToString();
        Console.WriteLine("Second and third digits exchanged -> {0}", secondThirdExchanged);        
    }
}
