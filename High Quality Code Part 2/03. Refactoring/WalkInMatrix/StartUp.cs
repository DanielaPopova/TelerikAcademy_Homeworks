namespace WalkInMatrix
{      
    using WalkInMatrix.Models;
    using WalkInMatrix.Providers;
    using WalkInMatrix.Utils;

    public class StartUp
    {        
        public static void Main()
        {
            var writer = new Writer();
            var reader = new Reader();
            var engine = new Engine(writer, reader);
            var startingPoint = new Coordinates(0, 0);
            
            var matrix = engine.ProcessInput();
            
            engine.ExecuteWalkInMatrix(matrix);
        }        
    }
}