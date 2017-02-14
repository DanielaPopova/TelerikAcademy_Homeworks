namespace Cosmetics.Tests.Engine.CosmeticsEngineTests
{
    using System.Collections.Generic;

    using NUnit.Framework;
    using Moq;

    using Cosmetics.Contracts;
    using Cosmetics.Common;
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
            commandMock.SetupGet(c => c.Parameters).Returns(new List<string>() { categoryName });
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

        [Test]
        public void Start_ValidInputStringForAddToCategoryCommand_ShouldAddProductToCategory()
        {
            //Arrange
            string categoryName = "categoryName";
            string productName = "productName";

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();

            var commandMock = new Mock<ICommand>();

            commandMock.SetupGet(c => c.Name).Returns("AddToCategory");
            commandMock.SetupGet(c => c.Parameters).Returns(new List<string>() { categoryName, productName });
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand> { commandMock.Object });

            var categoryMock = new Mock<ICategory>();
            categoryMock.SetupGet(cat => cat.Name).Returns(categoryName);
            var productMock = new Mock<IProduct>();

            var engine = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engine.Categories.Add(categoryName, categoryMock.Object);
            engine.Products.Add(productName, productMock.Object);

            //Act
            engine.Start();

            //Assert
            categoryMock.Verify(c => c.AddProduct(productMock.Object), Times.Once);
        }

        [Test]
        public void Start_ValidInputStringForRemoveFromCategoryCommand_ShouldRemoveProductFromCategory()
        {
            //Arrange
            string categoryName = "categoryName";
            string productName = "productName";

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();

            var commandMock = new Mock<ICommand>();

            commandMock.SetupGet(c => c.Name).Returns("RemoveFromCategory");
            commandMock.SetupGet(c => c.Parameters).Returns(new List<string>() { categoryName, productName });
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand> { commandMock.Object });

            var categoryMock = new Mock<ICategory>();
            categoryMock.SetupGet(cat => cat.Name).Returns(categoryName);
            var productMock = new Mock<IProduct>();

            var engine = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engine.Categories.Add(categoryName, categoryMock.Object);
            engine.Products.Add(productName, productMock.Object);

            //Act
            engine.Start();

            //Assert
            categoryMock.Verify(c => c.RemoveProduct(productMock.Object), Times.Once);
        }

        [Test]
        public void Start_ValidInputStringForShowCategoryCommand_ShouldCallPrintMethod()
        {
            //Arrange
            string categoryName = "categoryName";

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();

            var commandMock = new Mock<ICommand>();

            commandMock.SetupGet(c => c.Name).Returns("ShowCategory");
            commandMock.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });
            commandParserMock.Setup(c => c.ReadCommands()).Returns(new List<ICommand> { commandMock.Object });

            var categoryMock = new Mock<ICategory>();
            categoryMock.SetupGet(cat => cat.Name).Returns(categoryName);

            var engine = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engine.Categories.Add(categoryName, categoryMock.Object);

            //Act
            engine.Start();

            //Assert
            categoryMock.Verify(c => c.Print(), Times.Once);
        }

        [Test]
        public void Start_ValidInputStringForCreateShampooCommand_ShouldAddShampooToProductList()
        {
            //Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();

            var commandMock = new Mock<ICommand>();
            var shampooMock = new Mock<IShampoo>();

            commandMock.SetupGet(c => c.Name).Returns("CreateShampoo");
            commandMock.SetupGet(c => c.Parameters).Returns(new List<string>() { "shampooName", "shampooBrand", "12", "men", "200", "everyday" });
            commandParserMock.Setup(com => com.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });

            factoryMock.Setup(f => f.CreateShampoo("shampooName", "shampooBrand", 12, GenderType.Men, 200, UsageType.EveryDay)).Returns(shampooMock.Object);

            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);

            //Act
            engineMock.Start();

            //Assert
            Assert.IsTrue(engineMock.Products.ContainsKey("shampooName"));
            Assert.AreSame(shampooMock.Object, engineMock.Products["shampooName"]);
        }

        [Test]
        public void Start_ValidInputStringForCreateToothpasteCommand_ShouldAddToothpasteToProductList()
        {
            //Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();

            var commandMock = new Mock<ICommand>();
            var toothpasteMock = new Mock<IToothpaste>();

            commandMock.SetupGet(c => c.Name).Returns("CreateToothpaste");
            commandMock.SetupGet(c => c.Parameters).Returns(new List<string>() { "toothpasteName", "toothpasteBrand", "12", "men", "ingr1,ingr2" });
            commandParserMock.Setup(com => com.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });

            factoryMock.Setup(f => f.CreateToothpaste("toothpasteName", "toothpasteBrand", 12, GenderType.Men, new List<string>() { "ingr1", "ingr2" }))
                .Returns(toothpasteMock.Object);

            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);

            //Act
            engineMock.Start();

            //Assert
            Assert.IsTrue(engineMock.Products.ContainsKey("toothpasteName"));
            Assert.AreSame(toothpasteMock.Object, engineMock.Products["toothpasteName"]);
        }

        [Test]
        public void Start_ValidInputStringForAddToShoppingCartCommand_ShouldAddProductToShoppingCart()
        {
            //Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();

            var commandMock = new Mock<ICommand>();
            var productMock = new Mock<IProduct>();

            commandMock.SetupGet(c => c.Name).Returns("AddToShoppingCart");
            commandMock.SetupGet(c => c.Parameters).Returns(new List<string>() { "productName" });
            commandParserMock.Setup(com => com.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });

            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engineMock.Products.Add("productName", productMock.Object);

            //Act
            engineMock.Start();

            //Assert
            shoppingCartMock.Verify(sh => sh.AddProduct(productMock.Object), Times.Once);
        }

        [Test]
        public void Start_ValidInputStringForRemoveFromShoppingCartCommand_ShouldRemoveProductFromShoppingCart()
        {
            //Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();

            var commandMock = new Mock<ICommand>();
            var productMock = new Mock<IProduct>();

            commandMock.SetupGet(c => c.Name).Returns("RemoveFromShoppingCart");
            commandMock.SetupGet(c => c.Parameters).Returns(new List<string>() { "productName" });
            commandParserMock.Setup(com => com.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });

            shoppingCartMock.Setup(x => x.ContainsProduct(productMock.Object)).Returns(true);

            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engineMock.Products.Add("productName", productMock.Object);

            //Act
            engineMock.Start();

            //Assert
            shoppingCartMock.Verify(sh => sh.RemoveProduct(productMock.Object), Times.Once);
        }
    }
}
