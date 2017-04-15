namespace WalkInMatrixTests.Utils
{
    using System;

    using WalkInMatrix.Contracts;   
    using WalkInMatrix.Models;
    using WalkInMatrix.Providers;
    using WalkInMatrix.Utils;

    using Moq;
    using NUnit.Framework;    

    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Constructor_PassedWriterIsNull_ShouldThrowNullReferenceException()
        {
            IWriter nullWriter = null;
            var readerMock = new Mock<IReader>();

            Assert.Throws<NullReferenceException>(() => new Engine(nullWriter, readerMock.Object));
        }

        [Test]
        public void Constructor_PassedReaderIsNull_ShouldThrowNullReferenceException()
        {
            var writerMock = new Mock<IWriter>();
            IReader nullReader = null;

            Assert.Throws<NullReferenceException>(() => new Engine(writerMock.Object, nullReader));
        }

        [Test]
        public void Constructor_ShouldReturnInstanceOfIWriter()
        {
            var writer = new Writer();
            var readerMock = new Mock<IReader>();

            var engine = new Engine(writer, readerMock.Object);

            Assert.IsInstanceOf<IWriter>(engine.Writer);
        }

        [Test]
        public void Constructor_WhenPassedWriterIsValid_ShouldBeCorrectlyAssigned()
        {
            var writer = new Writer();
            var readerMock = new Mock<IReader>();

            var engine = new Engine(writer, readerMock.Object);

            Assert.AreSame(writer, engine.Writer);
        }

        [Test]
        public void Constructor_ShouldReturnInstanceOfIReader()
        {
            var writerMock = new Mock<IWriter>();
            var reader = new Reader();

            var engine = new Engine(writerMock.Object, reader);

            Assert.IsInstanceOf<IReader>(engine.Reader);
        }

        [Test]
        public void Constructor_WhenPassedReadeIsValid_ShouldBeCorrectlyAssigned()
        {
            var writerMock = new Mock<IWriter>();
            var reader = new Reader();

            var engine = new Engine(writerMock.Object, reader);

            Assert.AreSame(reader, engine.Reader);
        }

        [Test]
        public void ProcessInput_PassedInputIsCorrect_ShouldCallWriterOnceOnly()
        {
            var writerMock = new Mock<IWriter>();

            var readerMock = new Mock<IReader>();
            readerMock.Setup(s => s.ReadLine()).Returns("4");

            var engine = new Engine(writerMock.Object, readerMock.Object);

            engine.ProcessInput();

            writerMock.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ProcessInput_PassedInputIsInvalid_ShouldCallWriterTwice()
        {
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            readerMock.SetupSequence(s => s.ReadLine()).Returns("-1").Returns("5");

            var engine = new Engine(writerMock.Object, readerMock.Object);

            engine.ProcessInput();

            writerMock.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void ProcessInput_PassedInputIsInvalid_ShouldPrintCorrectMessage()
        {
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            readerMock.SetupSequence(s => s.ReadLine()).Returns("-1").Returns("5");

            var engine = new Engine(writerMock.Object, readerMock.Object);

            engine.ProcessInput();

            writerMock.Verify(w => w.WriteLine(It.Is<string>(m => m.Contains("Wrong input"))));
        }

        [Test]
        public void ProcessInput_PassedInputIsValid_ShouldReturnMatrixWithCorrespondingSize()
        {
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            readerMock.Setup(s => s.ReadLine()).Returns("5");

            var engine = new Engine(writerMock.Object, readerMock.Object);

            var returnedMatrix = engine.ProcessInput();

            Assert.AreEqual(5, returnedMatrix.Size);
        }

        [Test]
        public void ExecuteWalkInMatrix_PassedMatrixIsNull_ShouldThrowNullReferenceException()
        {
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var engine = new Engine(writerMock.Object, readerMock.Object);

            IMatrix nullMatrix = null;

            Assert.Throws<NullReferenceException>(() => engine.ExecuteWalkInMatrix(nullMatrix));
        }

        [Test]
        public void ExecuteWalkInMatrix_PassedMatrixIsValid_ShouldFillMatrixCorrectly()
        {
            var expectedMatrix = new int[,]
            {
                { 1, 10, 11, 12 },
                { 9, 2, 15, 13 },
                { 8, 16, 3, 14 },
                { 7, 6, 5, 4 },
            };
            var actualMatrix = new SquareMatrix(4);
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var engine = new Engine(writerMock.Object, readerMock.Object);

            engine.ExecuteWalkInMatrix(actualMatrix);

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Assert.AreEqual(expectedMatrix[row, col], actualMatrix[row, col]);
                }
            }
        }

        [Test]
        public void ExecuteWalkInMatrix_PassedMatrixIsValid_ShouldCallWriterOnce()
        {
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var engine = new Engine(writerMock.Object, readerMock.Object);

            var matrixMock = new Mock<IMatrix>();

            engine.ExecuteWalkInMatrix(matrixMock.Object);

            writerMock.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Once);
        }
    }
}
