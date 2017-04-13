namespace WalkInMatrix.Models
{
    using System;
    using System.Text;

    using WalkInMatrix.Contracts;

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
                if(value < MinSize || value > MaxSize)
                {
                    throw new ArgumentException("Matrix size is in range 1 - 100!");
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
                    throw new IndexOutOfRangeException();
                }

                return this.matrix[row, col];
            }

            set
            {
                if (row < 0 || row >= this.Size || col < 0 || col >= this.Size)
                {
                    throw new IndexOutOfRangeException();
                }

                this.matrix[row, col] = value;
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
