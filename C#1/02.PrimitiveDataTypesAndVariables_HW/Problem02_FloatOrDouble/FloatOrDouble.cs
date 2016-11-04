/*
Which of the following values can be assigned to a variable of type float and which to a variable of type double:
34.567839023, 12.345, 8923.1234857, 3456.091?
Write a program to assign the numbers in variables and print them to ensure no precision is lost.
*/

using System;

class FloatOrDouble
{
    static void Main()
    {
        double a = 34.567839023;
        float b = 12.345F;
        double c = 8923.1234857;        
        float d = 3456.091F;

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);     
        Console.WriteLine(d);        
    }
}

