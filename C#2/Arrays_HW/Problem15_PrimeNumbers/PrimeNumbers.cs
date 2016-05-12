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

