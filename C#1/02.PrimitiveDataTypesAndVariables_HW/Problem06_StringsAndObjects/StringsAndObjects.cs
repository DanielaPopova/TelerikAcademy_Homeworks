/*
Declare two string variables and assign them with Hello and World.
Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval between).
Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).
*/

using System;

class StringsAndObjects
{
    static void Main()
    {
        string firstWord = "Hello";
        string secondWord = "World";
        object concatWords = firstWord + " " + secondWord;
        Console.WriteLine(concatWords);

        string objValue = (string)concatWords;
        Console.WriteLine(objValue);

        //Same with integers, casting should be explicit
        int a = 5;
        int b = 6;
        object sum = a + b;
        Console.WriteLine(sum);

        int intSum = (int)sum;
        Console.WriteLine(intSum);
    }
}

