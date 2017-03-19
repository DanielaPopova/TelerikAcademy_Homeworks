namespace QualityMethods
{
    using System;

    using QualityMethods.Enums;

    public static class NumberCalculation
    {
        public static string NumberToDigit(int number)
        {
            string[] numbersAsDigits = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            if (number < 0 || number > 9)
            {
                throw new ArgumentOutOfRangeException("Input number is not a digit [0 - 9]!");
            }

            return numbersAsDigits[number];
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Invalid elements!");
            }

            int maxNumber = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }

            return maxNumber;
        }

        public static void PrintAsNumber(object number, NumberFormatType format)
        {
            ValidateNumber(number);

            switch (format)
            {
                case NumberFormatType.FixedPoint:
                    Console.WriteLine("Number with fixed-point: {0:f2}", number);
                    break;
                case NumberFormatType.Percent:
                    Console.WriteLine("Number as percent: {0:p0}", number);
                    break;
                case NumberFormatType.RightAligned:
                    Console.WriteLine("Number right aligned: {0,8}", number);
                    break;
                default:
                    throw new InvalidOperationException("Invalid format!");
            }           
        }

        private static void ValidateNumber(object number)
        {
            if (!(number is sbyte) &&
                !(number is byte) &&
                !(number is short) &&
                !(number is ushort) &&
                !(number is int) &&
                !(number is uint) &&
                !(number is long) &&
                !(number is ulong) &&
                !(number is float) &&
                !(number is double) &&
                !(number is decimal))
            {
                throw new ArgumentException("Input object is not a number");
            }
        }
    }
}
