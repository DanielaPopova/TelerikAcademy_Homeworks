namespace Abstraction
{  
    using Abstraction.Contracts;

    public abstract class Figure : IFigure
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();        
    }
}
