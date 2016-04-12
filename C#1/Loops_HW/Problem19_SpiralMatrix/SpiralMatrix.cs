/*
Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20)
and prints a matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below.
Examples:

n = 2   matrix      n = 3   matrix      n = 4   matrix
        1 2                 1 2 3               1  2  3  4
        4 3                 8 9 4               12 13 14 5
                            7 6 5               11 16 15 6
                                                10 9  8  7
*/

using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.WriteLine("Enter positive integer number in range [1...20]");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        int i = 1;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = i++;
                if (i == n)
                {
                    matrix[row++, col] = i++;
                }
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}

