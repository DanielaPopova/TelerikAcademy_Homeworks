namespace WalkInMatrix.Utils
{
    using System;

    using Contracts;
    using Models;
    
    public class Engine
    {
        private const int MinSize = 1;
        private const int MaxSize = 100;

        private IWriter writer;
        private IReader reader;

        public Engine(IWriter writer, IReader reader)
        {
            this.Writer = writer;
            this.Reader = reader;
        }

        public IWriter Writer
        {
            get
            {
                return this.writer;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Writer cannot be null!");
                }

                this.writer = value;
            }
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Reader cannot be null!");
                }

                this.reader = value;
            }
        }

        public IMatrix ProcessInput()
        {
            this.Writer.WriteLine("Enter a positive number in range 1 - 100:");
            string input = this.Reader.ReadLine();
            int size = 0;

            while (!int.TryParse(input, out size) || size < MinSize || size > MaxSize)
            {
                this.Writer.WriteLine("Wrong input, try again!");
                input = this.Reader.ReadLine();
            }

            return new SquareMatrix(size);
        }

        public void ExecuteWalkInMatrix(IMatrix matrix)
        {
            if (matrix == null)
            {
                throw new NullReferenceException("Matrix cannot be null!");
            }
            
            matrix.FillMatrixInCircularPattern();
            this.Writer.WriteLine(matrix.ToString());
        }
    }
}
