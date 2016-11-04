/*
Write an expression that extracts from given integer n the value of given bit at index p.
Examples:

n	    binary representation	p	bit at p
5	        00000000 00000101	2	    1
0	        00000000 00000000	9	    0
15	        00000000 00001111	1	    1
5343	    00010100 11011111	7	    1
62241	    11110011 00100001	11	    0
*/

using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.WriteLine("Enter integer number");
        int number = int.Parse(Console.ReadLine());
        
        string binaryRep = Convert.ToString(number, 2);
        Console.WriteLine("Binary representation: {0}", binaryRep.PadLeft(16, '0'));

        Console.WriteLine("Enter bit position");
        int position = int.Parse(Console.ReadLine());

        int mask = 1 << position;
        int numNMask = number & mask;
        int bit = numNMask >> position;
        Console.WriteLine(bit);
    }
}

