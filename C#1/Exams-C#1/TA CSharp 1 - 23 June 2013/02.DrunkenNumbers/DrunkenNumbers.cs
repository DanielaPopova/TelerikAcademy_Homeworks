using System;

class DrunkenNumbers
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        int sumVladko = 0;
        int sumMitko = 0;

        for (int i = 0; i < length; i++)
        {
            string number = Console.ReadLine();

            //handle if number is 0
            if (int.Parse(number) == 0)
            {
               continue;
            }

            // clear zeroes and/or minus sign
            char first = number[0];
            int startIndex = 0;

            while (first == '0' || first == '-')
            {
                number = number.Substring(startIndex + 1);
                startIndex = 0;
                first = number[startIndex];
            }
            
            //actual calculation of both sums 
            int currSumVladko = 0;
            int currSumMitko = 0;

            for (int j = 0; j < number.Length; j++)
            {
                int currDigit = number[j] - '0';

                if (number.Length % 2 == 0)
                {
                    if (j < number.Length / 2)
                    {
                        currSumMitko += currDigit;
                    }
                    else
                    {
                        currSumVladko += currDigit;
                    }
                }
                else
                {
                    if (j == number.Length / 2)
                    {
                        currSumMitko += currDigit;
                        currSumVladko += currDigit;
                    }
                    else if (j < number.Length / 2)
                    {
                        currSumMitko += currDigit;
                    }
                    else if (j > number.Length / 2)
                    {
                        currSumVladko += currDigit;
                    }
                }
            }

            sumMitko += currSumMitko;
            sumVladko += currSumVladko;
        }

        if (sumVladko > sumMitko)
        {
            Console.WriteLine("V {0}", sumVladko - sumMitko);
        }
        else if (sumVladko < sumMitko)
        {
            Console.WriteLine("M {0}", sumMitko - sumVladko);
        }
        else
        {
            Console.WriteLine("No {0}", sumMitko + sumVladko);
        }
    }
}

//different approach

//using System;

//class DrunkenNumbers
//{
//    static void Main()
//    {
//        int rounds = int.Parse(Console.ReadLine());
        
//        long mitkoBeers = 0;
//        long vladoBeers = 0;

//        for (int i = 0; i < rounds; i++)
//        {
//           long drunkNum = long.Parse(Console.ReadLine());
//           if (drunkNum < 0)
//           {
//               drunkNum = -drunkNum;
//           }

//           long firstNum = drunkNum / 100000000;          
//           long secondNum = (drunkNum / 10000000) % 10;           
//           long thirdNum = (drunkNum / 1000000) % 10;          
//           long fourthNum = (drunkNum / 100000) % 10;
//           long fifthNum = (drunkNum / 10000) % 10;
//           long sixthNum = (drunkNum / 1000) % 10;
//           long seventhNum = (drunkNum / 100) % 10;
//           long eighthNum = (drunkNum / 10) % 10;
//           long ninthNum = drunkNum % 10;

//            if (drunkNum <= 999999999 && drunkNum >= 100000000)
//            {
//                mitkoBeers += firstNum + secondNum + thirdNum + +fourthNum + +fifthNum;
//                vladoBeers += fifthNum + sixthNum + seventhNum + eighthNum + ninthNum;
//            }
//            else if (drunkNum <= 99999999 && drunkNum >= 10000000)
//            {
//                mitkoBeers += secondNum + thirdNum + +fourthNum + fifthNum;
//                vladoBeers += sixthNum + seventhNum + eighthNum + ninthNum;
//            }
//            else if (drunkNum <= 9999999 && drunkNum >= 1000000)
//            {
//                mitkoBeers += thirdNum + +fourthNum + fifthNum + sixthNum;
//                vladoBeers += sixthNum + seventhNum + eighthNum + ninthNum;
//            }
//            else if (drunkNum <= 999999 && drunkNum >= 100000)
//            {
//                mitkoBeers += fourthNum + fifthNum + sixthNum;
//                vladoBeers += seventhNum + eighthNum + ninthNum;
//            }
//            else if (drunkNum <= 99999 && drunkNum >= 10000)
//            {
//                mitkoBeers += fifthNum + sixthNum + seventhNum;
//                vladoBeers += seventhNum + eighthNum + ninthNum;
//            }
//            else if (drunkNum <= 9999 && drunkNum >= 1000)
//            {
//                mitkoBeers += sixthNum + seventhNum;
//                vladoBeers += eighthNum + ninthNum;
//            }
//            else if (drunkNum <= 999 && drunkNum >= 100)
//            {
//                mitkoBeers += seventhNum + eighthNum;
//                vladoBeers += eighthNum + ninthNum;
//            }
//            else if (drunkNum <= 99 && drunkNum >= 10 )
//            {
//                mitkoBeers += eighthNum;
//                vladoBeers += ninthNum;
//            }
//            else
//            {
//                mitkoBeers += ninthNum;
//                vladoBeers += ninthNum;
//            }
            
//        }

//        if (mitkoBeers > vladoBeers)
//        {
//            Console.WriteLine("M {0}", mitkoBeers - vladoBeers);
//        }
//        else if (mitkoBeers < vladoBeers)
//        {
//            Console.WriteLine("V {0}", vladoBeers - mitkoBeers);
//        }
//        else
//        {
//            Console.WriteLine("No {0}", mitkoBeers + vladoBeers);
//        }       
//    }
//}

