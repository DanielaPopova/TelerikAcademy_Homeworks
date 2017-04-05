namespace Problem03_CompareAdvancedMaths
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    public class AdvancedMaths
    {
        private const int MaxIterations = 1000000;
        private const int MaxTimes = 10;
        
        private const float FloatNumber = 2.4f;
        private const double DoubleNumber = 2.4;
        private const decimal DecimalNumber = 2.4m;
        
        private static IList<TimeSpan> allTimeSpansFloat = new List<TimeSpan>();
        private static IList<TimeSpan> allTimeSpansDouble = new List<TimeSpan>();
        private static IList<TimeSpan> allTimeSpansDecimal = new List<TimeSpan>();

        public static void Main()
        {
            // Square Root
            AddToTimeSpanLists(GetPerformanceForSquareRoot);

            Console.WriteLine("Average TimeSpan for Square Root with float/double/decimal:");
            PrintResults();

            // Natural Logarithm
            ClearLists();
            AddToTimeSpanLists(GetPerformanceForLogarithm);

            Console.WriteLine("Average TimeSpan for Natural Logarithm with float/double/decimal:");
            PrintResults();

            // Sinus
            ClearLists();
            AddToTimeSpanLists(GetPerformanceForSinus);

            Console.WriteLine("Average TimeSpan for Sinus with float/double/decimal:");
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
                allTimeSpansFloat.Add(getPerformance(FloatNumber));
                allTimeSpansDouble.Add(getPerformance(DoubleNumber));
                allTimeSpansDecimal.Add(getPerformance(DecimalNumber));
            }
        }

        private static void ClearLists()
        {            
            allTimeSpansFloat = new List<TimeSpan>();
            allTimeSpansDouble = new List<TimeSpan>();
            allTimeSpansDecimal = new List<TimeSpan>();
        }

        private static void PrintResults()
        {            
            Console.WriteLine(CalculateAverageTimeSpan(allTimeSpansFloat));
            Console.WriteLine(CalculateAverageTimeSpan(allTimeSpansDouble));
            Console.WriteLine(CalculateAverageTimeSpan(allTimeSpansDecimal));
        }

        // Method for Square Root
        private static TimeSpan GetPerformanceForSquareRoot(dynamic number)
        {
            Stopwatch sw = new Stopwatch();            
            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                Math.Sqrt((double)number);
            }

            sw.Stop();

            return sw.Elapsed;
        }

        // Method for Natural Logarithm
        private static TimeSpan GetPerformanceForLogarithm(dynamic number)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                Math.Log((double)number);
            }

            sw.Stop();

            return sw.Elapsed;
        }

        //Method for Sinus
        private static TimeSpan GetPerformanceForSinus(dynamic number)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int times = 0; times < MaxIterations; times++)
            {
                Math.Sin((double)number);
            }

            sw.Stop();

            return sw.Elapsed;
        }
    }
}
