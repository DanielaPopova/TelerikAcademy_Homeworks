using System;

namespace _01.ThreeNumbers
{
    class ThreeNumbers
    {
        static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int smallest = Math.Min(Math.Min(firstNum, secondNum), thirdNum);
            int biggest = Math.Max(Math.Max(firstNum, secondNum), thirdNum);
            double avr = (firstNum + secondNum + thirdNum) / 3D;

            Console.WriteLine(biggest);
            Console.WriteLine(smallest);
            Console.WriteLine("{0:0.00}", avr);
        }
    }
}
