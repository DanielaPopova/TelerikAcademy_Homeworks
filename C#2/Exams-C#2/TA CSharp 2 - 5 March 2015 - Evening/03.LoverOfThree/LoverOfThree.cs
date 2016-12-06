using System;
using System.Numerics;

class LoverOfThree
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');

        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);
        int[,] field = new int[rows, cols];
        FillField(field);
        //PrintMatrix(field);

        int countMovies = int.Parse(Console.ReadLine());

        BigInteger sum = 0;
        int currRow = rows - 1;
        int currCol = 0;

        for (int i = 0; i < countMovies; i++)
        {
            string[] data = Console.ReadLine().Split(' ');
            string directions = data[0];
            int movements = int.Parse(data[1]);

            for (int p = 0; p < movements; p++)
            {               
                sum += field[currRow, currCol];
                field[currRow, currCol] = 0;

                if (p == movements - 1)
                {
                    break;
                }

                if (directions == "UR" || directions == "RU")
                {
                    currRow--;
                    currCol++;
                }
                else if(directions == "UL" || directions == "LU")
                {
                    currRow--;
                    currCol--;
                }
                else if (directions == "DL" || directions == "LD")
                {
                    currRow++;
                    currCol--;
                }
                else if (directions == "DR" || directions == "RD")
                {
                    currRow++;
                    currCol++;
                }

                if (CheckBorder(currRow, currCol, field))
                {
                    int[] newPosition = ReturnPosition(currRow, currCol, directions);
                    currRow = newPosition[0];
                    currCol = newPosition[1];                     
                    break;
                }
            }          
        }

        Console.WriteLine(sum);
    }

    public static void FillField(int[,] field)
    {
        int count = 0;

        for (int col = 0; col < field.GetLength(1); col++)
        {
            int currRow = field.GetLength(0) - 1;

            for (int row = field.GetLength(0) - 1; row >= 0 ; row--)
            {
                field[row, col] = count;
                count += 3;                
            }

            count = field[field.GetLength(0) - 1, col] + 3;
        }
    }

    public static bool CheckBorder(int row, int col, int[,] field)
    {
        bool stopCycle = false;

        if (row >= field.GetLength(0) || row < 0 || col >= field.GetLength(1) || col < 0)
        {
            stopCycle = true;
        }

        return stopCycle;
    }

    public static int[] ReturnPosition(int currRow, int currCol, string directions)
    {
        int[] position = new int[2];

        if (directions == "UR" || directions == "RU")
        {
            currRow++;
            currCol--;
        }
        else if (directions == "UL" || directions == "LU")
        {
            currRow++;
            currCol++;
        }
        else if (directions == "DL" || directions == "LD")
        {
            currRow--;
            currCol++;
        }
        else if (directions == "DR" || directions == "RD")
        {
            currRow--;
            currCol--;
        }

        position[0] = currRow;
        position[1] = currCol;

        return position;
    }
  
    public static void PrintMatrix(int[,] matrix)
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
}

