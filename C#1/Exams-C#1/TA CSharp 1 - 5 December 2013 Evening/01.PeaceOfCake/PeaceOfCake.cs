using System;

class PeaceOfCake
{
    static void Main()
    {
        long A = long.Parse(Console.ReadLine());
        long B = long.Parse(Console.ReadLine());
        long C = long.Parse(Console.ReadLine());
        long D = long.Parse(Console.ReadLine());

        long nominator = A * D + B * C;
        long denominator = B * D;

        if (nominator / (decimal)denominator >= 1)
        {
            Console.WriteLine(nominator / denominator);
        }
        else
        {
            Console.WriteLine((nominator / (decimal)denominator).ToString("F22")); 
        }

        Console.WriteLine("{0}/{1}",nominator, denominator);
        // Math.Truncate - The integral part of d; that is, the number that remains after any fractional digits have been discarded.
    }
}

