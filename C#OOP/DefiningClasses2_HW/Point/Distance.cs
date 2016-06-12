namespace Point
{
    using System;

    public static class Distance
    {
        public static double CalculateDistance(Point3D pointA, Point3D pointB)
        {
            double distance = Math.Sqrt(
                (pointB.X - pointA.X) * (pointB.X - pointA.X) +
                (pointB.Y - pointA.Y) * (pointB.Y - pointA.Y) +
                (pointB.Z - pointA.Z) * (pointB.Z - pointA.Z));

            return distance;
        }
    }
}

/*
Online calculator
http://www.calculatorsoup.com/calculators/geometry-solids/distance-two-points.php
*/