using System;

class Program
{
    static void Main()
    {
        long numA = long.Parse(Console.ReadLine());
        int codeB = int.Parse(Console.ReadLine());
        long numC = long.Parse(Console.ReadLine());

        long result = 0;

        if (codeB == 3)
        {
            result = numA + numC;
        }
        else if (codeB == 6)
        {
            result = numA * numC;
        }
        else if (codeB == 9)
        {
            result = numA % numC;
        }

        if (result % 3 ==0)
        {
            Console.WriteLine(result / 3);
        }
        else
        {
            Console.WriteLine(result % 3);
        }

        Console.WriteLine(result);
    }
}

