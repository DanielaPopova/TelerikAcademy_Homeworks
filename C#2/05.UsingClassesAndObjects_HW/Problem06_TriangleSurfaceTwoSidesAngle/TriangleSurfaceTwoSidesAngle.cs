using System;

class TriangleSurfaceTwoSidesAngle
{
    static void Main(string[] args)
    {
        double sideA = double.Parse(Console.ReadLine());
        double sideB = double.Parse(Console.ReadLine());
        double angleGrad = double.Parse(Console.ReadLine());        

        Triangle figure = new Triangle(sideA, sideB, angleGrad);

        double area = figure.CalculateArea();
        Console.WriteLine("{0:F2}", area);
    }  

    public class Triangle
    {
        double sideA;
        double sideB;
        double angleRad;

        public Triangle(double sideA, double sideB, double angleGrad)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.angleRad = angleGrad * Math.PI / 180;
        }        

        public double CalculateArea()
        {            
            double area = (this.sideA * this.sideB * Math.Sin(this.angleRad)) / 2;

            return area;
        }        
    }
}
/*
Description

Write program that calculates the surface of a triangle by given two sides and an angle between them.

Input

On the first line you will receive the length of the first side of the triangle
On the second line you will receive the length of the second side of the triangle
On the third line you will receive the angle between the given sides
Angle is given in degrees
Output

Print the surface of the rectangle with two digits of precision
Constraints

Input data describes a valid triangle
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
10
7       14.79
25	
*/
