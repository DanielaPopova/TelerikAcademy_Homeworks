namespace SchoolSystem.Tests.Core
{
    using System;
    using NUnit.Framework;
    using Moq;
    using SchoolSystem.Core.Contracts;
    using SchoolSystem.Core;
    using Mocks;

    [TestFixture]
    public class EngineTests
    {
        [Test]
        public static void Constructor_PassedReaderIsNull_ShouldThrowArgumentNullException()
        {
            IReader nullReader = null;
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();

            Assert.Throws<ArgumentNullException>(() => new Engine(nullReader, writer.Object, parser.Object));
        }

        [Test]
        public static void Constructor_PassedWriterIsNull_ShouldThrowArgumentNullException()
        {
            var reader = new Mock<IReader>();
            IWriter nullWriter = null;
            var parser = new Mock<IParser>();

            Assert.Throws<ArgumentNullException>(() => new Engine(reader.Object, nullWriter, parser.Object));
        }

        [Test]
        public static void Constructor_PassedParserIsNull_ShouldThrowArgumentNullException()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            IParser nullParser = null;
            

            Assert.Throws<ArgumentNullException>(() => new Engine(reader.Object, writer.Object, nullParser));
        }

        [Test, Timeout(2500)]
        public static void Execute_PassedCommandIsTerminationCommand_ShouldBreakLoop()
        {
            var terminationCommand = "End";

            var reader = new Mock<IReader>();
            reader.Setup(r => r.ReadLine()).Returns(terminationCommand);
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
           
            var engine = new Engine(reader.Object, writer.Object, parser.Object);

            engine.Execute();
        }

        //[TestCase("")]
        //[TestCase(null)]
        //public static void Execute_PassedCommandIsNullOrEmpty_ShouldPrintErrorMessage(string invalidCommand)
        //{
        //    var expectedMessage = "null or empty";

        //    var reader = new Mock<IReader>();
        //    reader.Setup(r => r.ReadLine()).Returns(invalidCommand); 
                    
        //    var writer = new Mock<IWriter>();
        //    var parser = new Mock<IParser>();

        //    var engine = new Engine(reader.Object, writer.Object, parser.Object);

        //    writer.Verify(w => w.WriteLine(It.Is<string>(s => s.Contains(expectedMessage))));           
        //}

    }
}
