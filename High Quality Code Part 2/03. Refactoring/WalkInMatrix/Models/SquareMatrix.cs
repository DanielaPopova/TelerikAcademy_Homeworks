namespace WalkInMatrix.Models
{
    using System;
    using System.Text;

    using WalkInMatrix.Contracts;
    using WalkInMatrix.Utils;

    public class SquareMatrix : IMatrix
    { 
        private int size;
        private int[,] matrix;

        public SquareMatrix(int size)
        {
            this.Size = size;
            this.matrix = new int[this.Size, this.Size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Matrix size cannot be zero or smaller!");
                }

                this.size = value;
            }
        }

        public int this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= this.Size || col < 0 || col >= this.Size)
                {
                    throw new IndexOutOfRangeException("No such index in the matrix!");
                }

                return this.matrix[row, col];
            }

            set
            {
                if (row < 0 || row >= this.Size || col < 0 || col >= this.Size)
                {
                    throw new IndexOutOfRangeException("No such index in the matrix!");
                }

                this.matrix[row, col] = value;
            }
        }

        public void FillMatrixInCircularPattern()
        {
            // Awlays starts from:
            int counter = 1;           
            ICoordinates delta = new Coordinates(1, 1);
            ICoordinates matrixCell = new Coordinates(0, 0);

            while (true)
            {
                this.matrix[matrixCell.X, matrixCell.Y] = counter;

                if (!this.matrix.IsNearCellEmpty(matrixCell))
                {
                    matrixCell = this.matrix.FindEmptyCell();

                    if (matrixCell != null)
                    {
                        delta.X = 1;
                        delta.Y = 1;
                        counter++;

                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                while (this.matrix.IsOutsideMatrixBorders(matrixCell, delta) ||
                     this.matrix[matrixCell.X + delta.X, matrixCell.Y + delta.Y] != 0)
                {
                    MatrixExtensions.ChangeDirection(delta);
                }

                matrixCell.X += delta.X;
                matrixCell.Y += delta.Y;
                counter++;
            }
        }

        public override string ToString()
        {
            var printedMatrix = new StringBuilder();

            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    printedMatrix.AppendFormat("{0,5}", this.matrix[row, col]);
                }

                printedMatrix.AppendLine();
            }

            return printedMatrix.ToString();
        }
    }
}
