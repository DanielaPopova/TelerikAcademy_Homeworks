using System;

namespace _01.ABC
{
    class ABC
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int smallest = Math.Min(Math.Min(a, b), c);
            int biggest = Math.Max(Math.Max(a, b), c);
            double avr = (a + b + c) / 3D;

            Console.WriteLine(biggest);
            Console.WriteLine(smallest);
            Console.WriteLine(avr.ToString("F3"));            
        }
    }
}
