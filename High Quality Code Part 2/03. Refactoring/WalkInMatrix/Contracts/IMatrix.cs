namespace WalkInMatrix.Contracts
{
    public interface IMatrix
    {
        int Size { get; }
        
        int[,] Matrix { get; }

        void FillMatrixInCircularPattern(ICoordinates matrixCell, ICoordinates delta);
    }
}
