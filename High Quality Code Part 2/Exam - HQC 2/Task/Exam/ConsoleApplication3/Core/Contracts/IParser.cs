namespace SchoolSystem.Core.Contracts
{
    using System.Collections.Generic;

    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
