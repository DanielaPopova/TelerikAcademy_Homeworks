namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;
    using Exceptions;

    [TestFixture]
    public class UnitsFactoryTests
    {
        //GetUnit should return new Procyon unit, when a valid corresponding command is passed (i.e. "create unit Procyon Gosho 1");      
        [Test]
        public void GetUnit_ValidCommandIsPassed_ShouldReturnProcyon()
        {
            //Arrange
            string validCommand = "create unit Procyon Gosho 1";            
            var factory = new UnitsFactory();

            //Act
            var actual = factory.GetUnit(validCommand);

            //Assert
            Assert.IsInstanceOf<Procyon>(actual);
        }

        //GetUnit should return new Luyten unit, when a valid corresponding command is passed (i.e. "create unit Luyten Pesho 2");
        [Test]
        public void GetUnit_ValidCommandIsPassed_ShouldReturnLuyten()
        {
            //Arrange
            string validCommand = "create unit Luyten Pesho 2";
            var factory = new UnitsFactory();

            //Act
            var actual = factory.GetUnit(validCommand);

            //Assert
            Assert.IsInstanceOf<Luyten>(actual);
        }

        //GetUnit should return new Lacaille unit, when a valid corresponding command is passed (i.e. "create unit Lacaille Tosho 3");
        [Test]
        public void GetUnit_ValidCommandIsPassed_ShouldReturnLacaille()
        {
            //Arrange
            string validCommand = "create unit Lacaille Tosho 3";
            var factory = new UnitsFactory();

            //Act
            var actual = factory.GetUnit(validCommand);

            //Assert
            Assert.IsInstanceOf<Lacaille>(actual);
        }

        //GetUnit should throw InvalidUnitCreationCommandException, when the command passed is not in the valid format described above.
        //(Check for at least 2 different cases)
        [TestCase("create unit InvalidType Name 3")]
        [TestCase("create unit Luyten Name invalidId")]
        public void GetUnit_InvalidCommandIsPassed_ShouldThrowInvalidUnitCreationCommandException(string invalidCommand)
        {
            //Arrange
            var factory = new UnitsFactory();

            //Act/Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(invalidCommand));
        }
    }
}
