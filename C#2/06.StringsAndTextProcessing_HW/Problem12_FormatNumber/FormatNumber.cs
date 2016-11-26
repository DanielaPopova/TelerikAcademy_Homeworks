using System;

class FormatNumber
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());

        Console.WriteLine("{0, 15}", number.ToString("D"));
        Console.WriteLine("{0, 15}", number.ToString("X"));
        Console.WriteLine("{0, 15}", number.ToString("P"));
        Console.WriteLine("{0, 15}", number.ToString("E"));
    }
}

