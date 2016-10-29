using System;

class PrimeNumbers
{
    static void Main()
    {
        //60/100 bgcoder - timeLimit
        int num = int.Parse(Console.ReadLine());

        int[] array = new int[num + 1];
        int maxNum = int.MinValue;

        int count = 2;
        for (int i = 2; i <= num; i++)
        {
            array[i] = count;
            count++;            
        }

        for (int i = 2; i * i <= num; i++)
        {
            for (int j = (i * i); j <= num; j = j + i)
            {
                array[j] = 0;
            }
        }
        Array.Sort(array);
        maxNum = array[array.Length - 1];    
               
        Console.WriteLine(maxNum);
    }
}

// 100/100 bgcoder

//namespace Homeworks
//{
//    using System;

//    class Program
//    {
//        static void Main()
//        {
//            int length = int.Parse(Console.ReadLine());           

//            byte[] isPrime = new byte[length + 1];
//            int biggestPrime = 0;

//            for (int i = 2; i <= length; i++)
//            {
//                if (isPrime[i] == 0)
//                {
//                    biggestPrime = i;

//                    for (int j = i * 2; j <= length; j += i)
//                    {
//                        isPrime[j] = 1;
//                    }
//                }
//            }

//            Console.WriteLine(biggestPrime);
//        }
//    }
//}

