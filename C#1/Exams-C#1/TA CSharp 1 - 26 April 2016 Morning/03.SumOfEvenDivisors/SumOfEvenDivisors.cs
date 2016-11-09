using System;

class SumOfEvenDivisors
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        int evenSum = 0;

        for (int i = start; i <= end; i++)
        {
            int currentNumber = i;

            for (int j = 1; j <= currentNumber; j++)
            {
                if (currentNumber % j == 0 && j % 2 ==0)
                {                    
                    evenSum += j;                    
                }
            }
        }

        Console.WriteLine(evenSum);
    }
}

