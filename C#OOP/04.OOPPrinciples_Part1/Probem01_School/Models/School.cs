namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class School
    {        
        private List<SchoolClass> classes;

        public School(string name)
        {
            this.Name = name;
            this.classes = new List<SchoolClass>();
        }

        public string Name { get; private set; }

        public void AddClass(SchoolClass schoolClass)
        {
            this.classes.Add(schoolClass);
        }

        public void RemoveClass(SchoolClass schoolClass)
        {
            if (!this.classes.Contains(schoolClass))
            {
                throw new ArgumentException("There is no such class in the list!");
            }

            this.classes.Remove(schoolClass);
            SchoolClass.uniqueIDs.Remove(schoolClass.ID);
        }

        public string PrintSchoolInfo()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine(string.Format("***** Shcool {0} *****", this.Name));

            if (this.classes.Count != 0)
            {
                foreach (var schoolClass in this.classes)
                {
                    info.AppendLine(schoolClass.PrintClassInfo());
                }
            }

            return info.ToString();
        }
    }
}
