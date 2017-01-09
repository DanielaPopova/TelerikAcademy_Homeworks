namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : Person
    {
        private List<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.disciplines = new List<Discipline>();
        }        

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            if (!this.disciplines.Contains(discipline))
            {
                throw new ArgumentException("There is no such discipline in the list!");
            }

            this.disciplines.Remove(discipline);
        }

        public string PrintDisciplines()
        {
            StringBuilder info = new StringBuilder();

            if (this.disciplines.Count == 0)
            {
                throw new ArgumentException("The list is empty!");
            }
            else
            {
                info.AppendLine(string.Format("{0} teaches:", this.Name));

                foreach (var discipline in this.disciplines)
                {
                    info.AppendLine(discipline.ToString());
                }
            }

            return info.ToString();          
        }

        public override string Comment()
        {
           return "I'm teaching";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
