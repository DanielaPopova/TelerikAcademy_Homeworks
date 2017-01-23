namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    using SchoolSystem.Models;

    public interface ISchool
    {
        string SchoolName { get; }

        IEnumerable<IStudent> Students { get; }

        IEnumerable<ICourse> Courses { get; }

        void AdmitStudent(IStudent student);

        void ExpellStudent(IStudent student);

        void AddCourse(ICourse course);

        void RemoveCourse(ICourse course);
    }
}
