namespace Problem02_CompareSimpleMaths
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;    

    public class SimpleMaths
    {
        private const int MaxIterations = 1000000;
        private const int MaxTimes = 10;

        private const int IntNumber = 42;
        private const long LongNumber = 42L;
        private const float FloatNumber = 2.42f;
        private const double DoubleNumber = 2.42;
        private const decimal DecimalNumber = 2.42m;

        private static IList<TimeSpan> allTimeSpansInt = new List<TimeSpan>();
        private static IList<TimeSpan> allTimeSpansLong = new List<TimeSpan>();
        private static IList<TimeSpan> allTimeSpansFloat = new List<TimeSpan>();
        private static IList<TimeSpan> allTimeSpansDouble = new List<TimeSpan>();
        private static IList<TimeSpan> allTimeSpansDecimal = new List<TimeSpan>();

        public static void Main()
        {
            // Add
            AddToTimeSpanLists(GetPerformanceForAdd);

            Console.WriteLine("Average TimeSpan for Addition with int/long/float/double/decimal:");
            PrintResults();

            // Subtract
            ClearLists();
            AddToTimeSpanLists(GetPerformanceForAdd);

            Console.WriteLine("Average TimeSpan for Subtraction with int/long/float/double/decimal:");
            PrintResults();

            // Multiplication
            ClearLists();
            AddToTimeSpanLists(GetPerformanceForMultiply);

            Console.WriteLine("Average TimeSpan for Multiplication with int/long/float/double/decimal:");
            PrintResults();

            // Division
            ClearLists();
            AddToTimeSpanLists(GetPerformanceForDivide);

            Console.WriteLine("Average TimeSpan for Division with int/long/float/double/decimal:");
            PrintResults();

            // Prefix increment
            ClearLists();
            AddToTimeSpanLists(GetPerformanceForPrefixIncrement);

            Console.WriteLine("Average TimeSpan for Prefix Increment with int/long/float/double/decimal:");
            PrintResults();

            // Postfix increment
            ClearLists();
            AddToTimeSpanLists(GetPerformanceForPostfixIncrement);

            Console.WriteLine("Average TimeSpan for Postfix Increment with int/long/float/double/decimal:");
            PrintResults();
        }

        // Stackoverflow
        private static TimeSpan CalculateAverageTimeSpan(IList<TimeSpan> allTimeSpans)
        {
            double doubleAverageTicks = allTimeSpans.Average(timeSpan => timeSpan.Ticks);
            long longAverageTicks = Convert.ToInt64(doubleAverageTicks);

            return new TimeSpan(longAverageTicks);
        }

        private static void AddToTimeSpanLists(Func<dynamic, TimeSpan> getPerformance)
        {
            for (int i = 0; i < MaxTimes; i++)
            {
                allTimeSpansInt.Add(getPerformance(IntNumber));
                allTimeSpansLong.Add(getPerformance(LongNumber));
                allTimeSpansFloat.Add(getPerformance(FloatNumber));
                allTimeSpansDouble.Add(getPerformance(DoubleNumber));
                allTimeSpansDecimal.Add(getPerformance(DecimalNumber));
            }
        }

        private static void ClearLists()
        {
            allTimeSpansInt = new List<TimeSpan>();
            allTimeSpansLong = new List<TimeSpan>();
            allTimeSpansFloat = new List<TimeSpan>();
            allTimeSpansDouble = new List<TimeSpan>();
            allTimeSpansDecimal = new List<TimeSpan>();
        }

        private static void PrintResults()
        {
            Console.WriteLine(CalculateAverageTimeSpan(allTimeSpansInt));
            Console.WriteLine(CalculateAverageTimeSpan(allTimeSpansLong));
            Console.WriteLine(CalculateAverageTimeSpan(allTimeSpansFloat));
            Console.WriteLine(CalculateAverageTimeSpan(allTimeSpansDouble));
            Console.WriteLine(CalculateAverageTimeSpan(allTimeSpansDecimal));
        }

        // Method for Addition
        private static TimeSpan GetPerformanceForAdd(dynamic number)
        {
            Stopwatch sw = new Stopwatch();
            dynamic result;
            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                result = number + number;
            }

            sw.Stop();

            return sw.Elapsed;
        }
       
        // Method for Subtraction
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

        // Method for Multiplicaiton
        private static TimeSpan GetPerformanceForMultiply(dynamic number)
        {
            Stopwatch sw = new Stopwatch();
            dynamic result;
            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                result = number * number;
            }

            sw.Stop();

            return sw.Elapsed;
        }

        // Method for Division
        private static TimeSpan GetPerformanceForDivide(dynamic number)
        {
            Stopwatch sw = new Stopwatch();
            dynamic result;
            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                result = number / number;
            }

            sw.Stop();

            return sw.Elapsed;
        }

        // Method for Increment - After
        private static TimeSpan GetPerformanceForPostfixIncrement(dynamic number)
        {
            Stopwatch sw = new Stopwatch();            
            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
               number++;
            }

            sw.Stop();

            return sw.Elapsed;
        }

        // Method for Increment - Before
        private static TimeSpan GetPerformanceForPrefixIncrement(dynamic number)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                ++number;
            }

            sw.Stop();

            return sw.Elapsed;
        }
    }
}
