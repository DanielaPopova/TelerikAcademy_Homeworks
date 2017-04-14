namespace WalkInMatrix.Utils
{
    using WalkInMatrix.Contracts;
    using WalkInMatrix.Models;

    public static class MatrixExtensions
    {  
       public static void ChangeDirectionDelta(this int[,] matrix, ICoordinates delta)
        {
            int[] possibleDirectionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] possibleDirectionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };           
           
            for (int i = 0; i < 8; i++)
            {
                if (possibleDirectionsRow[i] == delta.X && possibleDirectionsCol[i] == delta.Y)
                {
                    delta.X = possibleDirectionsRow[(i + 1) % 8];
                    delta.Y = possibleDirectionsCol[(i + 1) % 8];
                    break;
                }
            }               
        }

        public static bool IsNearCellEmpty(this int[,] matrix, ICoordinates matrixCell)
        {
            int[] possibleDirectionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] possibleDirectionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (matrixCell.X + possibleDirectionsRow[i] >= matrix.GetLength(0) || matrixCell.X + possibleDirectionsRow[i] < 0)
                {
                    possibleDirectionsRow[i] = 0;
                }

                if (matrixCell.Y + possibleDirectionsCol[i] >= matrix.GetLength(1) || matrixCell.Y + possibleDirectionsCol[i] < 0)
                {
                    possibleDirectionsCol[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (matrix[matrixCell.X + possibleDirectionsRow[i], matrixCell.Y + possibleDirectionsCol[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static ICoordinates FindEmptyCell(this int[,] matrix)
        {            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {                        
                        return new Coordinates(row, col);
                    }
                }
            }

            return null;
        }

        public static bool IsOutsideMatrixBorders(this int[,] matrix, ICoordinates matrixCell, ICoordinates delta)
        {
            if (matrixCell.X + delta.X >= matrix.GetLength(0) || matrixCell.X + delta.X < 0 ||
                matrixCell.Y + delta.Y >= matrix.GetLength(1) || matrixCell.Y + delta.Y < 0)
            {
                return true;
            }

            return false;
        }
    }
}
