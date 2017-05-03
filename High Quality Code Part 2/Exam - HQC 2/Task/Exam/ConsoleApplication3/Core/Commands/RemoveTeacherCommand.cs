namespace SchoolSystem.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);

            if (!Engine.Teachers.ContainsKey(teacherId))
            {
                throw new ArgumentException("There is no teacher with that ID!");
            }

            Engine.Teachers.Remove(teacherId);

            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
