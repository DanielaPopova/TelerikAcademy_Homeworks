using System;

class Patterns
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        long[,] field = new long[n, n];

        for (int row = 0; row < n; row++)
        {
            string[] line = Console.ReadLine().Split(' ');

            for (int col = 0; col < n; col++)
            {
                field[row, col] = int.Parse(line[col]);
            }
        }

        long maxSum = long.MinValue;
        bool foundPattern = false;

        for (int row = 0; row < n - 2; row++)
        {
            for (int col = 0; col < n - 4; col++)
            {
                if (field[row, col] == field[row, col + 1] - 1 &&
                    field[row, col + 1] == field[row, col + 2] - 1 &&
                    field[row, col + 2] == field[row + 1, col + 2] - 1 &&
                    field[row + 1, col + 2] == field[row + 2, col + 2] - 1 &&
                    field[row + 2, col + 2] == field[row + 2, col + 3] - 1 &&
                    field[row + 2, col + 3] == field[row + 2, col + 4] - 1)
                {
                    foundPattern = true;

                    long currSum = field[row, col] + field[row, col + 1] + field[row, col + 2] +
                                  field[row + 1, col + 2] +
                                  field[row + 2, col + 2] + field[row + 2, col + 3] + field[row + 2, col + 4];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                    }
                }                
            }
        }

        if (foundPattern)
        {
            Console.WriteLine("YES {0}", maxSum);
        }
        else
        {
            long diagonalSum = SumDiagonal(field);
            Console.WriteLine("NO {0}", diagonalSum);
        }
    }

    public static long SumDiagonal(long[,] matrix)
    {
        long sum = 0;

        for (int i = 0; i < Math.Min(matrix.GetLength(0), matrix.GetLength(1)); ++i)
        {
            sum += matrix[i, i];
        }

        return sum;
    }
}

