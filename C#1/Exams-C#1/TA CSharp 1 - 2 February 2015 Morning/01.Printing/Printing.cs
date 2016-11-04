using System;

namespace _01.Printing
{
    class Printing
    {
        static void Main()
        {
            int students = int.Parse(Console.ReadLine());
            int sheetsPerStudent = int.Parse(Console.ReadLine());
            double realmPrice = double.Parse(Console.ReadLine());

            double totalSum = students * (sheetsPerStudent / 500D) * realmPrice;

            Console.WriteLine(totalSum.ToString("F2"));
        }
    }
}
