using System;
using System.Numerics;

namespace _03.ConsoleApplication1
{
    class ConsoleApplication
    {
        static void Main()
        {
            string input = String.Empty;
            
            int position = 0;
            BigInteger finalProduct = 1;
            BigInteger secondProduct = 1;
            bool moreThanTen = false;

            while (input != "END")
            {
                input = Console.ReadLine();
                BigInteger product = 1;

                if (input == "END")
                {
                    break;
                }

                if (position % 2 == 1)
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        int digit = input[i] - '0';

                        product *= digit == 0 ? 1 : digit; 
                    }

                    finalProduct *= product;
                }

                if (position == 10)
                {
                    secondProduct = finalProduct;
                    finalProduct = 1;
                    moreThanTen = true;                    
                }

                position++;                
            }

            if (!moreThanTen)
            {
                Console.WriteLine(finalProduct);
            }
            else
            {
                Console.WriteLine(secondProduct);
                Console.WriteLine(finalProduct);
            }
        }
    }
}
