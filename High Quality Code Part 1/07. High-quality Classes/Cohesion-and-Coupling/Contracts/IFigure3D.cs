namespace CohesionAndCoupling.Contracts
{
    public interface IFigure3D
    {
        double Width { get; }

        double Height { get; }

        double Depth { get;  }

        double Volume { get; }
    }
}
