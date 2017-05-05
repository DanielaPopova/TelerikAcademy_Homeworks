namespace SchoolSystem.Tests.Models
{
    using System;
    using NUnit.Framework;
    using Moq;
    using Enums;
    using SchoolSystem.Models;
    using SchoolSystem.Models.Contracts;
    using System.Collections.Generic;

    [TestFixture]
    public class TeacherTests
    {
        [TestCase("validName")]
        [TestCase("tooooloooooongvalidnameeeeeee")]
        [TestCase("va")]
        public static void Constructor_PassedFirstNameIsValid_ShouldNotThrowArgumentException(string validFirstName)
        {
            var lastName = "Peshev";
            var subject = Subject.Bulgarian;

            Assert.DoesNotThrow(() => new Teacher(validFirstName, lastName, subject));
        }

        [TestCase("v")]
        [TestCase("tooooloooooonginvaaaalidnameeeeeee")]
        public static void Constructor_PassedFirstNameIsInvalid_ShouldThrowArgumentException(string invalidFirstName)
        {
            var lastName = "Peshev";
            var subject = Subject.Bulgarian;

            Assert.Throws<ArgumentException>(() => new Teacher(invalidFirstName, lastName, subject));
        }

        [TestCase("validName")]
        [TestCase("tooooloooooongvalidnameeeeeee")]
        [TestCase("va")]
        public static void Constructor_PassedLastNameIsValid_ShouldNotThrowArgumentException(string validLastName)
        {
            var firstName = "Mitko";
            var subject = Subject.Bulgarian;

            Assert.DoesNotThrow(() => new Teacher(firstName, validLastName, subject));
        }

        [TestCase("v")]
        [TestCase("tooooloooooonginvaaaalidnameeeeeee")]
        public static void Constructor_PassedLastNameIsInvalid_ShouldThrowArgumentException(string invalidLastName)
        {
            var firstName = "Mitko";
            var subject = Subject.Bulgarian;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, invalidLastName, subject));
        }

        [Test]
        public static void Constructor_PassedValuesAreValid_ShouldBeCorrectlyAssaigned()
        {
            var validFirstName = "Mitko";
            var validLastName = "Peshev";
            var validSubject = Subject.English;

            var teacher = new Teacher(validFirstName, validLastName, validSubject);

            Assert.AreEqual(validFirstName, teacher.FirstName);
            Assert.AreEqual(validLastName, teacher.LastName);
            Assert.AreEqual(validSubject, teacher.Subject);
        }

        [Test]
        public static void AddMark_StudentMarkListCountIsBiggerThan20_ShouldThrowArgumenException()
        {
            var tooMuchMarks = 22;
            var studentMock = new Mock<IStudent>();
            var markMock = new Mock<IMark>();
            var listMarks = new List<IMark>();

            for (int i = 0; i <= tooMuchMarks; i++)
            {
                listMarks.Add(markMock.Object);
            }

            studentMock.SetupGet(st => st.Marks).Returns(listMarks);

            var teacher = new Teacher("Motko", "Peshev", Subject.English);

            Assert.Throws<ArgumentException>(() => teacher.AddMark(studentMock.Object, 5.0f));
        }

        [Test]
        public static void AddMark_StudentMarksCountIsLessThan20_ShouldAddValue()
        {
            var markMock = new Mock<IMark>();
            var listMarks = new List<IMark>();
            listMarks.Add(markMock.Object);

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Marks).Returns(listMarks);

            var teacher = new Teacher("Motko", "Peshev", Subject.English);
            teacher.AddMark(studentMock.Object, 5);

            CollectionAssert.Contains(studentMock.Object.Marks, markMock.Object);
        }
    }
}
