namespace ProjectManager.Common.Contracts
{
    public interface ICommandProcessor
    {
        string ProcessCommand(string commandLine);
    }
}
