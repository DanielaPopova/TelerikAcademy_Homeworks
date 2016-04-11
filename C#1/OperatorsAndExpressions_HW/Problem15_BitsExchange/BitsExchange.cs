/*
Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
Examples:

n	            binary representation of n	                binary result	                            result
1140867093	    01000100 00000000 01000000 00010101	        01000010 00000000 01000000 00100101	        1107312677
255406592	    00001111 00111001 00110010 00000000	        00001000 00111001 00110010 00111000	        137966136
4294901775	    11111111 11111111 00000000 00001111	        11111001 11111111 00000000 00111111	        4194238527
5351	        00000000 00000000 00010100 11100111	        00000100 00000000 00010100 11000111	        67114183
2369124121	    10001101 00110101 11110111 00011001	        10001011 00110101 11110111 00101001	        2335569705
*/

using System;

class BitsExchange
{
    static void Main()
    {
        //Stil thinking 
        uint number = uint.Parse(Console.ReadLine());
        string binaryNum = Convert.ToString(number, 2).PadLeft(32, '0');

        uint result3, result4, result5, result24, result25, result26, mask;

        uint nMask3 = number & 1 << 3;
        uint bit3 = nMask3 >> 3;
        //Console.WriteLine(bit3);

        uint nMask4 = number & 1 << 4;
        uint bit4 = nMask4 >> 4;
        //Console.WriteLine(bit4);

        uint nMask5 = number & 1 << 5;
        uint bit5 = nMask5 >> 5;
        //Console.WriteLine(bit5);

        uint nMask24 = number & 1 << 24;
        uint bit24 = nMask24 >> 24;
        //Console.WriteLine(bit24);

        uint nMask25 = number & 1 << 25;
        uint bit25 = nMask25 >> 25;
        //Console.WriteLine(bit25);

        uint nMask26 = number & 1 << 26;
        uint bit26 = nMask26 >> 26;
        //Console.WriteLine(bit26);

        if (bit24 == 0)
        {
            mask = ~((uint)1 << 3);
            result24 = number & mask;
        }
        else
        {
            mask = (uint)1 << 3;
            result24 = number | mask;
        }
        //string result24Bin = Convert.ToString(result24, 2).PadLeft(32, '0');
        //Console.WriteLine("Result Binary {0}", result24Bin);
        //Console.WriteLine("Result {0}", result24);

        if (bit25 == 0)
        {
            mask = ~((uint)1 << 4);
            result25 = result24 & mask;
        }
        else
        {
            mask = ((uint)1) << 4;
            result25 = result24 | mask;
        }
        //string result25Bin = Convert.ToString(result25, 2).PadLeft(32, '0');
        //Console.WriteLine("Result Binary {0}", result25Bin);
        //Console.WriteLine("Result {0}", result25);

        if (bit26 == 0)
        {
            mask = ~((uint)1 << 5);
            result26 = result25 & mask;
        }
        else
        {
            result26 = result25 | ((uint)1 << 5);
        }

        //string result26Bin = Convert.ToString(result26, 2).PadLeft(32, '0');
        //Console.WriteLine("Result Binary {0}", result26Bin);
        //Console.WriteLine("Result {0}", result26);

        if (bit3 == 0)
        {
            mask = ~((uint)1 << 24);
            result3 = result26 & mask;
        }
        else
        {
            mask = ((uint)1) << 24;
            result3 = result26 | mask;
        }

        if (bit4 == 0)
        {
            mask = ~((uint)1 << 25);
            result4 = result3 & mask;
        }
        else
        {
            mask = ((uint)1) << 25;
            result4 = result3 | mask;
        }

        if (bit5 == 0)
        {
            mask = ~((uint)1 << 26);
            result5 = result4 & mask;
        }
        else
        {
            mask = ((uint)1) << 26;
            result5 = result4 | mask;
        }

        Console.WriteLine(result5);
    }
}

