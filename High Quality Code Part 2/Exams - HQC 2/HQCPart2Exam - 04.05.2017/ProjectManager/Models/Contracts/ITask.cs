namespace ProjectManager.Models.Contracts
{
    using Enums;

    public interface ITask
    {
        string Name { get; set; }

        IUser Owner { get; set; }

        TaskState State { get; set; }
    }
}
