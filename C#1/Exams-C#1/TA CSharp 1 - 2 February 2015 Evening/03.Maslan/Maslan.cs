using System;
using System.Numerics;

namespace _03.Maslan
{
    class Maslan
    {
        static void Main()
        {
            string number = Console.ReadLine();

            int transformation = 0;
            BigInteger product = 1;

            while (number.Length > 1)
            {
                number = number.Substring(0, number.Length - 1);
                int sum = 0;
                

                for (int i = 1; i < number.Length; i += 2)
                {
                    sum += (number[i] - '0');
                }

                product *= sum == 0 ? 1 : sum;
                sum = 0;

                if (number.Length == 1)
                {
                    number = product.ToString();
                    transformation++;
                    product = 1;
                }               

                if (transformation >= 10)
                {
                    break;
                }
            }

            if (transformation < 10)
            {
                Console.WriteLine( transformation);
            }

            Console.WriteLine(number);            
        }
    }
}
