namespace QualityMethods
{
    using System;

    public static class GeometricCalculation
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive!");                
            }

            if ((a + b) <= c || (a + c) <= b || (b + c) <= a)
            {
                throw new ArgumentException("You cannot build a trinagle out of these sides!");
            }

            double halfPerimeter = (a + b + c) / 2.0;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return area;
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }
    }
}
