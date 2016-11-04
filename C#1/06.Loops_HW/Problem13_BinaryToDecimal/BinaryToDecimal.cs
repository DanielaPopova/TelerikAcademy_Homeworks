/*
Using loops write a program that converts a binary integer number to its decimal form.
The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality.
Examples:

binary	                        decimal
0	                            0
11	                            3
1010101010101011	            43691
1110000110000101100101000000	236476736
*/

using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter binary number:");
        string binary = Console.ReadLine();        
        double power = 0;        
        long decNum = 0;

        for (int i = binary.Length - 1; i >= 0 ; i--)
        {
            int bit = int.Parse(binary[i].ToString());
            decNum = decNum + (long)(bit * Math.Pow(2, power));            
            power++;           
        }
        Console.WriteLine(decNum);
    }    
}

