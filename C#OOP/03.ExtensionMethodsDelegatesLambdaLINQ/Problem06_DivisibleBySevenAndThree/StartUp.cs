namespace Problem6_DivisibleBySevenAndThree
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var intArray = new int[] { 3, 5, 14, 28, 7, 21, 105, 42 };

            var divisibleNumbers = intArray
                .Where(n => n % 21 == 0);
                //.ToArray(); not necessary

            foreach (var number in divisibleNumbers)
            {
                Console.Write(number + " ");
            }
						
            Console.WriteLine("\nUsing LINQ query keywords");

            // using LINQ
            var divisibleWithLinq =
                from numbers in intArray
                where numbers % 21 == 0
                select numbers;

            foreach (var number in divisibleWithLinq)
            {
                Console.Write(number + " ");
            }
        }
    }
}