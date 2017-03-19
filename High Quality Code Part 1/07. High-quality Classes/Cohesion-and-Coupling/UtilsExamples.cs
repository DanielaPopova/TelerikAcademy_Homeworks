namespace CohesionAndCoupling
{
    using System;
        
    using Models;
    using Utilities;

    public class UtilsExamples
    {
        public static void Main()
        {
            // Throws exception
            // Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            // Throws exception
            // Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Geometry2DUtils.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Geometry3DUtils.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            var figure3D = new Figure3D(3, 4, 5);
            
            Console.WriteLine("Volume = {0:f2}", figure3D.Volume);
            Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry3DUtils.CalculateDiagonalXYZ(figure3D));
            Console.WriteLine("Diagonal XY = {0:f2}", Geometry2DUtils.CalculateDiagonalXY(figure3D));
            Console.WriteLine("Diagonal XZ = {0:f2}", Geometry2DUtils.CalculateDiagonalXZ(figure3D));
            Console.WriteLine("Diagonal YZ = {0:f2}", Geometry2DUtils.CalculateDiagonalYZ(figure3D));
        }
    }
}