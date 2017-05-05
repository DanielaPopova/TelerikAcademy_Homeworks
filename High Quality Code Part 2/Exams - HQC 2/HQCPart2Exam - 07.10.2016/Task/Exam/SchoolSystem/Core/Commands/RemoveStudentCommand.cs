namespace SchoolSystem.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);

            if (!Engine.Students.ContainsKey(studentId))
            {
                throw new ArgumentException("There is no student with that ID!");
            }

            Engine.Students.Remove(studentId);

            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
