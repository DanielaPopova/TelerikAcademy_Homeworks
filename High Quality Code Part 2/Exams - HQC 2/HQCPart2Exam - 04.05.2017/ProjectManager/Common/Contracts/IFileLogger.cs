namespace ProjectManager.Common.Contracts
{
    public interface IFileLogger
    {
        void Info(object message);

        void Error(object message);

        void Fatal(object message);
    }
}
