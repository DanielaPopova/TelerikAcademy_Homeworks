namespace Cosmetics.Tests.Engine.CosmeticsFactoryTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Engine;    
    using Contracts;

    [TestFixture]
    public class CreateCategory_Tests
    {
        [TestCase(null)]
        [TestCase("")]
        public void CreateCategory_PassedNameIsNullOrEmpty_ShouldThrowNullReferenceException(string nullOrEmptyName)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(nullOrEmptyName));
        }

        [TestCase("a")]
        [TestCase("16aaaaaaaaaaaaaaaa")]
        public void CreateCategory_PassedNameLengthIsOutOfRange_ShouldThrowIndexOutOfRangeException(string outOfRangeName)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(outOfRangeName));
        }

        [Test]
        public void CreateCategory_PassedNameIsValid_ShouldReturnInstanceOfCategory()
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Act
            var actualProduct = factory.CreateCategory("someName");

            //Assert
            Assert.IsInstanceOf<ICategory>(actualProduct);
        }
    }
}
