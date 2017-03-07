namespace Cosmetics.Tests.Engine.CosmeticsFactoryTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Engine;
    using Cosmetics.Common;    
    using Contracts;

    [TestFixture]
    public class CreateShampoo_Tests
    {
        [TestCase(null)]
        [TestCase("")]
        public void CreateShampoo_PassedNameIsNullOrEmpty_ShouldThrowNullReferenceException(string mullOrEmptyName)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Act/Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(mullOrEmptyName, "someBrand", 12.0M, GenderType.Men, 200, UsageType.EveryDay));
        }

        [TestCase("aa")]
        [TestCase("aaaaaaaaaaa")]
        public void CreateShampoo_PassedNameLenghtIsOutOfRange_ShouldThrowIndexOutOfRangeException(string nameOutOfRange)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Act/Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(nameOutOfRange, "someBrand", 12.0M, GenderType.Men, 200, UsageType.EveryDay));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateShampoo_PassedBrandIsNullOrEmpty_ShouldThrowNullReferenceException(string mullOrEmptyBrand)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Act/Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo("someName", mullOrEmptyBrand, 12.0M, GenderType.Men, 200, UsageType.EveryDay));
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaa")]
        public void CreateShampoo_PassedBrandLenghtIsOutOfRange_ShouldThrowIndexOutOfRangeException(string brandOutOfRange)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Act/Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo("someName", brandOutOfRange, 12.0M, GenderType.Men, 200, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_PassedParametersAreValid_ShouldReturnInstanceOfShampoo()
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Act
            var actualProduct = factory.CreateShampoo("someName", "someBrand", 12.0M, GenderType.Men, 200, UsageType.EveryDay);

            //Assert
            Assert.IsInstanceOf<IShampoo>(actualProduct);
        }
    }
}
