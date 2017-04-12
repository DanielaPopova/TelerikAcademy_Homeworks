namespace WalkInMatrix
{
    using WalkInMatrix.Models;
    using WalkInMatrix.Utils;
    
    public class StartUp
    {        
        static void Main()
        {
            var engine = Engine.Instance;

            int matrixSize = engine.GetMatrixSize();
            var matrix = new SquareMatrix(matrixSize);
            var matrixCell = new Coordinates(0, 0);
            var direction = new Coordinates(1, 1);

            engine.FillMatrixInCircularPattern(matrix, matrixCell, direction);
        }
    }
}