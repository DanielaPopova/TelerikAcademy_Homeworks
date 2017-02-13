namespace Cosmetics.Tests.Engine.CommandTests
{
    using System;
    using NUnit.Framework;
    using Cosmetics.Engine;
    using System.Collections.Generic;

    [TestFixture]
    public class Parse_Tests
    {
        [Test]
        public void Parse_ValidInput_ShouldReturnInstanceOfCommand()
        {
            //Arrrange
            string validInput = "test Input";

            //Act
            var sut = Command.Parse(validInput);

            //Assert
            Assert.IsInstanceOf<Command>(sut);
        }

        [Test]
        public void Parse_ValidInput_ShouldSetCorrectlyCommandName()
        {
            //Arrange
            string validInput = "someName param1 param2";
            string name = "someName";

            //Act
            var sut = Command.Parse(validInput);

            //Assert
            Assert.AreEqual(name, sut.Name);           
        }

        [Test]
        public void Parse_ValidInput_ShouldSetCorrectlyCommandParameters()
        {
            //Arrange
            string validInput = "someName param1 param2";
            List<string> parameters = new List<string>(){ "param1", "param2"};

            //Act
            var sut = Command.Parse(validInput);

            //Assert
            //Assert.AreEqual("param1", sut.Parameters[0]);
            //Assert.AreEqual("param2", sut.Parameters[1]);
            CollectionAssert.AreEqual(parameters, sut.Parameters);
        }

        [Test]
        public void Parse_InputIsNull_ShouldThrowNullReferenceException()
        {
            //Arrange
            string nullInput = null;
           
            //Act/Assert
            Assert.Throws<NullReferenceException>(() => Command.Parse(nullInput));
        }

        [Test]
        public void Parse_InputWithNullOrEmptyName_ShouldThrowArgumentException()
        {
            //Arrange
            string inputWithEmptyName = " param1 param2";

            //Assert
            Assert.That(() => Command.Parse(inputWithEmptyName), Throws.ArgumentNullException.With.Message.Contains("Name"));
        }

        [Test]
        public void Parse_InputWithNullOrEmptyParameterList_ShouldThrowArgumentException()
        {
            //Arrange
            string inputWithoutParameters = "name ";

            //Assert            
            Assert.That(() => Command.Parse(inputWithoutParameters), Throws.ArgumentNullException.With.Message.Contains("List"));

            //Other
            //var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(inputWithoutParameters));
            //StringAssert.Contains(ex.Message, "List");
        }
    }
}
