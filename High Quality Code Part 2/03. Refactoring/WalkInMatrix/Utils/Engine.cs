namespace WalkInMatrix.Utils
{
    using Contracts;
    using Models;
    
    public class Engine
    {
        public Engine(IWriter writer, IReader reader)
        {
            this.Writer = writer;
            this.Reader = reader;
        }

        public IWriter Writer { get; set; }

        public IReader Reader { get; set; }

        public IMatrix ProcessInput()
        {
            this.Writer.WriteLine("Enter a positive number in range 1 - 100:");
            string input = this.Reader.ReadLine();
            int size = 0;

            while (!int.TryParse(input, out size))
            {
                this.Writer.WriteLine("You haven't entered a correct positive number, try again!");
                input = this.Reader.ReadLine();
            }

            return new SquareMatrix(size);
        }

        public void ExecuteWalkInMatrix(IMatrix matrix, ICoordinates startingPoint, ICoordinates startDirection)
        {
            matrix.FillMatrixInCircularPattern(startingPoint, startDirection);
            this.Writer.WriteLine(matrix.ToString());
        }
    }
}
