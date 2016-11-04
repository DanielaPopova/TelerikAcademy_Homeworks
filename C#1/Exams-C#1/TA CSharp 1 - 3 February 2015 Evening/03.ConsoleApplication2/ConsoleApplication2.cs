using System;
using System.Numerics;

namespace _03.ConsoleApplication2
{
    class ConsoleApplication2
    {
        static void Main()
        {
            string input = string.Empty;

            int position = 0;            
            BigInteger first10Product = 1;
            BigInteger finalProduct = 1;
            bool moreThan10 = false;

            while (input != "END")
            {
                input = Console.ReadLine();

                if (input.Equals("END"))
                {
                    break;
                }

                BigInteger currProduct = 1;                

                if (position % 2 == 0)
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        int digit = input[i] - '0';
                        currProduct *= digit == 0 ? 1 : digit;
                    }

                    finalProduct *= currProduct;                                     
                }    

                position++;

                if (position == 10)
                {
                    first10Product = finalProduct;
                    moreThan10 = true;
                    finalProduct = 1;
                }   
            }

            if (moreThan10)
            {
                Console.WriteLine(first10Product);
                Console.WriteLine(finalProduct);
            }
            else
            {
                Console.WriteLine(finalProduct);
            }
        }
    }
}
