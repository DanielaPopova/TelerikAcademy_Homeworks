namespace Academy.Commands.Listing
{
    using System.Collections.Generic;

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

        //TODO: Implement
        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.engine.Seasons[int.Parse(seasonId)];

            return season.ListCourses().TrimEnd();
        }

    }
}
