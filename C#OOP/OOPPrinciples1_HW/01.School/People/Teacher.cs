namespace Schools.People
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Schools.Disciplines;
    

    public class Teacher : Person
    {
        private List<Discipline> disciplines;

        public Teacher(string name) : base(name)
        {
            this.Disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }

            private set
            {
                this.disciplines = value;
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.Disciplines.Add(discipline);
        }

        public void DeleteDiscipline(Discipline discipline)
        {
            if (this.Disciplines.Count == 0)
            {
                throw new ArgumentException("There are no disciplines!");
            }
            else
            {
                this.Disciplines.Remove(discipline);
            }
        }

        public string PrintDisciplinesInfo()
        {
            StringBuilder info = new StringBuilder();

            foreach (var discipline in this.Disciplines)
            {
                info.Append("Discipline: " + discipline.Name + " Lectures: " + discipline.NumberOfLectures + " Exercises: " + discipline.NumberOfExercises + Environment.NewLine);
            }

            return info.ToString();
        }

        public override void Comment()
        {
            Console.WriteLine("I'm teaching");
        }
    }
}
