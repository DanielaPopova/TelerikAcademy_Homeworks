using System;

class AddingPolynomials
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        string[] firstRow = Console.ReadLine().Split(' ');        
        int[] firstArray = InitializeArray(length, firstRow);
        //PrintArray(firstArray);

        string[] secondRow = Console.ReadLine().Split(' ');
        int[] secondArray = InitializeArray(length, secondRow);
        //PrintArray(secondArray);

        int[] result = SumCoefficients(firstArray, secondArray);
        PrintArray(result);
    }
    

    static int[] InitializeArray(int length, string[] inputNumbers)
    {
        int[] numbers = new int[length];
        for (int i = 0; i < inputNumbers.Length; i++)
        {
            numbers[i] = int.Parse(inputNumbers[i]);
        }

        return numbers;
    }

    static int[] SumCoefficients(int[] firstArr, int[] secondArr)
    {
        int length = firstArr.Length;
        int[] newArr = new int[length];
        for (int i = 0; i < length; i++)
        {
            newArr[i] = firstArr[i] + secondArr[i];
        }

        return newArr;
    }

    static void PrintArray(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }
}

/*
Adding polynomials
Description

Write a method that adds two polynomials. Represent them as arrays of their coefficients.
Write a program that reads two polynomials and prints their sum.

Input

On the first line you will receive the number N
On the second line you will receive the first polynomial as coefficients separated by spaces
On the third line you will receive the second polynomial as coefficients separated by spaces
Output

Print the sum of the polynomials
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
  3
5 0 1       12 4 -2
7 4 -3	
Example explanation:

x2 + 5 = 1x2 + 0x + 5 => {5, 0, 1}

-3x2 + 4x + 7 = -3x2 + 4x + 7 => {7, 4, -3}

(x2 + 5) + (-3x2 + 4x + 7) = (-2x2 + 4x + 12) = -2x2 + 4x + 12 => {12, 4, -2}
*/

