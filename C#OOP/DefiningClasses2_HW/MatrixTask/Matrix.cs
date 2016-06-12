namespace MatrixTask
{
    using System;
    using System.Text;

    public class Matrix<T> where T : struct, IComparable
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
            this.Rows = rows;
            this.Cols = cols;
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            set
            {
                if (value < 0 || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Rows should be between 0 and 2,147,483,647!");
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            set
            {
                if (value < 0 || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Cols should be between 0 and 2,147,483,647!");
                }

                this.cols = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= this.Rows || col < 0 || col >= this.Cols)
                {
                    throw new IndexOutOfRangeException("No such index in the matrix!");
                }

                return this.matrix[row, col];
            }

            set
            {
                if (row < 0 || row >= this.Rows || col < 0 || col >= this.Cols)
                {
                    throw new IndexOutOfRangeException("No such index in the matrix!");
                }

                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            var result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            if (firstMatrix.Rows != secondMatrix.Rows && firstMatrix.Cols != secondMatrix.Cols)
            {
                throw new ArgumentException("Both matrices must be the same size!");
            }
            else
            {
                for (int row = 0; row < firstMatrix.Rows; row++)
                {
                    for (int col = 0; col < firstMatrix.Cols; col++)
                    {
                        result[row, col] = (dynamic)firstMatrix[row, col] + (dynamic)secondMatrix[row, col];
                    }
                }

                return result;
            }
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            var result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            if (firstMatrix.Rows != secondMatrix.Rows && firstMatrix.Cols != secondMatrix.Cols)
            {
                throw new ArgumentException("Both matrices must be the same size!");
            }
            else
            {
                for (int row = 0; row < firstMatrix.Rows; row++)
                {
                    for (int col = 0; col < firstMatrix.Cols; col++)
                    {
                        result[row, col] = (dynamic)firstMatrix[row, col] - (dynamic)secondMatrix[row, col];
                    }
                }

                return result;
            }
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            var result = new Matrix<T>(firstMatrix.Rows, secondMatrix.Cols);

            if (firstMatrix.Cols != secondMatrix.Rows)
            {
                throw new ArgumentException("The cols of the first matrix must be equal to the rows of the second matrix!");
            }

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    for (int i = 0; i < firstMatrix.Cols; i++)
                    {
                        result[row, col] += (dynamic)firstMatrix[row, i] * (dynamic)secondMatrix[i, col];
                    }
                }
            }

            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            return CheckNonZeros(matrix);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return CheckNonZeros(matrix);
        }

        // works with intiger numbers
        public void FillMatrix()
        {
            var randomGenerator = new Random();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    this.matrix[row, col] = (dynamic)randomGenerator.Next(-50, 51);
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    result.Append(this.matrix[row, col] + " ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        private static bool CheckNonZeros(Matrix<T> matrix)
        {
            bool result = true;
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if (matrix[row, col] == (dynamic)0)
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
    }
}