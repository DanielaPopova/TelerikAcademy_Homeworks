namespace WalkInMatrix.Contracts
{
    public interface IMatrix
    {
        int Size { get; }
        
        int this[int x, int y] { get;  set; }     
    }
}
