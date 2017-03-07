namespace Academy.Tests.Mocks
{
    using Commands.Adding;
    using System;
    using Core.Contracts;

    internal class AddStudentToSeasonCommandMock : AddStudentToSeasonCommand
    {
        public AddStudentToSeasonCommandMock(IAcademyFactory factory, IEngine engine)
            : base(factory, engine)
        {

        }

        public IAcademyFactory AcademyFactory
        {
            get
            {
                return base.factory;
            }            
        }

        public IEngine Engine
        {
            get
            {
                return base.engine;
            }
        }
    }
}
