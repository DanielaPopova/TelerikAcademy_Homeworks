namespace Cosmetics.Tests.Engine.CosmeticsFactoryTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;
    using Cosmetics.Engine;
    using Cosmetics.Common;    
    using Contracts;

    [TestFixture]
    public class CreateToothpaste_Tests
    {
        [TestCase(null)]
        [TestCase("")]
        public void CreateToothpaste_PassedNameIsNullOrEmpty_ShouldThrowNullReferenceException(string mullOrEmptyName)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Act/Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(mullOrEmptyName, "someBrand", 12.0M, GenderType.Men, new List<string> { "validIng", "validIng"}));
        }

        [TestCase("aa")]
        [TestCase("aaaaaaaaaaa")]
        public void CreateToothpaste_PassedNameLenghtIsOutOfRange_ShouldThrowIndexOutOfRangeException(string nameOutOfRange)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Act/Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(nameOutOfRange, "someBrand", 12.0M, GenderType.Men, new List<string> { "validIng", "validIng" }));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateToothpaste_PassedBrandIsNullOrEmpty_ShouldThrowNullReferenceException(string mullOrEmptyBrand)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Act/Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste("someName", mullOrEmptyBrand, 12.0M, GenderType.Men, new List<string> { "validIng", "validIng" }));
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaa")]
        public void CreateToothpaste_PassedBrandLenghtIsOutOfRange_ShouldThrowIndexOutOfRangeException(string brandOutOfRange)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Act/Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("someName", brandOutOfRange, 12.0M, GenderType.Men, new List<string> { "validIng", "validIng" }));
        }

        [TestCase("a", "a")]
        [TestCase("tooLongIngredientsName", "tooLongIngredientsName")]
        [TestCase("a", "tooLongIngredientsName")]
        [TestCase("validIng", "tooLongIngredientsName")]
        public void CreateToothpaste_PassedIngredientsLengthInListIsOutOfRange_ShouldThrowIndexOutOfRangeException(params string[] listIngredients)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("someName","someBrand", 12.0M, GenderType.Men, listIngredients.ToList()));
        }

        [Test]
        public void CreateToothpaste_PassedParametersAreValid_ShouldReturnInstanceOfToothpaste()
        {
            // Arrange
            var factory = new CosmeticsFactory();

            // Act
            var actual = factory.CreateToothpaste("someName", "someBrand", 12.0M, GenderType.Men, new List<string>() { "validIng", "validIng" });

            // Assert
            Assert.IsInstanceOf<IToothpaste>(actual);
        }
    }
}
