namespace CohesionAndCoupling.Utilities
{
    using System;

    using Contracts;

    public static class Geometry3DUtils
    {
        public static double CalculateDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalculateDiagonalXYZ(IFigure3D figure)
        {
            double distance = CalculateDistance3D(0, 0, 0, figure.Width, figure.Height, figure.Depth);
            return distance;
        }        
    }
}
