/*
Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).
Examples:

x	    y	inside K & outside of R
1	    2	        yes
2.5	    2	        no
0	    1	        no
2.5	    1	        no
2	    0	        no
4	    0	        no
2.5	    1.5	        no
2	    1.5	        yes
1	    2.5	        yes
-100    -100	    no
*/

using System;
using System.Threading;

class PointInsideCircleOutsideRectangle
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Console.WriteLine("Enter x");
        double x = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter y");
        double y = double.Parse(Console.ReadLine());

        double radius = 1.5F;

        //(x - h)*(x - h) + (y - k)*(y - k) = r * r, h/k - coordinates of center of circle
        bool insideCircle = ((x - 1) * (x - 1)) + ((y - 1) * (y - 1)) <= radius * radius;
        bool outsideRectangle = ((x > -1) && (x > 5)) || ((y > -1) && (y > 1));

        if (insideCircle && outsideRectangle)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}

