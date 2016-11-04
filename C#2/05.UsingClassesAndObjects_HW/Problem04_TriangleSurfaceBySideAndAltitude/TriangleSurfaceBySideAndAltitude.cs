using System;

class TriangleSurfaceBySideAndAltitude
{
    static void Main()
    {
        double side = double.Parse(Console.ReadLine());
        double altitude = double.Parse(Console.ReadLine());

        double surface = CalculateTriangleSurface(side, altitude);
        Console.WriteLine("{0:0.00}", surface);
    }

    static double CalculateTriangleSurface(double side, double altitude)
    {
        double surface = (side * altitude) / 2D;

        return surface;
    }
}

/*
Description

Write program that calculates the surface of a triangle by given a side and an altitude to it.

Input

On the first line you will receive the length of a side of the triangle
On the second line you will receive the altitude to that side
Output

Print the surface of the rectangle with two digits of precision
Constraints

Input data describes a valid triangle
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
23.2
5	    58.00
*/

