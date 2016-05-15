using System;

class RandomNumbers
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        int countRandomNumbers = int.Parse(Console.ReadLine());

        PrintRandomNumbers(start, end, countRandomNumbers);
    }

    static void PrintRandomNumbers(int start, int end, int count)
    {        
        if (start > end)
        {
            int temp = start;
            start = end;
            end = temp;
        }
        Random rndGen = new Random();
        for (int i = 0; i < count; i++)
        {
            int number = rndGen.Next(start, end + 1);
            Console.WriteLine(number);
        }
    }
}

