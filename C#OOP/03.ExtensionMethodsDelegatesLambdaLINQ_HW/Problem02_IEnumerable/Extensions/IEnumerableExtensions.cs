namespace Problem2_IEnumerable.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;    

    public static class IEnumerableExtensions
    {
        public static decimal Sum<T>(this IEnumerable<T> collection) where T : struct, IFormattable   // boolean type is not included (doesn't implement IFormattable)
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));
            
            decimal result = 0m;

            foreach (var number in decimalCollection)
            {                
                result += number;
            }

            return result;
        }

        public static decimal Product<T>(this IEnumerable<T> collection) where T : struct, IFormattable
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));

            decimal product = 1m;

            foreach (var number in decimalCollection)
            {
                product *= number;
            }

            return product;
        }

        public static decimal Min<T>(this IEnumerable<T> collection) where T : struct, IFormattable
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));

            decimal minValue = decimal.MaxValue;

            foreach (var number in decimalCollection)
            {
                if (minValue > number)
                {
                    minValue = number;
                }
            }

            return minValue;
        }

        public static decimal Max<T>(this IEnumerable<T> collection) where T : struct, IFormattable
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));

            decimal maxValue = decimal.MinValue;

            foreach (var number in decimalCollection)
            {
                if (maxValue < number)
                {
                    maxValue = number;
                }
            }

            return maxValue;
        }

        public static decimal Average<T>(this IEnumerable<T> collection) where T : struct, IFormattable
        {
            return collection.Sum() / collection.Count();
        }
    }
}
