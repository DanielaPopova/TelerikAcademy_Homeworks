namespace Assertions_Homework.Utils
{
    using System;
    using System.Diagnostics;

    public static class Search
    {
        public static int BinarySearch<T>(T[] array, T value)
           where T : IComparable<T>
        {
            Debug.Assert(array != null && array.Length > 0, "Array cannot be null or empty!");

            int index = BinarySearch(array, value, 0, array.Length - 1);

            Debug.Assert(index < array.Length, "Found index cannot be bigger than array length!");

            return index;
        }

        private static int BinarySearch<T>(T[] array, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(array != null && array.Length > 0, "Array cannot be null or empty!");

            while (startIndex <= endIndex)
            {
                Debug.Assert(startIndex >= 0 && startIndex < array.Length, "Start index is out of the array range!");
                Debug.Assert(endIndex >= 0 && endIndex < array.Length, "End index is out of the array range!");

                int midIndex = (startIndex + endIndex) / 2;
                if (array[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (array[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}
