using System;

class MaximalSum
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        int[,] matrix = new int[rows, cols];
        int maxSum = int.MinValue;

        for (int row = 0; row < rows; row++)
        {
            string[] elements = Console.ReadLine().Split(' ');
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = int.Parse(elements[col]);
            }
        }

        int currSum = 0;
        for (int row = 0; row < rows - 2; row++)
        {
            for (int col = 0; col < cols - 2; col++)
            {
                currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                           matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                           matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                }
            }
        }
        Console.WriteLine(maxSum);
    }
}

