using System;

namespace _01.Money
{
    class Money
    {
        static void Main()
        {
            int students = int.Parse(Console.ReadLine());
            int paperSheets = int.Parse(Console.ReadLine());
            double realmPrice = double.Parse(Console.ReadLine());

            double money = students * (paperSheets / 400D) * realmPrice;

            Console.WriteLine(money.ToString("F3"));
        }
    }
}
