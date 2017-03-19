namespace QualityMethods
{
    using System;

    using QualityMethods.Enums;

    public class StartUp
    {       
        public static void Main()
        {
            // GeometricCalculation Examples
            Console.WriteLine(GeometricCalculation.CalculateTriangleArea(3, 4, 5));

            double pointAx = 3;
            double pointAy = -1;
            double pointBx = 3;
            double pointBy = 2.5;

            Console.WriteLine(GeometricCalculation.CalculateDistance(pointAx, pointAy, pointBx, pointBy));
            Console.WriteLine("Horizontal? " + (pointAy == pointBy));
            Console.WriteLine("Vertical? " + (pointAx == pointBx));

            // NumberCalculation Examples
            Console.WriteLine(NumberCalculation.NumberToDigit(5));

            Console.WriteLine(NumberCalculation.FindMax(5, -1, 3, 2, 14, 2, 3));

            NumberCalculation.PrintAsNumber(1.3, NumberFormatType.FixedPoint);
            NumberCalculation.PrintAsNumber(0.75, NumberFormatType.Percent);
            NumberCalculation.PrintAsNumber(2.30, NumberFormatType.RightAligned);

            // Student Examples
            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 19), "Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 3, 11), "Vidin", "gamer, high results");            

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
