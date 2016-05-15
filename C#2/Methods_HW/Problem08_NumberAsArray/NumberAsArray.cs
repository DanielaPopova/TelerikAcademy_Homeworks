using System;
using System.Text;
using System.Collections.Generic;


//TODO: 9 9 9 + 9 9 9 => 8 9 9 ?

class NumberAsArray
{
    static void Main()
    {
        string[] inputLengths = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int firstArrLen = int.Parse(inputLengths[0]);
        int secondArrLen = int.Parse(inputLengths[1]);

        string[] firstRow = Console.ReadLine().Split(' ');
        List<string> firstList = new List<string>();        
        for (int i = 0; i < firstArrLen; i++)
        {
            firstList.Add(firstRow[i]);
        }
        //PrintArray(firstList);

        string[] secondRow = Console.ReadLine().Split(' ');
        List<string> secondList = new List<string>();
        for (int i = 0; i < secondArrLen; i++)
        {
            secondList.Add(secondRow[i]);
        }
        //PrintArray(secondList);

        //string[] firstArray = {"0", "3", "9", "3", "2"};
        //string[] secondArray = { "5", "9", "5", "1", "7" };

        //making both lists with equal lenghts
        int difference = Math.Abs(firstList.Count - secondList.Count);
        if (firstList.Count > secondList.Count)
        {
            for (int i = 0; i < difference; i++)
            {
                secondList.Add("0");
            }
        }
        else if (firstList.Count < secondList.Count)
        {
            for (int i = 0; i < difference; i++)
            {
                firstList.Add("0");
            }
        }

        StringBuilder result = SumArrays(firstList, secondList);

        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i] + " ");
        }        
        
    }

    static StringBuilder SumArrays(List<string> list1, List<string> list2)
    {
        StringBuilder result = new StringBuilder();

        int maxLength = Math.Max(list1.Count, list2.Count);
        int sumDigit = 0;
        int plusOne = 0;        

        for (int i = 0; i < maxLength; i++)
        {
            
                sumDigit = int.Parse(list1[i]) + int.Parse(list2[i]) + plusOne;

                if (sumDigit >= 10)
                {
                    plusOne = sumDigit / 10;
                    sumDigit = sumDigit % 10;                
                }
                else
                {
                    plusOne = 0;
                }

                result.Append(sumDigit);
        }

        return result;
        
    }   

    static void PrintArray(List<string> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();
    }
}


/*
Number as array
Description

Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]). Write a program that reads two arrays representing positive integers and outputs their sum.

Input

On the first line you will receive two numbers separated by spaces - the size of each array
On the second line you will receive the first array
On the third line you will receive the second array
Output

Print the sum as an array of digits (as described)
Digits should be separated by spaces
Constraints

Each of the numbers that will be added could have up to 10 000 digits.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
3 4
8 3 3
6 2 4 2	    4 6 7 2

5 5
0 3 9 3 2
5 9 5 1 7	5 2 5 5 9
*/
