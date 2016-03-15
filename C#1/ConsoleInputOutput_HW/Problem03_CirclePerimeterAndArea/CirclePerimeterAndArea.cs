/*
Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.
Examples:

r	    perimeter	area
2	    12.57	    12.57
3.5	    21.99	    38.48
*/

using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Write("Enter the radius of the circle: ");
        double radius = double.Parse(Console.ReadLine());

        double perimeter = 2 * Math.PI * radius;
        double area = Math.PI * radius * radius;

        Console.WriteLine("Perimeter p = {0: 0.00}", perimeter);
        Console.WriteLine("Area a = {0: 0.00}", area);
    }
}

