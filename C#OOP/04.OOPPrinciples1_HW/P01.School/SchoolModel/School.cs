namespace Schools.SchoolModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;   

    public class School
    {
        private List<SchoolClass> classes;

        public School()
        {
            this.Classes = new List<SchoolClass>();
        }

        public List<SchoolClass> Classes
        {
            get
            {
                return this.classes;
            }

            private set
            {
                this.classes = value;
            }
        }

        public void AddClass(SchoolClass someClass)
        {
            this.Classes.Add(someClass);
        }

        public void RemoveClass(SchoolClass someClass)
        {
            if (this.Classes.Count == 0)
            {
                throw new ArgumentException("There are no classes!");
            }
            else
            {
                this.Classes.Remove(someClass);
                SchoolClass.uniqueIds.Remove(someClass.Id);
            }
        }

        public string PrintSchoolInfo()
        {
            StringBuilder schoolInfo = new StringBuilder();

            schoolInfo.Append("School information:\n");
            foreach (var someClass in this.Classes)
            {
                schoolInfo.Append(someClass.PrintClassInfo() + "\n");
            }

            return schoolInfo.ToString();
        }
    }
}