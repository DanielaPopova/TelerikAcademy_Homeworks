namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System;

    using NUnit.Framework;
    using ArmyOfCreatures.Logic.Battles;

    [TestFixture]
    public class CreatureIdentifierTests
    {
        //Call with null valueToParse should throw ArgumentNullException
        [Test]
        public void CreatureIdentifier_ValueToParseIsNull_ShouldThrowArgumentNullException()
        {
            //Arrange
            string nullValueToParse = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(nullValueToParse));
            Assert.That(() => CreatureIdentifier.CreatureIdentifierFromString(nullValueToParse), Throws.ArgumentNullException.With.Message.Contains("valueToParse"));
        }

        //Call with invalid Army number (ex: Angel(test)) test cannot be parsed should throw FormatExcepition
        [Test]
        public void CreatureIdentifier_ValueToParseHasInvalidArmyNumber_ShouldThrowFormatException()
        {
            //Arrange --correct format exm Angel(1)--
            string invalidArmyNumberInValueToParse = "Angel(invalid)";

            //Act/Assert
            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString(invalidArmyNumberInValueToParse));
            Assert.That(() => CreatureIdentifier.CreatureIdentifierFromString(invalidArmyNumberInValueToParse),
               Throws.InstanceOf<FormatException>());
        }

        //Call with invalid string (without brackets to split) should throw IndexOutOfRangeException
        [Test]
        public void CreatureIdentifier_ValueToParseHasnoBracketsToBeSplittedBy_ShouldThrowIndexOutOfRangeException()
        {
            //Arrange
            string valueToParseWithoutBrackets = "Angel";

            //Act/Assert
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParseWithoutBrackets));
        }

        //ToString should output expected result
        [Test]
        public void ToString_ValidInput_ShouldReturnExpectedoutput()
        {
            //Arrange
            string expected = "Angel(1)";
            
            var creatureId = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            //Act
            var actual = creatureId.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
