/*
Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).
Examples:

x	    y	    inside
0	    1	    true
-2	    0	    true
-1	    2	    false
1.5	    -1	    true
-1.5    -1.5	false
100	    -30	    false
0	    0	    true
0.2	    -0.8	true
0.9	    -1.93	false
1	    1.655	true
*/

using System;
using System.Threading;

class PointInAcircle
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Console.WriteLine("Enter x:");
        float x = float.Parse(Console.ReadLine());

        Console.WriteLine("Enter y:");
        float y = float.Parse(Console.ReadLine());

        float radius = 2;

        if ((x * x) + (y * y) <= radius * radius)
        {
            Console.WriteLine("Is the point inside the circle? -> " + true);
        }
        else
        {
            Console.WriteLine("Is the point inside the circle? -> " + false);
        }        
    }
}

