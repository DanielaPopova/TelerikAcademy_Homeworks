using System;

namespace _05.SequencesOfBits
{
    class SequencesOfBits
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            int lastBit = 2;

            int maxCountOnes = 0;
            int maxCountZeroes = 0;

            int currentCountOnes = 0;
            int currentCountZeroes = 0;

            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());                

                for (int j = 29; j >= 0; j--)
                {
                    int bit = (number & (1 << j)) >> j;

                    if (bit == 0)
                    {
                        if (lastBit == 0)
                        {
                            currentCountZeroes++;
                        }
                        else
                        {
                            currentCountZeroes = 1;
                        }

                        maxCountZeroes = Math.Max(maxCountZeroes, currentCountZeroes);
                    }
                    else if (bit == 1)
                    {
                        if (lastBit == 1)
                        {
                            currentCountOnes++;
                        }
                        else
                        {
                            currentCountOnes = 1;
                        }

                        maxCountOnes = Math.Max(maxCountOnes, currentCountOnes);
                    }

                    lastBit = bit;
                }
            }

            Console.WriteLine(maxCountOnes);
            Console.WriteLine(maxCountZeroes);
        }
    }
}
