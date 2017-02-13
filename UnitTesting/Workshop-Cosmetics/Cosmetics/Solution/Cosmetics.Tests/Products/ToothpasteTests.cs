namespace Cosmetics.Tests.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using NUnit.Framework;
    using Cosmetics.Products;
    using Cosmetics.Common;

    [TestFixture]
    public class ToothpasteTests
    {
        [Test]
        public void Print_ShouldReturnStringWithToothpasteDetails()
        {
            // Arrange
            var toothpaste = new Toothpaste("someName", "someBrand", 12M, GenderType.Men, new List<string>() { "validIng", "validIng" });

            var expected = new StringBuilder();
            expected.AppendLine("- someBrand - someName:");
            expected.AppendLine("  * Price: $12");
            expected.AppendLine("  * For gender: Men");
            expected.Append("  * Ingredients: validIng, validIng");

            // Act
            var actual = toothpaste.Print();

            // Assert
            Assert.AreEqual(expected.ToString(), actual);
        }
    }
}
