namespace StatisticalAnalysis.Contracts
{
    public interface IWriter
    {
        void Write(string line);

        void WriteLine(string line);
    }
}
