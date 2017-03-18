namespace GeometricFigures
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var size = new Size(5, 4);
            double rotationAngle = 60;
            var rotatedSize = Size.GetRotatedSize(size, rotationAngle);
            Console.WriteLine(rotatedSize);
        }
    }
}
