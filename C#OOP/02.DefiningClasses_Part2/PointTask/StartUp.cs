namespace PointTask
{
    using System;

    using AttributeTask;
    using PointTask.Models;

    [Version(1, 1)]
    public class StartUp
    {
        public static void Main()
        {
            var pointA = new Point3D(4, 5, 6);
            var pointB = new Point3D(-1, 0, 3);
            var pointC = new Point3D(0, 2, -4);

            var path = new Path();

            path.AddPoint(pointA);
            path.AddPoint(pointB);
            path.AddPoint(pointC);

            path.DeletePoint(pointC);
            
            Console.WriteLine(path.DisplayPath());

            // Test saving a path with PathStorage -> check SaveTo.txt file
            PathStorage.SavePath(path);

            // Test loading from LoadFrom.txt file
            var newPath = PathStorage.LoadPath();
            Console.WriteLine(newPath.DisplayPath());
        }
    }
}
