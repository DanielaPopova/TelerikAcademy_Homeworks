namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    public interface IStudent
    {
        string Name { get; }

        uint ID { get; }

        IEnumerable<string> Courses { get; }       
    }
}
