namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;

    using Contracts;
    using Enums;
    using Models;

    public class CreateTeacherCommand : ICommand
    {
        private static int teachertId = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = new Teacher(firstName, lastName, subject);

            Engine.Teachers.Add(teachertId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {teachertId++} was created.";
        }
    }
}
