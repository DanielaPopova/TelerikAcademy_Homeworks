namespace WalkInMatrix.Models
{
    using System;
    using System.Text;

    using WalkInMatrix.Contracts;
    using WalkInMatrix.Utils;

    public class SquareMatrix : IMatrix
    {
        private const int MinSize = 1;
        private const int MaxSize = 100;

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
                if (value < MinSize || value > MaxSize)
                {
                    throw new ArgumentException("Matrix size is in range 1 - 100!");
                }

                this.size = value;
            }
        }

        public int[,] Matrix
        {
            get
            {
                return this.matrix;
            }
        }

        public void FillMatrixInCircularPattern(ICoordinates matrixCell, ICoordinates delta)
        {
            int counter = 1;

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
                    this.matrix.ChangeDirectionDelta(delta);
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
