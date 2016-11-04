using System;

namespace _05.BitsToBits
{
    class BitsToBits
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            string binaryNumber = string.Empty;
            
            int countOnes = 0;
            int countZeros = 0;

            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());                

                binaryNumber += Convert.ToString(number, 2).PadLeft(30, '0');
            }            
    
            int currentCountOnes = 1;
            int currentCountZeros = 1;

            for (int j = 0; j < binaryNumber.Length - 1; j++)
            {
                char currentSymbol = binaryNumber[j];

                if (currentSymbol == '0' && currentSymbol == binaryNumber[j + 1])
                {
                    currentCountZeros++;

                    if (currentCountZeros >= countZeros)
                    {
                        countZeros = currentCountZeros;
                    }
                }
                else if (currentSymbol == '1' && currentSymbol == binaryNumber[j + 1])
                {
                    currentCountOnes++;

                    if (currentCountOnes >= countOnes)
                    {
                        countOnes = currentCountOnes;
                    }
                }
                else
                {
                    currentCountOnes = 1;
                    currentCountZeros = 1;
                }
            }

            Console.WriteLine(countZeros);
            Console.WriteLine(countOnes);            
        }
    }
}

//autho solution - bitwise

//using System;

//public class SequencesOfBits
//{
//    public static void Main()
//    {
//        int n = int.Parse(Console.ReadLine());

//        int lastBit = -1;

//        int maxSequenceOfZeroes = 0;
//        int currentSequenceOfZeroes = 0;

//        int maxSequenceOfOnes = 0;
//        int currentSequenceOfOnes = 0;

//        for (int i = 0; i < n; i++)
//        {
//            int number = int.Parse(Console.ReadLine());
//            for (int p = 29; p >= 0; p--)
//            {
//                int mask = 1 << p;
//                int numberAndMask = number & mask;
//                int bit = numberAndMask >> p;

//                if (bit == 1)
//                {
//                    if (lastBit == 1)
//                    {
//                        currentSequenceOfOnes++;
//                    }
//                    else
//                    {
//                        currentSequenceOfOnes = 1;
//                    }

//                    maxSequenceOfOnes = Math.Max(maxSequenceOfOnes, currentSequenceOfOnes);
//                }
//                else
//                {
//                    // bit == 0
//                    if (lastBit == 0)
//                    {
//                        currentSequenceOfZeroes++;
//                    }
//                    else
//                    {
//                        currentSequenceOfZeroes = 1;
//                    }

//                    maxSequenceOfZeroes = Math.Max(maxSequenceOfZeroes, currentSequenceOfZeroes);
//                }

//                lastBit = bit;
//            }
//        }

//        Console.WriteLine(maxSequenceOfZeroes);
//        Console.WriteLine(maxSequenceOfOnes);
//    }
//}
