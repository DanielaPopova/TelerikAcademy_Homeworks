namespace WalkInMatrix.Utils
{   
    using WalkInMatrix.Contracts;   
    using WalkInMatrix.Providers;

    public class Engine
    {
        private static Engine instanceHolder = new Engine();

        private IWriter writer;
        private IReader reader;

        private Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
        }

        public static Engine Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public int GetMatrixSize()
        {
            this.writer.WriteLine("Enter a positive number in range 1 - 100:");
            string input = this.reader.ReadLine();
            int size = 0;

            while (!int.TryParse(input, out size))
            {
                this.writer.WriteLine("You haven't entered a correct positive number");
                input = this.reader.ReadLine();
            }

            return size;
        }

        public void FillMatrixInCircularPattern(IMatrix matrix, ICoordinates matrixCell, ICoordinates direction)
        {
            int counter = 1;

            while (true)
            {
                matrix[matrixCell.X, matrixCell.Y] = counter;

                if (!MatrixExtensions.IsNearCellEmpty(matrix, matrixCell))
                {
                    matrixCell = MatrixExtensions.FindEmptyCell(matrix);

                    if (matrixCell != null)
                    {
                        counter++;
                        direction.X = 1;
                        direction.Y = 1;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                while (MatrixExtensions.IsOutsideMatrixBorders(matrixCell, direction, matrix.Size) ||
                     matrix[matrixCell.X + direction.X, matrixCell.Y + direction.Y] != 0)
                {
                    MatrixExtensions.ChangeDirection(direction);
                }

                matrixCell.X += direction.X;
                matrixCell.Y += direction.Y;
                counter++;
            }

            this.writer.WriteLine(matrix.ToString());
        }       
    }
}
