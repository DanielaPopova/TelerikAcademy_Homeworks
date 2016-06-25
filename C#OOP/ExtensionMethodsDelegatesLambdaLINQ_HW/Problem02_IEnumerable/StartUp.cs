namespace Problem2_IEnumerable
{
    using System;
    using System.Collections.Generic;
    using Problem2_IEnumerable.Extensions;
    // using System.Numerics; 

    public class StartUp
    {
        public static void Main()
        {
            var testList = new List<int> { 2, 3, 4, 5, 8, 100, 14 };  // doesn't work with BigInteger

            Console.WriteLine(testList.Sum());
            Console.WriteLine(testList.Product());
            Console.WriteLine(testList.Min());
            Console.WriteLine(testList.Max());
            Console.WriteLine("{0:F4}", testList.Average());            
        }
    }
}
