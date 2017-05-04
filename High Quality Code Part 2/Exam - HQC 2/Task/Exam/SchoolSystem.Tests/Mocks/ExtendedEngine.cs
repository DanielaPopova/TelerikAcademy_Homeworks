namespace SchoolSystem.Tests.Mocks
{
    using SchoolSystem.Core;    
    using SchoolSystem.Core.Contracts;

    public class ExtendedEngine : Engine
    {
        public ExtendedEngine(IReader reader, IWriter writer, IParser parser)
            : base(reader, writer, parser)
        {

        }

        public IReader Reader
        {
            get
            {
                return base.reader;
            }
        }

        public IWriter Writer
        {
            get
            {
                return base.writer;
            }
        }

        public IParser Parser
        {
            get
            {
                return base.parser;
            }
        }
    }
}
