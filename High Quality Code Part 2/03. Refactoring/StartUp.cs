namespace RotatingWalkInMatrix
{
    using System;

    public class StartUp
    {        
        static void Main()
        {
            //Console.WriteLine("Enter a positive number ");
            //string input = Console.ReadLine();
            //int n = 0;
            //while (!int.TryParse(input, out n) || n < 0 || n > 100)
            //{
            //    Console.WriteLine("You haven't entered a correct positive number");
            //    input = Console.ReadLine();
            //}
            int size = 5;
            int[,] matrix = new int[size, size];
            int counter = 1;
            int currentRow = 0;
            int currentCol = 0;
            int deltaX = 1;
            int deltaY = 1;

            while (counter <= size * size)
            {
                matrix[currentRow, currentCol] = counter;

                if (!CheckIfAdjacentCellIsEmpty(matrix, currentRow, currentCol))
                {
                    if (currentRow == 0 && currentCol == 0)
                    {
                        break;
                    }
                }

                while ((currentRow + deltaX >= size || currentRow + deltaX < 0 || currentCol + deltaY >= size || currentCol + deltaY < 0 || matrix[currentRow + deltaX, currentCol + deltaY] != 0))
                {
                    ChangeDirection(ref deltaX, ref deltaY);
                }

                currentRow += deltaX;
                currentCol += deltaY;
                counter++;
            }

            FindEmptyCell(matrix, out currentRow, out currentCol);

            while (counter <= size * size)
            {
                matrix[currentRow, currentCol] = counter + 1;
                if (!CheckIfAdjacentCellIsEmpty(matrix, currentRow, currentCol))
                {
                    break;
                }

                while ((currentRow + deltaX >= size || currentRow + deltaX < 0 || currentCol + deltaY >= size || currentCol + deltaY < 0 || matrix[currentRow + deltaX, currentCol + deltaY] != 0))
                {
                    ChangeDirection(ref deltaX, ref deltaY);
                }

                currentRow += deltaX;
                currentCol += deltaY;
                counter++;
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0,5}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void ChangeDirection(ref int deltaX, ref int deltaY)
        {
            int[] directionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currDirection = 0;
            for (int i = 0; i < 8; i++)
            {
                if (directionsRow[i] == deltaX && directionsCol[i] == deltaY)
                {
                    currDirection = i;
                    break;
                }
            }
           
            deltaX = directionsRow[(currDirection + 1) % 8];
            deltaY = directionsCol[(currDirection + 1) % 8];
        }

        static bool CheckIfAdjacentCellIsEmpty(int[,] arr, int currentRow, int currentCol)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (currentRow + dirX[i] >= arr.GetLength(0) || currentRow + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (currentCol + dirY[i] >= arr.GetLength(0) || currentCol + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[currentRow + dirX[i], currentCol + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void FindEmptyCell(int[,] arr, out int currentRow, out int currentCol)
        {
            //Check if none empty cell is found -> x and y stay 0
            currentRow = 0;
            currentCol = 0;
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(0); col++)
                {
                    if (arr[row, col] == 0)
                    {
                        currentRow = row;
                        currentCol = col;
                        return;
                    }
                }
            }
        }
    }
}


