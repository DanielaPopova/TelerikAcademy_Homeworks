namespace Cosmetics.Tests.Products
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Contracts;
    using Mocks;
    using Cosmetics.Products;

    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void AddCosmetics_PassedProductIsValid_ShouldBeAddedToProductsList()
        {
            //Arrange
            var productMock = new Mock<IProduct>();
            var category = new CategoryMock("someName");

            //Act
            category.AddProduct(productMock.Object);

            //Assert
            //Assert.IsTrue(category.Products.Contains(productMock.Object));
            Assert.AreEqual(1, category.Products.Count);
        }

        [Test]
        public void RemoveCosmetics_PassedProduct_ShouldBeRemovedFromProductList()
        {
            //Arrange
            var productMock = new Mock<IProduct>();
            var category = new CategoryMock("someName");
            category.AddProduct(productMock.Object);

            //Act
            category.RemoveProduct(productMock.Object);

            //Assert
            //Assert.IsFalse(category.Products.Contains(productMock.Object));
            Assert.AreEqual(0, category.Products.Count);
        }

        [Test]
        public void Print_ShouldReturnStringWithcategoryDetails()
        {
            //Arrange            
            var category = new Category("someName");
            string actual = "someName category - 0 products in total";

            //Act
            var expected = category.Print();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
