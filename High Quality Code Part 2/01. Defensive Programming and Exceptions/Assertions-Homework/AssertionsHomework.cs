namespace Assertions_Homework
{
    using System;

    using Assertions_Homework.Utils;

    public class AssertionsHomework
    {
        public static void Main()
        {
            int[] numbers = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", numbers));           
            Sort.SelectionSort(numbers);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", numbers));

            // Test sorting empty array - will throw exception  
            // SelectionSort(new int[0]);  

            // Test sorting single element array    
            Sort.SelectionSort(new int[1]);

            Console.WriteLine(Search.BinarySearch(numbers, -1000));
            Console.WriteLine(Search.BinarySearch(numbers, 0));
            Console.WriteLine(Search.BinarySearch(numbers, 17));
            Console.WriteLine(Search.BinarySearch(numbers, 10));
            Console.WriteLine(Search.BinarySearch(numbers, 1000));
        }
    }
}