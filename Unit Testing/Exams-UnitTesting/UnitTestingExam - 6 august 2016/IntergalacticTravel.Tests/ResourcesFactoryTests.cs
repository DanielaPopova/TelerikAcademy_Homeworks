namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class ResourcesFactoryTests
    {
        //GetResources should return a newly created Resources object with correctly set up properties(Gold, Bronze and Silver coins),
        //no matter what the order of the parameters is,
        //when the input string is in the correct format. (Check with all possible cases):
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResources_ValidCommandIsPassed_ShouldReturnNewResourcesWithCorrectProperties(string validCommand)
        {
            //Arrange
            uint expectedGoldCoins = 20;
            uint expectedSilverCoins = 30;
            uint expectedbronzeCoins = 40;

            var resourceFactory = new ResourcesFactory();

            //Act
            var actualResources = resourceFactory.GetResources(validCommand);

            //Assert
            Assert.AreEqual(expectedGoldCoins, actualResources.GoldCoins);
            Assert.AreEqual(expectedSilverCoins, actualResources.SilverCoins);
            Assert.AreEqual(expectedbronzeCoins, actualResources.BronzeCoins);
        }

        //GetResources should throw InvalidOperationException, which contains the string "command", when the input string represents an invalid command.
        //(Check with at least 2 different cases).
        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void GetResources_InvalidCommandIsPassed_ShouldThrowInvalidOperationException(string invalidCommand)
        {
            //Arrange
            var resourceFactory = new ResourcesFactory();

            //Act/Assert
            Assert.That(() => resourceFactory.GetResources(invalidCommand), Throws.InvalidOperationException.With.Message.Contains("command"));

            var exc = Assert.Throws<InvalidOperationException>(() => resourceFactory.GetResources(invalidCommand));
            StringAssert.Contains("command", exc.Message);
        }

        //GetResources should throw OverflowException, when the input string command is in the correct format,
        //but any of the values that represent the resource amount is larger than uint.MaxValue. (Check with at least 2 different cases)
        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_ValidCommandButInvalidResourceAmountIsPassed_ShouldThrowOverflowException(string validCommandInvalidAmount)
        {
            //Arrange
            var resourceFactory = new ResourcesFactory();

            //Act/Assert
            Assert.Throws<OverflowException>(() => resourceFactory.GetResources(validCommandInvalidAmount));
        }
    }
}
