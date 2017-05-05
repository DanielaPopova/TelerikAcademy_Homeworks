namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;

    using Contracts;
    using Enums;
    using Models;

    public class CreateStudentCommand : ICommand
    {
        private static int studentId = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = new Student(firstName, lastName, grade);

            Engine.Students.Add(studentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {studentId++} was created.";
        }
    }
}
