namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Utils
    {
        public static T[] Subsequence<T>(T[] array, int startIndex, int count)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty!");
            }

            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of the array range!");
            }

            if (count < 0)
            {
                count = 0;
            }

            if (startIndex + count > array.Length)
            {
                throw new ArgumentOutOfRangeException("Count cannot exceed array length!");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(array[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("String cannot be null or empty!");
            }

            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("Count cannot exceed string length!");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            if (number <= 1)
            {
                throw new ArgumentException("Prime numbers are bigger than 1!");
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
