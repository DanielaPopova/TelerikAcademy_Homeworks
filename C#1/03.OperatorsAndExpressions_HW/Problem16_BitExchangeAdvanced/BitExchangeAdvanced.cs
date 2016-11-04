/*
Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
The first and the second sequence of bits may not overlap.
Examples:

n	            p	    q	    k	binary representation of n	                binary result	                            result
1140867093	    3	    24	    3	01000100 00000000 01000000 00010101	        01000010 00000000 01000000 00100101	        1107312677
4294901775	    24	    3	    3	11111111 11111111 00000000 00001111	        11111001 11111111 00000000 00111111	        4194238527
2369124121	    2	    22	    10	10001101 00110101 11110111 00011001	        01110001 10110101 11111000 11010001	        1907751121
987654321	    2	    8	    11	00111010 11011110 01101000 10110001	                            -	                    overlapping
123456789	    26	    0	    7	00000111 01011011 11001101 00010101	                            -	                    out of range
33333333333	    -1	    0	    33	00000111 11000010 11010010 01001101 01010101	                -	                    out of range
*/

using System;

class BitExchangeAdvanced
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        int firstBit = int.Parse(Console.ReadLine());
        int secondBit = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        int firstEnd = firstBit + step - 1;
        int secondEnd = secondBit + step - 1;        

        int fakeFirstBit = firstBit;
        int fakeSecondBit = secondBit;
        uint fakeNumber = number;       

        string binaryNum = Convert.ToString(number, 2).PadLeft(32, '0');
        //Console.WriteLine(binaryNum.Length);      

        for (int i = firstBit; i <= firstEnd; i++)
        {
            uint bit11 = (number & ((uint)1 << i)) >> i;
            //Console.WriteLine("BIT {0}",bit11);  
            //bit12 = (number & ((uint)1 << fakeSecondBit)) >> fakeSecondBit;
            //Console.WriteLine("BIT1 {0}", bit12);
            if (bit11 == 0)
            {
                fakeNumber = fakeNumber & (~((uint)1 << fakeSecondBit));
            }
            else if (bit11 == 1)
            {
                fakeNumber = fakeNumber | ((uint)1 << fakeSecondBit);
            }

            fakeSecondBit++;
        }        
        
        for (int i = secondBit; i <= secondEnd; i++)
        {
            uint bit12 = (number & ((uint)1 << i)) >> i;
            //Console.WriteLine("bit {0}",bit21);  
            //bit22 = (number & ((uint)1 << fakeFirstBit)) >> fakeFirstBit;
            //Console.WriteLine("bit1 {0}", bit22);
            if (bit12 == 0)
            {
                fakeNumber = fakeNumber & (~((uint)1 << fakeFirstBit));
            }
            else if (bit12 == 1)
            {
                fakeNumber = fakeNumber | ((uint)1 << fakeFirstBit);
            }
            fakeFirstBit++;
        }
        Console.WriteLine(fakeNumber);    
    }
}

