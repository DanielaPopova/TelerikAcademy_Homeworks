namespace SchoolSystem.Test
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem.Contracts;
    using SchoolSystem.Models;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void SchoolConstructor_WithNullName_ShouldThrowAnException()
        {
            string testedName = null;

            var school = new School(testedName);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void SchoolConstructor_WithEmptyStringName_ShouldThrowAnException()
        {
            string testedName = "";

            var school = new School(testedName);
        }

        [TestMethod]
        public void SchoolName_ShouldReturnExpectedName()
        {
            string expectedName = "81-SOU";
            var school = new School("81-SOU");

            Assert.AreEqual(expectedName, school.SchoolName);
        }

        [TestMethod]
        public void SchoolConstructor_CreateInstanceOfStudentCollection_ShouldReturnTrue()
        {
            var school = new School("81-SOU");

            Assert.IsInstanceOfType(school.Students, typeof(ICollection<IStudent>));
        }

        [TestMethod]
        public void SchoolConstructor_CreateInstanceOfCourseCollection_ShouldReturnTrue()
        {
            var school = new School("81-SOU");

            Assert.IsInstanceOfType(school.Courses, typeof(ICollection<ICourse>));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void AdmitStudent_StudentIsNull_ShouldThrowAnException()
        {
            var school = new School("Whatever");
            Student student = null;

            school.AdmitStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = false)]
        public void AdmitStudent_StudentIsAlreadyInTheList_ShouldThrowAnException()
        {
            var school = new School("Whatever");
            var student = new Student("pesho", 45654);

            school.AdmitStudent(student);
            school.AdmitStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void AddCourse_CourseIsNull_ShouldThrowAnException()
        {
            var school = new School("Whatever");
            Course course = null;

            school.AddCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = false)]
        public void AddCourse_CourseIsAlreadyInTheList_ShouldThrowAnException()
        {
            var school = new School("Whatever");
            var course = new Course("C#");

            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void ExpellStudent_StudentIsNull_ShouldThrowAnException()
        {
            var school = new School("Whatever");
            Student student = null;

            school.ExpellStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = false)]
        public void ExpellStudent_StudentIsNotInTheList_ShouldThrowAnException()
        {
            var school = new School("Whatever");
            var student = new Student("Billy", 88854);

            school.ExpellStudent(student);
        }

        [TestMethod]
        public void ExpellStudent_SuccessfullyRemoveStudentIdAfterExpellingStudent_ShouldNotThrowAnException()
        {
            var school = new School("test shcool");
            uint testedID = 45455;
            var student = new Student("someName", testedID);

            school.AdmitStudent(student);
            school.ExpellStudent(student);

            //if id is not correctly removed, should throw an exception for already used id
            var newStudent = new Student("someName", testedID);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), AllowDerivedTypes = false)]
        public void RemoveCourse_CourseIsNull_ShouldThrowAnException()
        {
            var school = new School("Whatever");
            Course course = null;

            school.RemoveCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = false)]
        public void RemoveCourse_CourseIsNotInTheList_ShouldThrowAnException()
        {
            var school = new School("Whatever");
            var course = new Course("C#");

            school.RemoveCourse(course);         
        }
    }
}
