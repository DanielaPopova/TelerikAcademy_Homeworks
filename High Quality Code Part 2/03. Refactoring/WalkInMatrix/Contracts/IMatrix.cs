namespace WalkInMatrix.Contracts
{
    public interface IMatrix
    {
        int Size { get; } 

        int this[int row, int col] { get;  set; }

        void FillMatrixInCircularPattern();
    }
}
