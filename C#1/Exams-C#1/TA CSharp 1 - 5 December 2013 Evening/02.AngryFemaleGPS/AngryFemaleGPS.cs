using System;

class AngryFemaleGPS
{
    static void Main()
    {
        long input = long.Parse(Console.ReadLine());
        string number = input.ToString();

        int oddSum = 0;
        int evenSum = 0;

        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] == '-')
            {
                continue;
            }
            else
            {
                int digit = number[i] - '0';

                if (digit % 2 == 0)
                {
                    evenSum += digit;
                }
                else
                {
                    oddSum += digit;
                }
            }            
        }

        if (evenSum > oddSum)
        {
            Console.WriteLine("right {0}", evenSum);
        }
        else if (evenSum < oddSum)
        {
            Console.WriteLine("left {0}", oddSum);            
        }
        else
        {
            Console.WriteLine("straight {0}", oddSum);
        }
    }
}
// different approach
//using System;

//class AngryFemaleGPS
//{
//    static void Main()
//    {
//        long number = long.Parse(Console.ReadLine());

//        if (number < 0)
//        {
//            number *= -1;
//        }

//        int length = 1;        
//        long oddSum = 0;
//        long evenSum = 0;

//        while (number != 0)
//        {
//            int digit = (int)(number % 10);
//            number /= 10;

//            if (digit % 2 == 0)
//            {
//                evenSum += digit;
//            }
//            else
//            {
//                oddSum += digit;
//            }                 
//        }       
      
//        if (evenSum == oddSum)
//        {
//            Console.WriteLine("straight {0}", evenSum);            
//        }
//        else  
//        {
//            if (evenSum > oddSum) 
//            {
//            Console.WriteLine("right {0}", evenSum);
//            }
//            else
//            {
//            Console.WriteLine("left {0}", oddSum);		        
//            }
//        }    
//    }
//}


