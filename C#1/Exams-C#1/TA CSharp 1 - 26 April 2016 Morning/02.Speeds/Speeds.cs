using System;

class Speeds
{
    static void Main()  /* 95/100 bgcoder (test17) */
    {
        int length = int.Parse(Console.ReadLine());
        int[] allSpeeds = new int[length];

        for (int i = 0; i < length; i++)
        {
            allSpeeds[i] = int.Parse(Console.ReadLine());
        }
       
        int currCount = 0;
        int currSum = 0;
        int bestSum = 0;
        bool enterLongestSequence = false;

        for (int i = 0; i < allSpeeds.Length - 1; i++)
        {
            int currSpeed = allSpeeds[i];

            if (currSpeed < allSpeeds[i + 1])
            {
                enterLongestSequence = true;
                currCount++;

                if (currCount == 1)
                {
                    currSum = allSpeeds[i];
                }

                currSum += allSpeeds[i + 1];

                if (currSum > bestSum)
                {
                    bestSum = currSum;
                }

                allSpeeds[i + 1] = currSpeed;
            }
            else
            {
                currSum = 0;
                currCount = 0;
            }            
        }

        if (!enterLongestSequence)
        {
            bestSum = allSpeeds[0];
        }

        Console.WriteLine(bestSum);
    }
}

