namespace SchoolSystem.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchoolSystem.Models;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void StudentConstructor_WithNullName_ShouldThrowAnException()
        {
            string studentName = null;
            uint studentId = 10000;

            var student = new Student(studentName, studentId);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void StudentConstructor_WithEmptyStringName_ShouldThrowAnException()
        {
            string studentName = "";
            uint studentId = 10000;

            var student = new Student(studentName, studentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = false)]
        public void StudentConstructor_WithLowerRangeID_ShouldThrowAnException()
        {
            string studentName = "Pesho";
            uint studentID = 100;

            var student = new Student(studentName, studentID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = false)]
        public void StudentConstructor_WithUpperRangeID_ShouldThrowAnException()
        {
            string studentName = "Pesho";
            uint studentID = 100000;

            var student = new Student(studentName, studentID);
        }

        [TestMethod]
        public void Student_ShouldReturnExpectedName()
        {
            string expectedName = "pesho";

            var student = new Student("pesho", 99998);

            Assert.AreEqual(expectedName, student.Name);
        }

        [TestMethod]
        public void Student_ShouldReturnExpectedID()
        {
            uint expectedId = 20000;

            var student = new Student("pesho", expectedId);

            Assert.AreEqual(expectedId, student.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_WithAlreadyUsedID_ShouldThrowAnException()
        {
            uint firstId = 66666;
            uint secondId = 66666;

            var firstStudent = new Student("pesho", firstId);
            var secondStudent = new Student("pesho", secondId);           
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void JoinCourse_CourseIsNull_ShouldThrowAnException()
        {
            var student = new Student("stoyan", 45698);
            Course course = null;

            student.JoinCourse(course);
        }

        [TestMethod]
        public void JoinCourse_ValidStudentAndCourse_ShouldNotThrowAnException()
        {
            string studentName = "Mimi";
            uint studentID = 84735;
            var student = new Student(studentName, studentID);

            string courseName = "Unit testing";
            var course = new Course(courseName);

            student.JoinCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void LeaveCourse_CourseIsNull_ShouldThrowAnException()
        {
            var student = new Student("dimityr", 66978);
            Course course = null;

            student.LeaveCourse(course);
        }

        [TestMethod]
        public void LeaveCourse_ValidStudentAndCourse_ShouldNotThrowAnException()
        {
            string studentName = "Deni";
            uint studentID = 55556;
            var student = new Student(studentName, studentID);

            string courseName = "HQC";
            var course = new Course(courseName);

            student.JoinCourse(course);
            student.LeaveCourse(course);
        }
    }
}
