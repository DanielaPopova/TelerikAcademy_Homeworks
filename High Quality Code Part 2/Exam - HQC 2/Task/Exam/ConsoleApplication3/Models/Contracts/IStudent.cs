namespace SchoolSystem.Models.Contracts
{
    using System.Collections.Generic;

    using SchoolSystem.Enums;

    public interface IStudent : IPerson
    {
        Grade Grade { get; set; }

        IList<IMark> Marks { get; }

        string ListMarks();
    }
}
