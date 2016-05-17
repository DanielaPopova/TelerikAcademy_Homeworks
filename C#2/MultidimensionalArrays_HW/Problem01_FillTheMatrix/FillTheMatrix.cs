using System;

class FillTheMatrix
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = rows;
        char type = char.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];

        int counter = 1;

        if (type == 'a')
        {            
            for (int col = 0; col < cols; col++)
            {                
                for (int row = 0; row < rows; row++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }                
            }
        }
        else if (type == 'b')
        {
            for (int col = 0; col < cols; col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < rows; row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int row = rows - 1; row >= 0; row--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
            }
        }
        else if (type == 'c')
        {           
            for (int i = rows - 1; i >= 0; i--)
            {
                int row = i;
                int col = 0;
                while (row < rows && col < cols)
                {
                    matrix[row, col] = counter;
                    counter++;
                    row++;
                    col++;
                }
            }

            for (int i = 1; i < rows; i++)
            {
               int  row = i;
                int col = 0;
                while (row < rows && col < cols)
                {
                    matrix[col, row] = counter;
                    counter++;
                    row++;
                    col++;
                }
            }
        }
        else if (type == 'd')
        {
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    
                }
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (col == cols - 1)
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

/*
//Console.WriteLine("Enter positive integer number in range [1...20]");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        string direction = "right";

        int currentRow = 0;
        int currentCol = 0;

        for (int i = 1; i <= n * n; i++)
        {

            if (direction == "right" && (currentCol >= n || matrix[currentRow, currentCol] != 0))
            {
                currentCol--;
                currentRow++;
                direction = "down";
            }

            else if (direction == "down" && (currentRow >= n || matrix[currentRow, currentCol] != 0))
            {
                currentRow--;
                currentCol--;   
                direction = "left";
            }

            else if (direction == "left" && (currentCol < 0 || matrix[currentRow, currentCol] != 0))
            {
                currentCol++;
                currentRow--;
                direction = "up";
            }
            else if (direction == "up" && (currentRow < 0 || matrix[currentRow, currentCol] != 0))
            {
                currentRow++;
                currentCol++;
                direction = "right";
            }

            matrix[currentRow, currentCol] = i;

            if (direction == "right")
            {
                currentCol++;
            }
            else if (direction == "down")
            {
                currentRow++;
            }
            else if (direction == "left")
            {
                currentCol--;
            }
            else if (direction == "up")
            {
                currentRow--;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i,j] + " ");
            }
            Console.WriteLine();
        } 
    }
}
*/