using System;

class SequenceInMatrix
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        string[,] matrix = new string[rows, cols];
        int maxCount = 1;
        int currCount = 1;
        for (int row = 0; row < rows; row++)
        {
            string[] currRow = Console.ReadLine().Split(' ');
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = currRow[col];
            }
        }
        
        //int [,] matrix =  {{1,1,4, 3,3,3},{2,1,5,7,8,9}};
        //search by rows
        for (int row = 0; row < rows; row++)
        {            
            for (int col = 0; col < cols - 1; col++)
            {                
                if (matrix[row, col] == matrix[row, col + 1])
                {
                    currCount++;
                    if (currCount > maxCount)
                    {
                        maxCount = currCount;
                    }
                }
                else
                {
                    currCount = 1;
                }                
            }            
        }

        //search by cols
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row, col] == matrix[row + 1, col])
                {
                    currCount++;
                    if (currCount > maxCount)
                    {
                        maxCount = currCount;
                    }
                }
                else
                {
                    currCount = 1;
                }
            }
        }

        //search by diagonals
        for (int row = 0; row < rows; row++)
        {
            for (int col = 1; col < cols; col++)
            {
                
            }
        }

        Console.WriteLine(maxCount);
    }
}

