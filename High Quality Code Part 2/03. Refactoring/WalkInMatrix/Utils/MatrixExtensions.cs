namespace WalkInMatrix.Utils
{
    using WalkInMatrix.Contracts;
    using WalkInMatrix.Models;

    public static class MatrixExtensions
    {        
        public static bool IsOutsideMatrixBorders(ICoordinates matrixCell, ICoordinates direction, int size)
        {
            if (matrixCell.X + direction.X >= size || matrixCell.X + direction.X < 0 ||
                matrixCell.Y + direction.Y >= size || matrixCell.Y + direction.Y < 0)
            {
                return true;
            }

            return false;
        }

       public static void ChangeDirection(ICoordinates direction)
        {
            int[] possibleDirectionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] possibleDirectionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int step = 0;

            for (int i = 0; i < 8; i++)
            {
                if (possibleDirectionsRow[i] == direction.X && possibleDirectionsCol[i] == direction.Y)
                {
                    step = i;
                    break;
                }
            }

            direction.X = possibleDirectionsRow[(step + 1) % 8];
            direction.Y = possibleDirectionsCol[(step + 1) % 8];
        }

        public static bool IsNearCellEmpty(IMatrix matrix, ICoordinates matrixCell)
        {
            int[] possibleDirectionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] possibleDirectionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (matrixCell.X + possibleDirectionsRow[i] >= matrix.Size || matrixCell.X + possibleDirectionsRow[i] < 0)
                {
                    possibleDirectionsRow[i] = 0;
                }

                if (matrixCell.Y + possibleDirectionsCol[i] >= matrix.Size || matrixCell.Y + possibleDirectionsCol[i] < 0)
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

        public static Coordinates FindEmptyCell(IMatrix matrix)
        {            
            for (int row = 0; row < matrix.Size; row++)
            {
                for (int col = 0; col < matrix.Size; col++)
                {
                    if (matrix[row, col] == 0)
                    {                        
                        return new Coordinates(row, col);
                    }
                }
            }

            return null;
        }
    }
}
