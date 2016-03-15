/*
Write a program that finds the biggest of three numbers.
Examples:

a	    b	    c	biggest
5	    2	    2	    5
-2	    -2	    1	    1
-2	    4	    3	    4
0	    -2.5	5	    5
-0.1	-0.5	-1.1	-0.1
*/

using System;

    class BiggestOfThreeNumbers
    {
        static void Main()
        {
            Console.WriteLine("Enter three numbers each on a separate row:");

            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            double thirdNum = double.Parse(Console.ReadLine());

            //Check combination 2 2 1

            if (firstNum == secondNum && firstNum == thirdNum && secondNum == thirdNum)
            {
                Console.WriteLine("The numbers are equal - [{0}]", firstNum);
            }
            else if (firstNum >= secondNum)
            {
                if (firstNum > thirdNum)
                {
                    Console.WriteLine("Biggest -> {0}", firstNum);
                }
                else
                {
                    Console.WriteLine("Biggest -> {0}", thirdNum);
                }
            }
            else if (firstNum <= secondNum)
            {
                if (secondNum > thirdNum)
                {
                    Console.WriteLine("Biggest -> {0}", secondNum);
                }
                else
                {
                    Console.WriteLine("Biggest -> {0}", thirdNum);
                }
            } 
           
            //Other solution
            //double biggest = Math.Max(firstNum, (Math.Max(secondNum, thirdNum)));
            //Console.WriteLine("Biggest -> {0}", biggest);
        }
    }

