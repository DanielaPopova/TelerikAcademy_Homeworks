/*
Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5.
Print the obtained array on the console.
*/

using System;

class AllocateArray
{
    static void Main()
    {
        int lenght = int.Parse(Console.ReadLine());
        int[] intArray = new int[lenght];

        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = i * 5;
            Console.WriteLine(intArray[i]);
        }
    }
}

