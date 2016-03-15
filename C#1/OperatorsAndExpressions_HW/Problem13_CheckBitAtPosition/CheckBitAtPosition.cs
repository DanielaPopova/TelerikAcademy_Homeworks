/*
Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n, has value of 1.
Examples:

n	    binary representation of n	p	bit @ p == 1
5	        00000000 00000101	    2	    true
0	        00000000 00000000	    9	    false
15	        00000000 00001111	    1	    true
5343	    00010100 11011111	    7	    true
62241	    11110011 00100001	    11	    false
*/

using System;

    class CheckBitAtPosition
    {
        static void Main()
        {
            Console.WriteLine("Enter number");
            int number = int.Parse(Console.ReadLine());

            string binaryRep = Convert.ToString(number, 2);
            Console.WriteLine("Binary representation -> {0}", binaryRep.PadLeft(16, '0'));

            Console.WriteLine("Enter position");
            int position = int.Parse(Console.ReadLine());

            int mask = 1 << position;
            int numNMask = number & mask;
            int bit = numNMask >> position;

            bool isOne = true;

            if (bit == 1)
            {
                Console.WriteLine("Is the bit at position {0} = 1 -> {1}", position, isOne);
            }
            else
            {
                Console.WriteLine("Is the bit at position {0} = 1 -> {1}", position, !isOne);
            }
        }
    }

