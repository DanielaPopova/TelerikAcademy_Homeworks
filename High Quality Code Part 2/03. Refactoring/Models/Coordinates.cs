namespace WalkInMatrix.Models
{ 
    /// <summary>
    /// Used for finding:
    /// a cell in a square matrix through given row and column;
    /// a possible direction to move in a square matrix
    /// </summary>
         
    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
