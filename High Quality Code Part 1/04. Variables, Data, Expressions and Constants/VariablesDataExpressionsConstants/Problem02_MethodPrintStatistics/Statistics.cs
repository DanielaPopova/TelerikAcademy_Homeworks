namespace StatisticalAnalysis
{
    using Contracts;

    public static class Statistics
    {
        public static void PrintStatistics(double[] collection, IWriter writer)
        {
            double maxValue = CalculateMaxValue(collection);
            double minValue = CalculateMinValue(collection);
            double average = CalculateAverage(collection);

            string maxValueMessage = string.Format("Maximum value is: {0:F2}", maxValue);
            string minValueMessage = string.Format("Minimum value is: {0:F2}", minValue);
            string averageMessage = string.Format("Average value is: {0:F2}", average);

            writer.WriteLine(maxValueMessage);
            writer.WriteLine(minValueMessage);
            writer.WriteLine(averageMessage);
        }

        public static double CalculateMaxValue(double[] collection)
        {
            double maxValue = double.MinValue;

            for (int i = 0; i < collection.Length; i++)
            {
                double currentValue = collection[i];
                if (currentValue > maxValue)
                {
                    maxValue = currentValue;
                }
            }

            return maxValue;
        }

        public static double CalculateMinValue(double[] collection)
        {
            double minValue = double.MaxValue;

            for (int i = 0; i < collection.Length; i++)
            {
                double currentValue = collection[i];
                if (currentValue < minValue)
                {
                    minValue = currentValue;
                }
            }

            return minValue;
        }

        public static double CalculateAverage(double[] collection)
        {            
            double sum = 0;

            for (int i = 0; i < collection.Length; i++)
            {
                sum += collection[i];
            }

            double average = sum / collection.Length;

            return average;
        }
    }
}
