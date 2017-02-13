namespace Cosmetics.Tests.Engine.CosmeticsEngineTests
{
    using System.Collections.Generic;

    using NUnit.Framework;
    using Moq;

    using Cosmetics.Contracts;
    using Mocks;

    [TestFixture]
    public class Start_Tests
    {
        [Test]
        public void Start_ValidInputStringForCreateCategoryCommand_ShoulAddCategoryToList()
        {
            //Arrange
            string categoryName = "someName";

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();

            var commandMock = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();

            commandMock.SetupGet(c => c.Name).Returns("CreateCategory");
            commandMock.SetupGet(c => c.Parameters).Returns(new List<string>() { categoryName});
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand> { commandMock.Object });

            categoryMock.SetupGet(cat => cat.Name).Returns(categoryName);
            factoryMock.Setup(f => f.CreateCategory(categoryName)).Returns(categoryMock.Object);

            var cosmeticsEngine = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);

            //Act
            cosmeticsEngine.Start();

            //Assert
            //Assert.AreSame(categoryMock.Object, cosmeticsEngine.Categories[categoryName]);
            Assert.IsTrue(cosmeticsEngine.Categories.ContainsKey(categoryName));
        }
    }
}
