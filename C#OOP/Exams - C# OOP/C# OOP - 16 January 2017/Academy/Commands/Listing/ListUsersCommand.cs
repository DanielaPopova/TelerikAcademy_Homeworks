namespace Academy.Commands.Listing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Models.Contracts;
    using Contracts;
    using Core.Contracts;

    public class ListUsersCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
       
        public string Execute(IList<string> parameters)
        {
            var students = this.engine.Students;
            var trainers = this.engine.Trainers;

            if (students.Count == 0 && trainers.Count == 0)
            {
                throw new ArgumentException("There are no registered users!");
            }

            var info = new StringBuilder();

            foreach (var trainer in trainers)
            {
                info.AppendLine(trainer.ToString());
            }

            foreach (var student in students)
            {
                info.AppendLine(student.ToString());
            }

            return info.ToString().TrimEnd();
        }
    }
}
