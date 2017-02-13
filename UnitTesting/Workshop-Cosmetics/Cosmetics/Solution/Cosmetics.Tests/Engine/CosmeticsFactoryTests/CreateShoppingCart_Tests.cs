namespace Cosmetics.Tests.Engine.CosmeticsFactoryTests
{    
    using NUnit.Framework;
    using Cosmetics.Engine;
    using Contracts;

    [TestFixture]
    public class CreateShoppingCart_Tests
    {
        [Test]
        public void CreateShoppingCart_ShouldCreateInstanceOfShoppingCart()
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Act
            var actual = factory.CreateShoppingCart();

            //Assert
            Assert.IsInstanceOf<IShoppingCart>(actual);
        }
    }
}
