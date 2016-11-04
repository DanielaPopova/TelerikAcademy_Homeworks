/*
Using loops write a program that converts an integer number to its binary representation.
The input is entered as long. The output should be a variable of type string.
Do not use the built-in .NET functionality.
Examples:

decimal	    binary
0	        0
3	        11
43691	    1010101010101011
236476736	1110000110000101100101000000
*/

using System;

class DecimalToBinary
{
    static void Main()
    {
        Console.WriteLine("Enter decimal number:");
        long decNum = long.Parse(Console.ReadLine());
        int reminder;
        string binaryNum = string.Empty;

        if (decNum == 0)
        {
            Console.WriteLine(0);
        }
        
        while (decNum > 0)
        {
            reminder = (int)(decNum % 2);            
            decNum = decNum / 2;
            binaryNum = reminder.ToString() + binaryNum;            
        }
        Console.WriteLine(binaryNum);
       

        
        
           

            
        
    }
}

