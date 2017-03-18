namespace Cosmetics.Tests.Products
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Mocks;
    using Contracts;
    using Cosmetics.Products;

    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void AddProduct_PassedProductIsValid_ShouldBeAddedToProductsList()
        {
            //Arrange
            var productMock = new Mock<IProduct>();
            var shoppingCart = new ShoppingCartMock();

            //Act
            shoppingCart.AddProduct(productMock.Object);

            //Assert
            Assert.AreEqual(1, shoppingCart.Products.Count);
        }

        [Test]
        public void RemoveProduct_PassedProduct_ShouldBeRemovedFromProductList()
        {
            //Arrange
            var productMock = new Mock<IProduct>();
            var shoppingCart = new ShoppingCartMock();
            shoppingCart.AddProduct(productMock.Object);

            //Act
            shoppingCart.RemoveProduct(productMock.Object);

            //Assert
            //Assert.IsFalse(shoppingCart.Products.Contains(productMock.Object));
            Assert.AreEqual(0, shoppingCart.Products.Count);
        }

        [Test]
        public void ContainsProduct_PassedProductIsInList_ShouldReturnTrue()
        {
            //Arrange
            var productMock = new Mock<IProduct>();
            var shoppingCart = new ShoppingCartMock();
            shoppingCart.AddProduct(productMock.Object);

            //Act
            bool actual = shoppingCart.ContainsProduct(productMock.Object);

            //Assert
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void ContainsProduct_PassedProductIsNotInList_ShouldReturnFalse()
        {
            //Arrange
            var productMock = new Mock<IProduct>();           
            var shoppingCart = new ShoppingCartMock();
           
            //Act
            bool actual = shoppingCart.ContainsProduct(productMock.Object);

            //Assert
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void TotalPrice_NoProductsInList_ShouldReturnZero()
        {
            //Arrange
            var shoppingCart = new ShoppingCartMock();

            //Act
            decimal actual = shoppingCart.TotalPrice();

            //Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void TotalPrice_ProductsInList_ShouldReturnTotalSumOfProductsPrices()
        {
            //Arrange
            var shoppingCart = new ShoppingCartMock();
            var productMock = new Mock<IProduct>();
            var secondProductMock = new Mock<IProduct>();

            productMock.SetupGet(pr => pr.Price).Returns(5.0M);
            secondProductMock.SetupGet(pr => pr.Price).Returns(2.0M);

            shoppingCart.AddProduct(productMock.Object);
            shoppingCart.AddProduct(secondProductMock.Object);

            //Act
            decimal actualPrice = shoppingCart.TotalPrice();

            //Assert
            Assert.AreEqual(7.0M, actualPrice);
        }
    }
}
