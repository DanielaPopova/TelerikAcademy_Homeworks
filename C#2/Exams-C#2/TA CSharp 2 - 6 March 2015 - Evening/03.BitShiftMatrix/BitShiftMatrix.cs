using System;
using System.Linq;
using System.Numerics;

class BitShiftMatrix
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        bool[,] isVisited = new bool[rows, cols];

        int moves = int.Parse(Console.ReadLine());
        double[] codes = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

        BigInteger sum = 0;
        int currRow = rows - 1;
        int currCol = 0;

        for (int i = 0; i < codes.Length; i++)
        {
            double code = codes[i];
            int[] newPosition = GetPosition(rows, cols, code);

            int nextRow = CheckRow(newPosition[0], rows);            
            int nextCol = CheckCol(newPosition[1], cols);

            int caseCycle = CycleCase(currRow, currCol, nextRow, nextCol);

            CurrentToNextPosition(caseCycle, currRow, currCol, nextRow, nextCol, isVisited);

            currRow = nextRow;
            currCol = nextCol;
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (isVisited[row, col])
                {
                    sum += GetValue(row, col, rows);
                }
            }
        }

        Console.WriteLine(sum);
    }

    public static int[] GetPosition(int rows, int cols, double code)
    {
        int[] position = new int[2];

        int coeff = Math.Max(rows, cols);
        int row = (int)code / coeff;
        int col = (int)code % coeff;

        position[0] = row;
        position[1] = col;

        return position;
    }

    public static int CheckRow(int row, int rows)
    {
        int newRow = row;

        if (row < 0)
        {
            newRow = 0;
        }
        else if (row >= rows)
        {
            newRow = rows - 1;
        }

        return newRow;
    }

    public static int CheckCol(int col, int cols)
    {
        int newCol = col;

        if (col < 0)
        {
            newCol = 0;
        }
        else if (col >= cols)
        {
            newCol = cols - 1;
        }

        return newCol;
    }

    public static int CycleCase(int currRow, int currCol, int nextRow, int nextCol)
    {
        int caseCycle = 0;

        if (currRow <= nextRow && currCol <= nextCol)
        {
            caseCycle = 0;
        }
        else if (currRow <= nextRow && currCol >= nextCol)
        {
            caseCycle = 1;
        }
        else if (currRow >= nextRow && currCol <= nextCol)
        {
            caseCycle = 2;
        }
        else if (currRow >= nextRow && currCol >= nextCol)
        {
            caseCycle = 3;
        }

        return caseCycle;
    }

    public static void CurrentToNextPosition(int caseCycle, int currRow, int currCol, int nextRow, int nextCol, bool[,] isVisited)
    {        
        if (caseCycle == 0)
        {
            for (int i = currRow; i <= nextRow; i++)
            {
                isVisited[i, nextCol] = true;                
            }

            for (int i = currCol; i <= nextCol; i++)
            {
                isVisited[currRow, i] = true;
            }
        }

        if (caseCycle == 1)
        {
            for (int i = currRow; i <= nextRow; i++)
            {
                isVisited[i, nextCol] = true;
               
            }

            for (int i = currCol; i >= nextCol; i--)
            {
                isVisited[currRow, i] = true;
            }
        }

        if (caseCycle == 2)
        {
            for (int i = currRow; i >= nextRow; i--)
            {
                isVisited[i, nextCol] = true;
            }

            for (int i = currCol; i <= nextCol; i++)
            {
                isVisited[currRow, i] = true;
            }
        }

        if (caseCycle == 3)
        {
            for (int i = currRow; i >= nextRow; i--)
            {
                isVisited[i, nextCol] = true;              
            }

            for (int i = currCol; i >= nextCol; i--)
            {
                isVisited[currRow, i] = true;
            }
        }
    }

    public static BigInteger GetValue(int row, int col, int rows)
    {
        return ((BigInteger)1) << (rows - row - 1 + col);
    }
}

