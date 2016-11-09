using System;

class Secrets
{
    static void Main()
    {
        string number = Console.ReadLine();

        if (number[0] == '-')
        {
            number = number.Substring(1);
        }

        int specialSum = 0;
        int position = 1;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            int digit = number[i] - '0';
            int currSum = 0;

            if (position % 2 == 0)
            {
                currSum += (digit * digit) * position;
            }
            else
            {
                currSum += digit * (position * position);
            }

            specialSum += currSum;
            position++;
        }

        Console.WriteLine(specialSum);
        
        int secretSequenceLength = specialSum % 10;        

        if (secretSequenceLength == 0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", number);
        }
        else
        {            
            int start = specialSum % 26;

            for (int i = 0; i < secretSequenceLength; i++)
            {
                Console.Write((char)('A' + (start + i) % 26));
            }            
        }        
    }
}

//using System;
//using System.Numerics;

//class TheSecretsOfNumbers
//{
//    static void Main()
//    {
//        //1. Math.Floor(Math.Log10(n) + 1); 2. int count = 1; while ((number /= 10) >= 1) { coiunt++; }  --> count of digits in a number

//        BigInteger n = BigInteger.Parse(Console.ReadLine());
//        BigInteger number = n;

//        if (n < 0)
//        {
//            number *= -1;
//        }

//        int specialSum = 0;
//        int position = 1;        

//        while (number > 0)
//        {       
//            int digit = (int) (number % 10);
//            number /= 10;
//            //Console.WriteLine("Digit ==> {0}", digit);

//            if (position % 2 == 0)
//            {
//                specialSum += digit * digit * position;
//            }
//            else
//            {
//                specialSum += digit * position * position;
//            }
//            position++;          
            
//        }
//
//        Console.WriteLine(specialSum);

//        //Console.WriteLine((char)('A' + 0)) --> A;
//        //A - Z ASCII ==> 65 - 90  

//        int length = specialSum % 10;
//        if (length == 0)
//        {            
//            Console.WriteLine("{0} has no secret alpha-sequence", n);
//        }
//        else
//        {
//            int start = specialSum % 26;
//            //Console.WriteLine("Start ==> {0}", start);

//            for (int i = 0; i < length; i++)
//            {                
//                Console.Write((char)('A' + (start + i) % 26));       
//            }
//
//            Console.WriteLine();
//        }        
//    }
//}

