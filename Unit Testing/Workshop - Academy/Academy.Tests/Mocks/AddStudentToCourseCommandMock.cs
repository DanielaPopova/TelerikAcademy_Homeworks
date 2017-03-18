namespace Academy.Tests.Mocks
{
    using System;
    using Core.Contracts;
    using Commands.Adding;

    internal class AddStudentToCourseCommandMock : AddStudentToCourseCommand
    {
        public AddStudentToCourseCommandMock(IAcademyFactory factory, IEngine engine)
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
