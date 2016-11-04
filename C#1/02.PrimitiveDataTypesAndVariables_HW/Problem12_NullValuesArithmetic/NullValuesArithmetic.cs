/*
Create a program that assigns null values to an integer and to a double variable.
Try to print these variables at the console.
Try to add some number or the null literal to these variables and print the result.
*/

using System;

class NullValuesArithmetic
{
    static void Main()
    {
        int? nullInt = null;
        double? nullDouble = null;

        Console.WriteLine("Does nullInt have value? -> {0}", nullInt.HasValue);
        Console.WriteLine("Does nullDouble have value? -> {0}", nullDouble.HasValue);

        nullInt = 5;
        nullDouble = 4.5;
        Console.WriteLine("Does nullInt have value? -> {0} -> {1}", nullInt.HasValue, nullInt.Value);
        Console.WriteLine("Does nullDouble have value? -> {0} -> {1}", nullDouble.HasValue, nullDouble.Value);       
    }
}

