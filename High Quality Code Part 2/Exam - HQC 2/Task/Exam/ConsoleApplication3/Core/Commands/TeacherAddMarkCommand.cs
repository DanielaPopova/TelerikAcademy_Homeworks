namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;

    using Contracts;

    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var markValue = float.Parse(parameters[2]);

            var student = Engine.Students[studentId];
            var teacher = Engine.Teachers[teacherId];
            teacher.AddMark(student, markValue);

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
