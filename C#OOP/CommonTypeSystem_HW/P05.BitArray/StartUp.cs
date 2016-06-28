namespace BitArray
{
    using System;
    using System.Collections.Concurrent;
    using BitArray.Models;

    public class StartUp
    {
        public static void Main()
        {

            var firstArray = new BitArray64(65478456456789);
            Console.WriteLine("Binary representation: " + "\n" + firstArray.ToString());
            Console.WriteLine("First bit = {0}", firstArray[0]);
            Console.WriteLine("Last bit = {0}", firstArray[63]);

            Console.WriteLine(firstArray[0] == firstArray[63]);

            // enumerator
            foreach (var bit in firstArray)
            {
                Console.Write(bit + " ");
            }
            Console.WriteLine();

            // equality of two arrays
            Console.WriteLine("Testing equality");

            var secondArray = new BitArray64(65478456456789);
            var thirdArrray = new BitArray64(65478456456788);

            Console.WriteLine(firstArray.Equals(secondArray) == true ? "arrays have equal elements" : "arrays do not have equal elements");
            Console.WriteLine(firstArray.Equals(thirdArrray) == true ? "arrays have equal elements" : "arrays do not have equal elements");
        }
    }
}
