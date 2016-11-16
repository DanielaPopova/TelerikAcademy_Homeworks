using System;

class FillTheMatrix
{
     static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        char type = char.Parse(Console.ReadLine());

        int[,] matrix = new int[size, size];

        int counter = 1;

        if (type == 'a')
        { 
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }

            PrintMatrix(matrix);
        }

        if (type == 'b')
        {
            for (int col = 0; col < size; col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < size; row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int row = size - 1; row >= 0; row--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
            }

            PrintMatrix(matrix);
        }

        if (type == 'c')
        {
            for (int i = size - 1; i >= 0; i--)
            {
                int row = i;
                int col = 0;
                while (row < size && col < size)
                {
                    matrix[row, col] = counter;
                    counter++;
                    row++;
                    col++;
                }
            }

            for (int i = 1; i < size; i++)
            {
                int row = i;
                int col = 0;
                while (row < size && col < size)
                {
                    matrix[col, row] = counter;
                    counter++;
                    row++;
                    col++;
                }
            }

            PrintMatrix(matrix);
        }

        if (type == 'd')
        {
            string direction = "down";
            int currRow = 0;
            int currCol = 0;

            for (int i = 1; i <= size * size; i++)
            {
                if (direction == "down" && (currRow >= size || matrix[currRow, currCol] != 0))
                {
                    direction = "right";
                    currRow--;
                    currCol++;
                }
                else if (direction == "right" && (currCol >= size || matrix[currRow, currCol] != 0))
                {
                    direction = "up";
                    currCol--;
                    currRow--;
                }
                else if (direction == "up" && (currRow < 0 || matrix[currRow, currCol] != 0))
                {
                    direction = "left";
                    currRow++;
                    currCol--;
                }
                else if (direction == "left" && (currCol < 0 || matrix[currRow, currCol] != 0))
                {
                    direction = "down";
                    currCol++;
                    currRow++;
                }

                matrix[currRow, currCol] = i;

                if (direction == "down")
                {
                    currRow++;
                }
                else if (direction == "right")
                {
                    currCol++;
                }
                else if (direction == "up")
                {
                    currRow--;
                }
                else if (direction == "left")
                {
                    currCol--;
                }
            }

            PrintMatrix(matrix);
        }

    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col == matrix.GetLength(1) - 1)
                {
                    Console.Write(matrix[row, col]);
                }
                else
                {
                    Console.Write(matrix[row, col] + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
