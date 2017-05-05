using ProjectManager.Models.Enums;

namespace ProjectManager.Models.Contracts
{
    public interface ITask
    {
        string Name { get; }

        IUser Owner { get; }

        State State { get; }
    }
}
