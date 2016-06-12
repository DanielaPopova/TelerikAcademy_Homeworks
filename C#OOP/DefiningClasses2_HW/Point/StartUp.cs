namespace Point
{
    using System;
    using AttributeTask;

    [Version(1, 1)]
    public class StartUp
    {
        public static void Main()
        {
            // Testing Point
            var pointA = new Point3D();
            pointA.X = 2.5;
            pointA.Y = 3;
            pointA.Z = 4.5;

            var pointB = new Point3D();
            pointB.X = 3.4;
            pointB.Y = -3;
            pointB.Z = 0.6;

            Console.WriteLine(Point3D.Start);
            Console.WriteLine(pointA);

            // Testing Distance
            double distance = Distance.CalculateDistance(pointA, pointB);
            Console.WriteLine("Distance between points: {0:F4}", distance);

            // Testing Path/PathStorage
            Path pathPoints = new Path();
            pathPoints.AddPoint(pointA);
            pathPoints.AddPoint(pointB);

            Console.WriteLine(pathPoints);

            PathStorage.SavePath(pathPoints);

            pathPoints = PathStorage.LoadPath();

            Console.WriteLine(pathPoints);
        }
    }
}