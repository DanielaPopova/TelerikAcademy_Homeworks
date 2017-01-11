namespace BitArray
{
    using System;
    using System.Collections.Concurrent;
    using BitArray.Models;

    public class StartUp
    {
        public static void Main()
        {
            ulong number = 65478456456789;
            var firstArray = new BitArray64(number);
            Console.WriteLine($"First array: {firstArray}");
            Console.WriteLine("First bit = {0}", firstArray[0]);
            Console.WriteLine("Last bit = {0}", firstArray[63]);

            Console.WriteLine($"Are first and last bits equal? {firstArray[0] == firstArray[63]}");

            // enumerator
            Console.WriteLine("\nTesting IEnumerable");
            foreach (var bit in firstArray)
            {
                Console.Write(bit + " ");
            }
            Console.WriteLine();

            // equality of two arrays
            Console.WriteLine("\nTesting equality");

            var secondArray = new BitArray64(65478456456789);
            Console.WriteLine("Second array: {0, 69}", secondArray);
            var thirdArrray = new BitArray64(65478456456788);
            Console.WriteLine("Third array: {0, 70}", thirdArrray);
           
            Console.WriteLine(firstArray.Equals(secondArray) == true ? "first and second arrays have equal elements" : "first and second arrays do not have equal elements");
            Console.WriteLine(firstArray.Equals(thirdArrray) == true ? "first and third arrays have equal elements" : "first and third arrays do not have equal elements");
        }
    }
}
