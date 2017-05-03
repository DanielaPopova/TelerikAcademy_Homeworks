namespace SchoolSystem.Tests.Models
{
    using System;

    using Enums;
    using SchoolSystem.Models;

    using NUnit.Framework;    

    [TestFixture]
    public class MarkTests
    {
        [Test]
        public static void Constructor_WhenSubjectIsValid_ShouldBeCorrectlyAssaigned()
        {
            var expectedSubject = Subject.Bulgarian;
            var value = 2;

            var mark = new Mark(expectedSubject, value);

            Assert.AreEqual(expectedSubject, mark.Subject);
        }

        [Test]
        public static void Constructor_WhenValueIsValid_ShouldBeCorrectlyAssaigned()
        {
            var subject = Subject.Bulgarian;
            var expectedValue = 2;

            var mark = new Mark(subject, expectedValue);

            Assert.AreEqual(expectedValue, mark.Value);
        }

        [TestCase(-1f)]
        [TestCase(1f)]
        [TestCase(7f)]
        public void Constructor_WhenValueIsInvalid_ShouldThrowArgumentException(float invalidValue)
        {
            var subject = Subject.Bulgarian;

            Assert.Throws<ArgumentException>(() => new Mark(subject, invalidValue));
        }

        [TestCase(2f)]
        [TestCase(4f)]
        [TestCase(6f)]
        public void Constructor_WhenValueIsValid_ShouldNotThrowArgumentException(float validValue)
        {
            var subject = Subject.Bulgarian;

            Assert.DoesNotThrow(() => new Mark(subject, validValue));
        }
    }
}
