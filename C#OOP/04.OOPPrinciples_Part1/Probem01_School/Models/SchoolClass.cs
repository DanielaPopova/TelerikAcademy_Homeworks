namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SchoolClass
    {
        internal static List<string> uniqueIDs = new List<string>();
        private string id;
        private List<Teacher> teachers;
        private List<Student> students;

        public SchoolClass(string id)
        {
            this.ID = id;
            this.teachers = new List<Teacher>();
            this.students = new List<Student>();
        }

        public string ID
        {
            get
            {
                return this.id;
            }

            private set
            {
                this.ValidateID(value);

                this.id = value;
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            if (!this.teachers.Contains(teacher))
            {
                throw new ArgumentException("There is no such teacher in the list!");
            }

            this.teachers.Remove(teacher);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.students.Contains(student))
            {
                throw new ArgumentException("There is no such teacher in the list!");
            }

            this.students.Remove(student);
            Student.uniqueClassNumbers.Remove(student.ClassNumber);
        }

        public string PrintClassInfo()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine(string.Format("=== Class {0} ===", this.ID));

            info.AppendLine("Teachers:");

            if (this.teachers.Count != 0)
            {
                foreach (var teacher in this.teachers)
                {
                    info.AppendLine(teacher.PrintDisciplines());
                }
            }

            info.AppendLine("Students:");

            if (this.students.Count != 0)
            {
                foreach (var student in this.students)
                {
                    info.AppendLine(student.ToString());
                }
            }

            return info.ToString();
        }

        private void ValidateID(string id)
        {
            if (!uniqueIDs.Contains(id))
            {
                uniqueIDs.Add(id);
            }
            else
            {
                throw new ArgumentException("There can't be classes with same id!");
            }
        }
    }
}
