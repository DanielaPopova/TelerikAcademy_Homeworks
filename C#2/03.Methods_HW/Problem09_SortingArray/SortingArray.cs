using System;

class SortingArray
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        string[] inputNums = Console.ReadLine().Split(' ');

        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = int.Parse(inputNums[i]);
        }

        SortArray(array);

    }

    static int FindMaxElementInRange(int[] array, int startIndex)
    {
        int maxElement = array[startIndex];
        for (int i = startIndex; i < array.Length; i++)
        {
            if (array[i] > maxElement)
            {
                maxElement = array[i];
            }
        }

        return maxElement;
    }

    static int FindIndex(int[] array)
    {
        int maxIndex = 0;
        int maxElement = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maxElement)
            {
                maxElement = array[i];
                maxIndex = i;
            }
        }

        return maxIndex;
    }

    static void SortArray(int[] array)
    {
        int[] sortedArray = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            int maxIndex = FindIndex(array);
            sortedArray[sortedArray.Length - 1 - i] = FindMaxElementInRange(array, 0);
            array[maxIndex] = int.MinValue;
        }

        for (int i = 0; i < sortedArray.Length; i++)
        {
            Console.Write(sortedArray[i] + " ");
        }
    }
}
/*using System;

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }

        Array.Reverse(SortArrayDescending(numbers));

        Console.WriteLine(String.Join(" ", numbers));
    }

    static int[] MaxElementAndIndex(int[] array, int startIndex)
    {
        int[] result = new int[2];  //container for both maximal element and its index

        int maxElement = array[startIndex];
        int maxElementIndex = startIndex;

        for (int i = startIndex; i < array.Length; i++)
        {
            if (array[i] > maxElement)
            {
                maxElement = array[i];
                maxElementIndex = i;
            }
        }

        result[0] = maxElement;
        result[1] = maxElementIndex;

        return result;
    }

    static int[] SortArrayDescending(int[] array)
    {
        
        for (int i = 0; i < array.Length; i++)
        {
            int[] elementAndIndex = MaxElementAndIndex(array, i);
            int maxNum = elementAndIndex[0];
            int maxNumIndex = elementAndIndex[1];
            array[maxNumIndex] = array[i];
            array[i] = maxNum;
        }

        return array;
    }     
}
*/
