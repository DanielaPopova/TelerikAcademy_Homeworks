using System;
using System.IO;

class MaximalAreaSum
{
    static void Main()
    {

        Console.WriteLine("Enter size of matrix [NxN]");
        int N = int.Parse(Console.ReadLine());

        StreamReader readMatrix = new StreamReader("../../matrix.txt");
        int[,] matrix = GetMatrix(readMatrix, N);
        PrintMatrix(matrix);
        int result = FindMaxSum(matrix);
        Console.WriteLine("Maximal sum is: {0}", result);
        
    }

    static int[,] GetMatrix(StreamReader reader, int size)
    {
        using (reader) 
        {
            int[,] matrix = new int[size, size];
            string lineNums = string.Empty;

            for (int row = 0; row < size; row++)           //Removing whitespaces
            {
                lineNums = reader.ReadLine();
                string[] numbers = lineNums.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);
                }
            }

            return matrix;
        }
    }

    static void PrintMatrix(int[,] matrix) 
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    static int FindMaxSum(int[,] matrix)
    {
        int sum = int.MinValue;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {            
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (sum < currSum)
                {
                    sum = currSum;
                }
            }
        }

        return sum;
    }
}

/*
Write a program that reads a text file containing a square matrix of numbers.
Find an area of size 2 x 2 in the matrix, with a maximal sum of its elements.
The first line in the input file contains the size of matrix N.
Each of the next N lines contain N numbers separated by space.
The output should be a single number in a separate text file.
Example:

input	    output
4 
2 3 3 4     17
0 2 3 4 
3 7 1 2 
4 3 3 2	

*/