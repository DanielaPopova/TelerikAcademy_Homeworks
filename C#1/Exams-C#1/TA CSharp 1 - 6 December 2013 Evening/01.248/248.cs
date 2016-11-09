using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        long numA = long.Parse(Console.ReadLine());
        int codeB = int.Parse(Console.ReadLine());
        long numC = long.Parse(Console.ReadLine());
        
        long result = 0;       

        if (codeB == 2)
        {
            result = numA % numC;
        }
        else if (codeB == 4)
        {
            result = numA + numC;
        }
        else if (codeB == 8)
        {
            result = numA * numC;
        }

        if (result % 4 == 0)
        {
            Console.WriteLine(result / 4);
        }
        else
        {
            Console.WriteLine(result % 4);
        }

        Console.WriteLine(result);
    }
}

