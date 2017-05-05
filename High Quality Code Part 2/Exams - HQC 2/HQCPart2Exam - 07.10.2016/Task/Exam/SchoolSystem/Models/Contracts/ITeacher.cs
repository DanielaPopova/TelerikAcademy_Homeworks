namespace SchoolSystem.Models.Contracts
{
    using SchoolSystem.Enums;

    public interface ITeacher : IPerson
    {
        Subject Subject { get; set; }

        void AddMark(IStudent student, float value);
    }
}
