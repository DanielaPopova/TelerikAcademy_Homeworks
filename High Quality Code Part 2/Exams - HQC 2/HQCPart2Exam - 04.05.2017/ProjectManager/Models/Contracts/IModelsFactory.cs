namespace ProjectManager.Models.Contracts
{
    public interface IModelsFactory
    {
        IProject CreateProject(string name, string startingDate, string endingDate, string state);

        ITask CreateTask(string name, IUser owner, string state);

        IUser CreateUser(string username, string email);
    }
}
