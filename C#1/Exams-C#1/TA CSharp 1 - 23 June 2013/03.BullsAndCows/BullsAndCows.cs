using System;
using System.Collections.Generic;

class BullsAndCows
{
    static void Main()
    {
        int secretNum = int.Parse(Console.ReadLine());
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());

        bool foundNumber = false;

        for (int currNum = 1000; currNum <= 9999; currNum++)
        {
            int currBulls = 0;
            int currCows = 0;

            int tempCurrNum = currNum;

            int currNumD = tempCurrNum % 10;
            tempCurrNum /= 10;
            int currNumC = tempCurrNum % 10;
            tempCurrNum /= 10;
            int currNumB = tempCurrNum % 10;
            tempCurrNum /= 10;
            int currNumA = tempCurrNum % 10;

            int tempSecretNum = secretNum;

            int secretNumD = tempSecretNum % 10;
            tempSecretNum /= 10;
            int secretNumC = tempSecretNum % 10;
            tempSecretNum /= 10;
            int secretNumB = tempSecretNum % 10;
            tempSecretNum /= 10;
            int secretNumA = tempSecretNum % 10;

            if (currNumA == 0 || currNumB == 0 || currNumC == 0 || currNumD == 0)
            {
                continue;
            }

            //find bulls
            if (currNumA == secretNumA)
            {
                currBulls++;
                currNumA = -1;
                secretNumA = -2;
            }

            if (currNumB == secretNumB)
            {
                currBulls++;
                currNumB = -1;
                secretNumB = -2;
            }

            if (currNumC == secretNumC)
            {
                currBulls++;
                currNumC = -1;
                secretNumC = -2;
            }

            if (currNumD == secretNumD)
            {
                currBulls++;
                currNumD = -1;
                secretNumD = -2;
            }

           //find cows
            var list = new List<int>();

            if (currNumA > 0) list.Add(currNumA);
            if (currNumB > 0) list.Add(currNumB);
            if (currNumC > 0) list.Add(currNumC);
            if (currNumD > 0) list.Add(currNumD);

            if (list.Contains(secretNumA))
            {
                list.Remove(secretNumA);
                currCows++;
            }

            if (list.Contains(secretNumB))
            {
                list.Remove(secretNumB);
                currCows++;
            }

            if (list.Contains(secretNumC))
            {
                list.Remove(secretNumC);
                currCows++;
            }

            if (list.Contains(secretNumD))
            {
                list.Remove(secretNumD);
                currCows++;
            }            

            if (currBulls == bulls && currCows == cows)
            {
                foundNumber = true;
                Console.Write("{0} ", currNum);
            }
        }

        if (foundNumber == false)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine();
        }
    }
}

 //find cows
//if (currNumA == secretNumB)
//{
//    currCows++;
//    currNumA = -1;
//    secretNumB = -2;
//}

//if (currNumA == secretNumC)
//{
//    currCows++;
//    currNumA = -1;
//    secretNumC = -2;
//}

//if (currNumA == secretNumD)
//{
//    currCows++;
//    currNumA = -1;
//    secretNumD = -2;
//}

//if (currNumB == secretNumA)
//{
//    currCows++;
//    currNumB = -1;
//    secretNumA = -2;
//}

//if (currNumB == secretNumC)
//{
//    currCows++;
//    currNumB = -1;
//    secretNumC = -2;
//}

//if (currNumB == secretNumD)
//{
//    currCows++;
//    currNumB = -1;
//    secretNumD = -2;
//}

//if (currNumC == secretNumA)
//{
//    currCows++;
//    currNumC = -1;
//    secretNumA = -2;
//}

//if (currNumC == secretNumB)
//{
//    currCows++;
//    currNumC = -1;
//    secretNumB = -2;
//}

//if (currNumC == secretNumD)
//{
//    currCows++;
//    currNumC = -1;
//    secretNumD = -2;
//}

//if (currNumD == secretNumA)
//{
//    currCows++;
//    currNumD = -1;
//    secretNumA = -2;
//}

//if (currNumD == secretNumB)
//{
//    currCows++;
//    currNumD = -1;
//    secretNumB = -2;
//}

//if (currNumD == secretNumC)
//{
//    currCows++;
//    currNumD = -1;
//    secretNumC = -2;
//}

