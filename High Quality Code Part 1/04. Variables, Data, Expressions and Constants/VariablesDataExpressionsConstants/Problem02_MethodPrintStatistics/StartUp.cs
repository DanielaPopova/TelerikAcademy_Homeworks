namespace StatisticalAnalysis
{
    using Providers;
    
    public class StartUp
    {
        public static void Main()
        {
            var writer = new ConsoleWriter();
            double[] numbers = new double[] { 2.5, 15, 3.14, 4, 8 };

            Statistics.PrintStatistics(numbers, writer);
        }
    }
}
