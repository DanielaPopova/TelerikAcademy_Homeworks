//84/100 bgcoder - timelimit
using System;

class Digits
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = rows;

        int[,] field = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            string[] line = Console.ReadLine().Split(' ');

            for (int col = 0; col < cols; col++)
            {
                field[row, col] = int.Parse(line[col]);
            }
        }

        Console.WriteLine(CountOne(field) + CountTwo(field) + CountThree(field) + CountFour(field) +
                          CountFive(field) + CountSix(field) + CountSeven(field) + CountEight(field) + CountNine(field));
    }

    // zero doesn't actually count
    public static int CountZero(int[,] matrix)
    {
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 4; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int currCell = matrix[row, col];

                if (currCell == 0 &&
                    currCell == matrix[row, col + 1] && currCell == matrix[row, col + 2] &&
                    currCell == matrix[row + 1, col + 2] && currCell == matrix[row + 2, col + 2] && currCell == matrix[row + 3, col + 2] && currCell == matrix[row + 4, col + 2] &&
                    currCell == matrix[row + 1, col] && currCell == matrix[row + 2, col] && currCell == matrix[row + 3, col] && currCell == matrix[row + 4, col] &&
                    currCell == matrix[row + 4, col + 1] && currCell == matrix[row + 4, col + 2])
                {
                    count++;
                }
            }
        }

        return count * 0;
    }

    public static int CountOne(int[,] matrix)
    {
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 4; row++)
        {
            for (int col = 2; col < matrix.GetLength(1); col++)
            {
                int currCell = matrix[row, col];

                if (currCell == 1 && 
                    currCell == matrix[row + 1, col] && currCell == matrix[row + 1, col - 1] &&
                    currCell == matrix[row + 2, col - 2] && currCell == matrix[row + 2, col] &&
                    currCell == matrix[row + 3, col] &&
                    currCell == matrix[row + 4, col])
                {
                    count++;
                }
            }
        }

        return count * 1;
    }

    public static int CountTwo(int[,] matrix)
    {
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 4; row++)
        {
            for (int col = 1; col < matrix.GetLength(1) - 1; col++)
            {
                int currCell = matrix[row, col];

                if (currCell == 2 && 
                    currCell == matrix[row + 1, col - 1] && currCell == matrix[row + 1, col + 1] &&
                    currCell == matrix[row + 1, col + 1] && currCell == matrix[row + 2, col + 1] &&
                    currCell == matrix[row + 3, col] &&
                    currCell == matrix[row + 4, col - 1] && currCell == matrix[row + 4, col] && currCell == matrix[row + 4, col + 1])
                {
                    count++;
                }
            }
        }

        return count * 2;
    }

    public static int CountThree(int[,] matrix)
    {
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 4; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int currCell = matrix[row, col];

                if (currCell == 3 && 
                    currCell == matrix[row, col + 1] && currCell == matrix[row, col + 2] &&
                    currCell == matrix[row + 1, col + 2] &&
                    currCell == matrix[row + 2, col + 1] && currCell == matrix[row + 2, col + 2] &&
                    currCell == matrix[row + 3, col + 2] &&
                    currCell == matrix[row + 4, col] && currCell == matrix[row + 4, col + 1] && currCell == matrix[row + 4, col + 2])
                {
                    count++;
                }
            }
        }

        return count * 3;
    }

    public static int CountFour(int[,] matrix)
    {
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 4; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int currCell = matrix[row, col];

                if (currCell == 4 && 
                    currCell == matrix[row, col + 2] &&
                    currCell == matrix[row + 1, col] && currCell == matrix[row + 1, col + 2] &&
                    currCell == matrix[row + 2, col] && currCell == matrix[row + 2, col + 1] && currCell == matrix[row + 2, col + 2] &&
                    currCell == matrix[row + 3, col + 2] &&
                    currCell == matrix[row + 4, col + 2])
                {
                    count++;
                }
            }
        }

        return count * 4;
    }

    public static int CountFive(int[,] matrix)
    {
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 4; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int currCell = matrix[row, col];

                if (currCell == 5 && 
                    currCell == matrix[row, col + 1] && currCell == matrix[row, col + 2] &&
                    currCell == matrix[row + 1, col] &&
                    currCell == matrix[row + 2, col] && currCell == matrix[row + 2, col + 1] && currCell == matrix[row + 2, col + 2] &&
                    currCell == matrix[row + 3, col + 2] &&
                    currCell == matrix[row + 4, col] && currCell == matrix[row + 4, col + 1] && currCell == matrix[row + 4, col + 2])
                {
                    count++;
                }
            }
        }

        return count * 5;
    }

    public static int CountSix(int[,] matrix)
    {
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 4; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int currCell = matrix[row, col];

                if (currCell == 6 && 
                    currCell == matrix[row, col + 1] && currCell == matrix[row, col + 2] &&
                    currCell == matrix[row + 1, col] &&
                    currCell == matrix[row + 2, col] && currCell == matrix[row + 2, col + 1] && currCell == matrix[row + 2, col + 2] &&
                    currCell == matrix[row + 3, col] && currCell == matrix[row + 3, col + 2] &&
                    currCell == matrix[row + 4, col] && currCell == matrix[row + 4, col + 1] && currCell == matrix[row + 4, col + 2])
                {
                    count++;
                }
            }
        }

        return count * 6;
    }

    public static int CountSeven(int[,] matrix)
    {
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 4; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int currCell = matrix[row, col];

                if (currCell == 7 && 
                    currCell == matrix[row, col + 1] && currCell == matrix[row, col + 2] &&
                    currCell == matrix[row + 1, col + 2] &&
                    currCell == matrix[row + 2, col + 1] &&
                    currCell == matrix[row + 3, col + 1] &&
                    currCell == matrix[row + 4, col + 1])
                {
                    count++;
                }
            }
        }

        return count * 7;
    }

    public static int CountEight(int[,] matrix)
    {
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 4; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int currCell = matrix[row, col];

                if (currCell == 8 && 
                    currCell == matrix[row, col + 1] && currCell == matrix[row, col + 2] &&
                    currCell == matrix[row + 1, col] && currCell == matrix[row + 1, col + 2] &&
                    currCell == matrix[row + 2, col + 1] &&
                    currCell == matrix[row + 3, col] && currCell == matrix[row + 3, col + 2] &&
                    currCell == matrix[row + 4, col] && currCell == matrix[row + 4, col + 1] && currCell == matrix[row + 4, col + 2])
                {
                    count++;
                }
            }
        }

        return count * 8;
    }

    public static int CountNine(int[,] matrix)
    {
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 4; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int currCell = matrix[row, col];

                if (currCell == 9 &&
                    currCell == matrix[row, col + 1] && currCell == matrix[row, col + 2] &&
                    currCell == matrix[row + 1, col] && currCell == matrix[row + 1, col + 2] &&
                    currCell == matrix[row + 2, col + 1] && currCell == matrix[row + 2, col + 2] &&
                    currCell == matrix[row + 3, col + 2] &&
                    currCell == matrix[row + 4, col] && currCell == matrix[row + 4, col + 1] && currCell == matrix[row + 4, col + 2])
                {
                    count++;
                }
            }
        }

        return count * 9;
    }
   
}

