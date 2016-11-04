/*
You are given an array of strings. Write a method that sorts the array
by the length of its elements (the number of characters composing them).
*/

using System;
using System.Collections.Generic;

class SortByStringLength
{
    static void Main(string[] args)
    {
        int len = int.Parse(Console.ReadLine());
        string[] array = new string[len];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Console.ReadLine();
        }

        //string[] array = { "az", "daniela", "mira", "metropolitan", "vreme" };

        int swapIndex = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            int shortestCount = array[i].Length;
            string shortestWord = array[i];
            bool isFound = false;
            int countFound = 0;
            for (int j = i + 1; j < array.Length; j++)
            {                
                int currentCount = array[j].Length;               

                if (shortestCount > currentCount)
                {
                    shortestCount = currentCount;
                    shortestWord = array[j];
                    swapIndex = j;                    
                    isFound = true;
                    countFound++;
                }
                else
                {
                    currentCount = array[j].Length;
                    isFound = false;
                }
            }
            if (isFound || countFound >= 1)
            {
                array[swapIndex] = array[i];                
            }
            array[i] = shortestWord; 
        }

        foreach (var elements in array)
        {
            Console.WriteLine(elements);
        }
    }
}

