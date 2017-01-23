namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string CourseName { get; }

        IEnumerable<IStudent> Students { get; }

        void AddStudent(IStudent student);

        void RemoveStudent(IStudent student);
    }
}
