namespace WalkInMatrix
{
    using Utils;
    using WalkInMatrix.Contracts;
    using WalkInMatrix.Models;
    using WalkInMatrix.Providers;

    public class StartUp
    {        
        public static void Main()
        {
            var writer = new Writer();
            var reader = new Reader();
            var engine = new Engine(writer, reader);
            var startCell = new Coordinates(0, 0);
            var startDirection = new Coordinates(1, 1);
            var matrix = engine.ProcessInput();
            
            engine.ExecuteWalkInMatrix(matrix, startCell, startDirection);
        }        
    }
}