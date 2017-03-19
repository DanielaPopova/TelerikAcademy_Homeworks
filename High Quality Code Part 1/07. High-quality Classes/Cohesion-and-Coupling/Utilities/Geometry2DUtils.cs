namespace CohesionAndCoupling.Utilities
{
    using System;

    using Contracts;

    public static class Geometry2DUtils
    {
        public static double CalculateDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalculateDiagonalXY(IFigure3D figure)
        {
            double distance = CalculateDistance2D(0, 0, figure.Width, figure.Height);
            return distance;
        }

        public static double CalculateDiagonalXZ(IFigure3D figure)
        {
            double distance = CalculateDistance2D(0, 0, figure.Width, figure.Depth);
            return distance;
        }

        public static double CalculateDiagonalYZ(IFigure3D figure)
        {
            double distance = CalculateDistance2D(0, 0, figure.Height, figure.Depth);
            return distance;
        }
    }
}
