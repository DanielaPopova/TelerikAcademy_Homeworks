namespace Assertions_Homework.Utils
{
    using System;
    using System.Diagnostics;

    public static class Sort
    {
        public static void SelectionSort<T>(T[] array)
           where T : IComparable<T>
        {
            Debug.Assert(array.Length > 0, "Array should not be empty!");

            for (int index = 0; index < array.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(array, index, array.Length - 1);
                Swap(ref array[index], ref array[minElementIndex]);
            }
        }

        private static int FindMinElementIndex<T>(T[] array, int startIndex, int endIndex)
           where T : IComparable<T>
        {
            Debug.Assert(array.Length > 0, "Array should not be empty!");

            Debug.Assert(startIndex >= 0, "Start index should be a positive number!");
            Debug.Assert(startIndex < array.Length, "Start index should be smaller than array lenght!");
            Debug.Assert(startIndex <= endIndex, "Start index shuld not be bigger than end index!");

            Debug.Assert(endIndex >= 0, "End index should be a positive number!");
            Debug.Assert(endIndex < array.Length, "End index should be smaller than the array lenght!");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (array[i].CompareTo(array[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            Debug.Assert(minElementIndex >= 0, "minElementIndex should be a positive number!");
            Debug.Assert(minElementIndex < array.Length, "minElementIndex should be smaller than array lenght!");

            return minElementIndex;
        }

        private static void Swap<T>(ref T firstValue, ref T secondValue)
        {
            T oldFirstValue = firstValue;
            firstValue = secondValue;
            secondValue = oldFirstValue;
        }
    }
}
