namespace SchoolSystem.Tests.Models
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Moq;
    
    using SchoolSystem.Models.Contracts;
    using Enums;
    using SchoolSystem.Models;

    [TestFixture]
    public class StudentTests
    {
        [TestCase("validName")]
        [TestCase("tooooloooooongvalidnameeeeeee")]
        [TestCase("va")]
        public static void Constructor_PassedFirstNameIsValid_ShouldNotThrowArgumentException(string validFirstName)
        {
            var lastName = "Peshev";
            var grade = Grade.Second;

            Assert.DoesNotThrow(() => new Student(validFirstName, lastName, grade));
        }

        [TestCase("v")]
        [TestCase("tooooloooooonginvaaaalidnameeeeeee")]        
        public static void Constructor_PassedFirstNameIsInvalid_ShouldThrowArgumentException(string invalidFirstName)
        {
            var lastName = "Peshev";
            var grade = Grade.Second;

            Assert.Throws<ArgumentException>(() => new Student(invalidFirstName, lastName, grade));
        }

        [TestCase("validName")]
        [TestCase("tooooloooooongvalidnameeeeeee")]
        [TestCase("va")]
        public static void Constructor_PassedLastNameIsValid_ShouldNotThrowArgumentException(string validLastName)
        {
            var firstName = "Mitko";
            var grade = Grade.Second;

            Assert.DoesNotThrow(() => new Student(firstName, validLastName, grade));
        }

        [TestCase("v")]
        [TestCase("tooooloooooonginvaaaalidnameeeeeee")]
        public static void Constructor_PassedLastNameIsInvalid_ShouldThrowArgumentException(string invalidLastName)
        {
            var firstName = "Mitko";
            var grade = Grade.Second;

            Assert.Throws<ArgumentException>(() => new Student(firstName, invalidLastName, grade));
        }

        [Test]
        public static void Constructor_WhenStudentIsInitialized_ShouldCreateInstanceOfMarkList()
        {
            var student = new Student("Mitko", "geshev", Grade.Eleventh);

            Assert.IsInstanceOf<List<IMark>>(student.Marks);
        }

        [Test]
        public static void Constructor_WhenStudentIsInitialized_ShoulSetListOfMark()
        {
            var student = new Student("Mitko", "geshev", Grade.Eleventh);

            Assert.AreNotEqual(null, student.Marks);
        }

        [Test]
        public static void ListMarks_WhenMarkListIsEmpty_ShouldReturnResultWithCorrectMessage()
        {
            var correctMessage = "This student has no marks.";
            var student = new Student("Mitko", "Peshev", Grade.Eleventh);

            var expectedResult = student.ListMarks();

            Assert.AreEqual(correctMessage, expectedResult);
            Assert.That(expectedResult.Contains(correctMessage));
        }

        [Test]
        public static void ListMarks_WhenMarkListIsNotEmpty_ShouldCorrectlyPrintList()
        {
            var markMock = new Mock<IMark>();
            markMock.SetupGet(m => m.Subject).Returns(Subject.English);
            markMock.SetupGet(m => m.Value).Returns(5);

            var student = new Student("Mitko", "Peshev", Grade.Eleventh);
            student.Marks.Add(markMock.Object);

            var listedMarks = student.ListMarks();

            Assert.That(listedMarks.Contains("English"));
            Assert.That(listedMarks.Contains("5"));
        }
    }
}
