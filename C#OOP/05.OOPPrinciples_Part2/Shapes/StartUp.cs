namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using Shapes.Models;

    public class StartUp
    {
        public static void Main()
        {
            // basically the same with array
            var shapeList = new List<Shape>
            {
                new Square(7),
                new Triangle(2, 5),
                new Square(3.5),
                new Rectangle(2, 3),
                new Triangle(6.4, 3),
                new Rectangle(4, 5.5)
            };

            foreach (var shape in shapeList)
            {
                Console.WriteLine(shape);
            }
        }
    }
}
