using System;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        string binary = Convert.ToString(number, 2).PadLeft(32, '0');
        
        if (binary.Length > 16)
        {
            binary = binary.Substring(binary.Length - 16, 16);
        }       

        string[] one = new string[] { ".#.", "##.", ".#.", ".#.", "###" };
        string[] zero = new string[] { "###", "#.#", "#.#", "#.#", "###" };

        for (int row = 0; row < 5; row++)
        {            
            for (int i = 0; i < binary.Length; i++)
            {
                int bit = binary[i] - '0';

                if (bit == 1)
                {
                    Console.Write(one[row]);
                }
                else
                {
                    Console.Write(zero[row]);
                }

                if (i != binary.Length - 1)
                {
                    Console.Write('.');
                }
            }

            Console.WriteLine();            
        }
    }
}

//without nested for-s

//using System;

//class OnesAndZeros
//{
//    static void Main()
//    {
//        int num = int.Parse(Console.ReadLine());
//        string bin = Convert.ToString(num, 2).PadLeft(32, '0');

//        //logic

//        string oneRow0 = ".#.";
//        string oneRow1 = "##.";
//        string oneRow2 = ".#.";
//        string oneRow3 = ".#.";
//        string oneRow4 = "###";

//        string zeroRow0 = "###";
//        string zeroRow1 = "#.#";
//        string zeroRow2 = "#.#";
//        string zeroRow3 = "#.#";
//        string zeroRow4 = "###";

//        //row 0
//        for (int i = 16; i < bin.Length; i++)
//        {
//            if (bin[i] == '1')
//            {
//                Console.Write(oneRow0);
//            }
//            else
//            {
//                Console.Write(zeroRow0);
//            }

//            if (i != bin.Length - 1)
//            {
//                Console.Write('.');                
//            }
//        }
//        Console.WriteLine();

//        //row 1
//        for (int i = 16; i < bin.Length; i++)
//        {
//            if (bin[i] == '1')
//            {
//                Console.Write(oneRow1);
//            }
//            else
//            {
//                Console.Write(zeroRow1);
//            }

//            if (i != bin.Length - 1)
//            {
//                Console.Write('.');
//            }
//        }
//        Console.WriteLine();

//        //row 2
//        for (int i = 16; i < bin.Length; i++)
//        {
//            if (bin[i] == '1')
//            {
//                Console.Write(oneRow2);
//            }
//            else
//            {
//                Console.Write(zeroRow2);
//            }

//            if (i != bin.Length - 1)
//            {
//                Console.Write('.');
//            }
//        }
//        Console.WriteLine();

//        //row 3
//        for (int i = 16; i < bin.Length; i++)
//        {
//            if (bin[i] == '1')
//            {
//                Console.Write(oneRow3);
//            }
//            else
//            {
//                Console.Write(zeroRow3);
//            }

//            if (i != bin.Length - 1)
//            {
//                Console.Write('.');
//            }
//        }
//        Console.WriteLine();

//        //row 4
//        for (int i = 16; i < bin.Length; i++)
//        {
//            if (bin[i] == '1')
//            {
//                Console.Write(oneRow4);
//            }
//            else
//            {
//                Console.Write(zeroRow4);
//            }

//            if (i != bin.Length - 1)
//            {
//                Console.Write('.');
//            }
//        }
//        Console.WriteLine();       
//    }
//}

