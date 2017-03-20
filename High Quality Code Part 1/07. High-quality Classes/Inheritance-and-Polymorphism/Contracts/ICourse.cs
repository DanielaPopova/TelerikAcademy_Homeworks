namespace InheritanceAndPolymorphism.Contracts
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; }

        string TeacherName { get; set; }

        ICollection<string> Students { get; set; }
    }
}
