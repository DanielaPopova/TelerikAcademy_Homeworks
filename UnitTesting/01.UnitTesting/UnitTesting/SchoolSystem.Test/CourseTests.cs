namespace SchoolSystem.Test
{
    using System;   
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchoolSystem.Contracts;
    using SchoolSystem.Models;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void CourseConstructor_WithNullName_ShouldThrowAnException()
        {
            string testedName = null;

            var course = new Course(testedName);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void CourseConstructor_WithEmptyStringName_ShouldThrowAnException()
        {
            string testedName = "";

            var course = new Course(testedName);
        }

        [TestMethod]
        public void CourseConstructor_CreateInstanceOfStudentCollection_ShouldReturnTrue()
        {
            var course = new Course("OOP");

            Assert.IsInstanceOfType(course.Students, typeof(ICollection<IStudent>));
        }

        [TestMethod]
        public void Course_ShoulReturnExpectedName()
        { 
            var course = new Course("OOP");

            Assert.AreEqual("OOP", course.CourseName);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void AddStudent_StudentIsNull_ShouldThrowAnException()
        {
            var course = new Course("JS OOP");
            Student student = null;

            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = false)]
        public void AddStudent_CourseIsFilledWithMaximumStudentsCount_ShouldThrowAnException()
        {
            var course = new Course("JS OOP");
            int maxStudentsInCourse = 30;

            for (int i = 0; i <= maxStudentsInCourse + 1; i++)
            {
                var student = new Student(i.ToString(), 10000 + (uint)i);
                course.AddStudent(student);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = false)]
        public void AddStudent_StudentIsAlreadyInTheList_ShouldThrowAnException()
        {
            var course = new Course("JS OOP");
            var student = new Student("George", 10000);

            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void RemoveStudent_StudentIsNull_ShouldThrowAnException()
        {
            var course = new Course("JS OOP");
            Student student = null;

            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = false)]
        public void RemoveStudent_StudentIsNotInTheList_ShouldThrowAnException()
        {
            var course = new Course("JS OOP");
            var student = new Student("George", 10000);

            course.RemoveStudent(student);           
        }
    }
}
