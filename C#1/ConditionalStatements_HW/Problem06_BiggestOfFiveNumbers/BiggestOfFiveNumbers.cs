/*
Write a program that finds the biggest of five numbers by using only five if statements.
Examples:

a	    b	    c	    d	    e	    biggest
5	    2	    2	    4	    1	    5
-2	    -22	    1	    0	    0	    1
-2	    4	    3	    2	    0	    4
0	    -2.5	0	    5	    5	    5
-3	    -0.5	-1.1	-2	    -0.1	-0.1
*/

using System;

class BiggestOfFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter five numbers each on a separate line");

        double firstNum = double.Parse(Console.ReadLine());
        double secondNum = double.Parse(Console.ReadLine());
        double thirdNum = double.Parse(Console.ReadLine());
        double fourthNum = double.Parse(Console.ReadLine());
        double fifthNum = double.Parse(Console.ReadLine());

        double biggestNum = firstNum;

        if (secondNum >= firstNum)
        {
            biggestNum = secondNum;            
        }
        if (thirdNum >= secondNum && thirdNum >= firstNum)
        {
            biggestNum = thirdNum;           
        }
        if (fourthNum >= firstNum && fourthNum >= secondNum && fourthNum >= thirdNum)
        {
            biggestNum = fourthNum;
        }
        if (fifthNum >= firstNum && fifthNum >= secondNum && fifthNum >= thirdNum && fifthNum >= fourthNum)
        {
            biggestNum = fifthNum;
        }
        
        Console.WriteLine("Biggest --> {0}", biggestNum);
    

        // :)
        //double max = Math.Max(Math.Max(Math.Max(secondNum, thirdNum), Math.Max(fourthNum, fifthNum)), firstNum);
        //Console.WriteLine("biggest --> {0}", max);

    }
}

