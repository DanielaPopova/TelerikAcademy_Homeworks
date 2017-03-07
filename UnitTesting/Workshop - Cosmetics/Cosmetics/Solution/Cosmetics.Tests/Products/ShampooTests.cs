namespace Cosmetics.Tests.Products
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Products;
    using Cosmetics.Common;
    using System.Text;

    [TestFixture]
    public class ShampooTests
    {
        [Test]
        public void Print_ShouldReturnStringWithShampooDetails()
        {
            //Arrange            
            var shampoo = new Shampoo("someName", "someBrand", 12.0M, GenderType.Men, 200, UsageType.EveryDay);

            var expected = new StringBuilder();
            expected.AppendLine("- someBrand - someName:");
            expected.AppendLine("  * Price: $2400.0");
            expected.AppendLine("  * For gender: Men");
            expected.AppendLine("  * Quantity: 200 ml");
            expected.Append("  * Usage: EveryDay");
            
            //Act
            var actual = shampoo.Print();

            //Assert
            Assert.AreEqual(expected.ToString(), actual);
        }
    }
}
