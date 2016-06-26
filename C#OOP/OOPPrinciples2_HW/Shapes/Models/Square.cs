namespace Shapes.Models
{
    public class Square : Shape
    {
        public Square(double size) : base(size, size)
        {            
        }

        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }
}
