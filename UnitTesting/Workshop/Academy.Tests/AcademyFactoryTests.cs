namespace Academy.Tests
{
    using System;

    using NUnit.Framework;
    using Core.Factories;
    using Models.Utils.LectureResources;
    using Models.Contracts;

    [TestFixture]
    public class AcademyFactoryTests
    {
        [Test]
        public void CreateLectureResource_PassedTypeIsInvalid_ShouldThrowArgumentException()
        {
            //Arrange
            var academyFactory = AcademyFactory.Instance;
            string invalidType = "invalid";

            //Act/Assert
            Assert.Throws<ArgumentException>(() => academyFactory.CreateLectureResource(invalidType, "someName", "someUrl"));
        }

        [Test]
        public void CreateLectureResource_PassedTypeIsVideo_ShouldCreateInstanceOfVideoResource()
        {
            //Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "video";

            //Act
            var actual = academyFactory.CreateLectureResource(type, "someName", "someUrl");
           
            //Assert
            //Assert.IsInstanceOf<ILectureResource>(actual); --true
            //Assert.That(actual, Is.InstanceOf<Resource>()); --> true           
            Assert.IsTrue(actual.GetType() == typeof(VideoResource), "Type should be {0}", actual.GetType().Name);
        }

        [Test]
        public void CreateLectureResource_PassedTypeIsPresentation_ShouldCreateInstanceOfPresentationResource()
        {
            //Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "presentation";

            //Act
            var actual = academyFactory.CreateLectureResource(type, "someName", "someUrl");

            //Assert
            Assert.IsTrue(actual.GetType() == typeof(PresentationResource), "Type should be {0}", actual.GetType().Name);
        }

        [Test]
        public void CreateLectureResource_PassedTypeIsDemo_ShouldCreateInstanceOfDemoResource()
        {
            //Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "demo";

            //Act
            var actual = academyFactory.CreateLectureResource(type, "someName", "someUrl");

            //Assert
            Assert.IsTrue(actual.GetType() == typeof(DemoResource), "Type should be {0}", actual.GetType().Name);
        }

        [Test]
        public void CreateLectureResource_PassedTypeIsHomework_ShouldCreateInstanceOfHomeworkResource()
        {
            //Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "homework";

            //Act
            var actual = academyFactory.CreateLectureResource(type, "someName", "someUrl");

            //Assert
            Assert.IsTrue(actual.GetType() == typeof(HomeworkResource), "Type should be {0}", actual.GetType().Name);
        }
    }
}
