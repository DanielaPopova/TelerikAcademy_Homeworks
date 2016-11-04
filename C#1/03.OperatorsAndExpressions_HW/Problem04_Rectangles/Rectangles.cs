/*
Write an expression that calculates rectangle’s perimeter and area by given width and height.
Examples:

width	height	perimeter	area
3	      4	      14	    12
2.5	      3	      11	    7.5
5	      5	      20	    25
*/

using System;
using System.Threading;

class Rectangles
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Console.WriteLine("Enter the width of the rectangle: ");
        double width = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the height of the rectangle: ");
        double height = double.Parse(Console.ReadLine());

        double perimeter = (height * 2) + (width * 2);
        double area = height * width;

        Console.WriteLine("The perimeter is {0}", Math.Round(perimeter, 1));
        Console.WriteLine("The area is {0}", Math.Round(area, 1));

    }
}

