using System;
using System.Numerics;

namespace _03.SaddyKopper
{
    class SaddyKopper
    {
        static void Main()
        {
            string number = Console.ReadLine();
            int transformation = 0;

            while (number.Length > 1 && transformation < 10)
            {
                BigInteger product = 1;

                while (number.Length > 0)
                {
                    number = number.Substring(0, number.Length - 1);
                    BigInteger sum = 0;

                    for (int i = 0; i < number.Length; i += 2)
                    {
                        sum += (number[i] - '0');
                    }

                    product *= sum != 0 ? sum : 1;
                }

                number = product.ToString();
                transformation++;
            }

            if (transformation < 10)
            {
                Console.WriteLine(transformation);
            }

            Console.WriteLine(number);
        }
    }
}

// Author solution
//
//using System;
//using System.Numerics;

//class MagicSadiKopar
//{
//    static void Main()
//    {
//        string text = Console.ReadLine();

//        int transformations = 0;
//        bool transformed = true;
//        while (text.Length > 1)
//        {
//            int sum = 0;
//            BigInteger product = 1;
//            int position = 0;
//            foreach (var symbol in text)
//            {
//                if (position % 2 == 0)
//                {
//                    int number = symbol - '0';
//                    sum += number;
//                }

//                product *= sum;
//                position++;
//            }

//            product /= sum;
//            transformations++;

//            text = product.ToString();

//            if (transformations == 10)
//            {
//                transformed = false;
//                break;
//            }
//        }

//        if (transformed)
//        {
//            Console.WriteLine(transformations);
//            Console.WriteLine(text);
//        }
//        else
//        {
//            Console.WriteLine(text);
//        }
//    }
//}
