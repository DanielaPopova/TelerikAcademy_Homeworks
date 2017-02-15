namespace ArmyOfCreatures.Tests.Extended
{
    using System;

    using NUnit.Framework;
    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Extended.Creatures;
    using ArmyOfCreatures.Logic.Creatures;

    [TestFixture]
    public class ExtendedCreaturesFactoryTests
    {
        /*CreateCreature should throw ArgumentException with message that contains the string "Invalid creature type",
         when a string representing non-existing creature type is passed as a method argument.*/
        [Test]
        public void CreateCreature_PassedTypeIsNonExisting_ShouldThrowArgumentExceptionWithExpectedMessage()
        {
            //Arrange
            string invalidType = "invalid";
            var factory = new ExtendedCreaturesFactory();

            //Act/Assert
            Assert.That(() => factory.CreateCreature(invalidType), Throws.ArgumentException.With.Message.Contain("Invalid creature type"));

            var er = Assert.Throws<ArgumentException>(() => factory.CreateCreature(invalidType));
            StringAssert.Contains("Invalid creature type", er.Message);
        }

        /*CreateCreature should return the corresponding creature type based on the string that is passed as a method argument.
         Test with (AncientBehemoth, CyclopsKing, Goblin, Griffin, WolfRaider, and something else for the default case).*/
        [TestCase("AncientBehemoth", typeof(AncientBehemoth))]
        [TestCase("CyclopsKing", typeof(CyclopsKing))]
        [TestCase("Goblin", typeof(Goblin))]
        [TestCase("Griffin", typeof(Griffin))]
        [TestCase("WolfRaider", typeof(WolfRaider))]
        [TestCase("Angel", typeof(Angel))]
        public void CreateCreature_PassedTypeIsValid_ShouldReturnCorrespondingCreatureType(string stringType, Type expectedType)
        {
            //Arrange
            var factory = new ExtendedCreaturesFactory();

            //Act
            var actualType = factory.CreateCreature(stringType).GetType();

            //Assert
            Assert.AreEqual(expectedType, actualType);
            Assert.IsInstanceOf(expectedType, factory.CreateCreature(stringType));
        }
    }
}
