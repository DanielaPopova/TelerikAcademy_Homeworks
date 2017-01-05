namespace Schools.SchoolModel
{    
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Schools.People;

    public class SchoolClass
    {
        internal static List<string> uniqueIds = new List<string>();
        private string id;
        private List<Student> students;
        private List<Teacher> teachers;

        public SchoolClass(string id)
        {
            this.Id = id;
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }

            private set
            {
                this.students = value;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }

            private set
            {
                this.teachers = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Class Id mst have more than 1 symbols");
                }

                if (uniqueIds.Contains(value))
                {
                    throw new ArgumentException("There is already a class with that ID!");
                }
                else
                {
                    uniqueIds.Add(value);
                }

                this.id = value;
            }
        }

        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }

        public void Addteacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }

        public void RemoveStudent(Student student)
        {
            if (this.Students.Count == 0)
            {
                throw new ArgumentException("There are no students!");
            }
            else
            {
                this.Students.Remove(student);
                Student.uniqueClassNumber.Remove(student.ClassNumber);
            }
        }

        public void RemoveTeacher(Teacher teacher)
        {
            if (this.Teachers.Count == 0)
            {
                throw new ArgumentException("there are no teachers!");
            }
            else
            {
                this.Teachers.Remove(teacher);
            }
        }

        public string PrintClassInfo()
        {
            StringBuilder classInfo = new StringBuilder();

            classInfo.Append(this.Id + " class\n");
            classInfo.Append("Teachers:\n");
            foreach (var teacher in this.Teachers)
            {
                classInfo.Append(teacher.Name + "\n" + teacher.PrintDisciplinesInfo());
            }

            classInfo.Append("Students:\n");

            foreach (var student in this.Students)
            {
                classInfo.Append(student.Name + " Number: " + student.ClassNumber + "\n");
            }

            return classInfo.ToString();
        }       
    }
}
