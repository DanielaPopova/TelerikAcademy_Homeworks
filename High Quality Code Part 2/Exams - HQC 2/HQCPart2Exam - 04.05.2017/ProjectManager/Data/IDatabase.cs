namespace ProjectManager.Data
{
    using Models.Contracts;
    using System.Collections.Generic;

    // You are not allowed to modify this interface (except to add documentation)
    public interface IDatabase
    {
        IList<IProject> Projects { get; }
    }
}
