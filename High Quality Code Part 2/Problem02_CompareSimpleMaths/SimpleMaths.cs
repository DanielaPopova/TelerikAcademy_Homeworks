using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem02_CompareSimpleMaths
{
    public class SimpleMaths
    {
        private const int MaxIterations = 1000000;
        private const int MaxTimes = 10;

        private const int intNumber = 42;
        private const long longNumber = 1234567890;
        private const float floatNumber = 2.4242f;
        private const double doubleNumber = 2.4242;
        private const decimal decimalNumber = 2.4242m;

        public static void Main(string[] args)
        {
            var allTimeSpansInt = new List<TimeSpan>();
            var allTimeSpansLong = new List<TimeSpan>();
            var allTimeSpansFloat = new List<TimeSpan>();
            var allTimeSpansDouble = new List<TimeSpan>();
            var allTimeSpansDecimal = new List<TimeSpan>();

            var timeSpansAverage = new List<TimeSpan>();

            // Add
            for (int i = 0; i < MaxTimes; i++)
            {
                allTimeSpansInt.Add(GetPerformanceForAddWithInt(intNumber));
                allTimeSpansLong.Add(GetPerformanceForAddWithLong(longNumber));
                allTimeSpansFloat.Add(GetPerformanceForAddWithFloat(floatNumber));
                allTimeSpansDouble.Add(GetPerformanceForAddWithDouble(doubleNumber));
                allTimeSpansDecimal.Add(GetPerformanceForAddWithDecimal(decimalNumber));
            }

            Console.WriteLine("Average TimeSpan for Add with int: {0}", CalculateAverageTimeSpan(allTimeSpansInt));
            Console.WriteLine("Average TimeSpan for Add with long: {0}", CalculateAverageTimeSpan(allTimeSpansLong));
            Console.WriteLine("Average TimeSpan for Add with float: {0}", CalculateAverageTimeSpan(allTimeSpansFloat));
            Console.WriteLine("Average TimeSpan for Add with double: {0}", CalculateAverageTimeSpan(allTimeSpansDouble));
            Console.WriteLine("Average TimeSpan for Add with decimal: {0}", CalculateAverageTimeSpan(allTimeSpansDecimal));

            // Subtract
            allTimeSpansInt = new List<TimeSpan>();
            allTimeSpansLong = new List<TimeSpan>();
            allTimeSpansFloat = new List<TimeSpan>();
            allTimeSpansDouble = new List<TimeSpan>();
            allTimeSpansDecimal = new List<TimeSpan>();

            for (int i = 0; i < MaxTimes; i++)
            {
                allTimeSpansInt.Add(GetPerformanceForSubtract(intNumber));
                allTimeSpansLong.Add(GetPerformanceForSubtract(longNumber));
                allTimeSpansFloat.Add(GetPerformanceForSubtract(floatNumber));
                allTimeSpansDouble.Add(GetPerformanceForSubtract(doubleNumber));
                allTimeSpansDecimal.Add(GetPerformanceForSubtract(decimalNumber));
            }

            Console.WriteLine("Average TimeSpan for Subtract with int: {0}", CalculateAverageTimeSpan(allTimeSpansInt));
            Console.WriteLine("Average TimeSpan for Subtract with long: {0}", CalculateAverageTimeSpan(allTimeSpansLong));
            Console.WriteLine("Average TimeSpan for Subtract with float: {0}", CalculateAverageTimeSpan(allTimeSpansFloat));
            Console.WriteLine("Average TimeSpan for Subtract with double: {0}", CalculateAverageTimeSpan(allTimeSpansDouble));
            Console.WriteLine("Average TimeSpan for Subtract with decimal: {0}", CalculateAverageTimeSpan(allTimeSpansDecimal));

        }

        // Stackoverflow
        private static TimeSpan CalculateAverageTimeSpan(IList<TimeSpan> allTimeSpans)
        {
            double doubleAverageTicks = allTimeSpans.Average(timeSpan => timeSpan.Ticks);
            long longAverageTicks = Convert.ToInt64(doubleAverageTicks);

            return new TimeSpan(longAverageTicks);
        }

        // Methods for Add
        private static TimeSpan GetPerformanceForAddWithInt(int number)            
        {
            Stopwatch sw = new Stopwatch();
            int result;

            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                result = number + number;
            }

            sw.Stop();

            return sw.Elapsed;
        }

        private static TimeSpan GetPerformanceForAddWithLong(long number)
        {
            Stopwatch sw = new Stopwatch();
            long result;

            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                result = number + number;
            }

            sw.Stop();

            return sw.Elapsed;
        }

        public static TimeSpan GetPerformanceForAddWithFloat(float number)
        {
            Stopwatch sw = new Stopwatch();
            float result;

            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                result = number + number;
            }

            sw.Stop();

            return sw.Elapsed;
        }

        private static TimeSpan GetPerformanceForAddWithDouble(double number)
        {
            Stopwatch sw = new Stopwatch();
            double result;

            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                result = number + number;
            }

            sw.Stop();

            return sw.Elapsed;
        }

        private static TimeSpan GetPerformanceForAddWithDecimal(decimal number)
        {
            Stopwatch sw = new Stopwatch();
            decimal result;

            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                result = number + number;
            }

            sw.Stop();

            return sw.Elapsed;
        }

        // Method for Subtract using dynamic
        private static TimeSpan GetPerformanceForSubtract(dynamic number)
        {
            Stopwatch sw = new Stopwatch();
            dynamic result;

            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                result = number - number;
            }

            sw.Stop();

            return sw.Elapsed;
        }
    }
}
