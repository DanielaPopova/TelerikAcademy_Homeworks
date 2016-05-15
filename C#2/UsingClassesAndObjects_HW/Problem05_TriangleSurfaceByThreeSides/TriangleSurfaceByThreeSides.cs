using System;

class TriangleSurfaceByThreeSides
{
    static void Main(string[] args)
    {
        double sideA = double.Parse(Console.ReadLine());
        double sideB = double.Parse(Console.ReadLine());
        double sideC = double.Parse(Console.ReadLine());

        Triangle figure = new Triangle(sideA, sideB, sideC);
        double perimeter = figure.CalculateHalfPerimeter();
        double area = figure.CalculateArea(perimeter);

        Console.WriteLine("{0:F2}", area);
    }

    public class Triangle
    {
        double sideA;
        double sideB;
        double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public double CalculateHalfPerimeter()
        { 
            double perimeter = (this.sideA + this.sideB + this.sideC) / 2D;
            return perimeter;
        }

        public double CalculateArea(double parameter)
        {
            double area = Math.Sqrt(parameter * (parameter - this.sideA) * (parameter - this.sideB) * (parameter - sideC));
            return area;
        }
    }
}

/*
Description

Write program that calculates the surface of a triangle by given its three sides.

Input

On the first line you will receive the length of the first side of the triangle
On the second line you will receive the length of the second side of the triangle
On the third line you will receive the length of the third side of the triangle
Output

Print the surface of the rectangle with two digits of precision
Constraints

Input data describes a valid triangle
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
11
12      61.48
13	    
*/