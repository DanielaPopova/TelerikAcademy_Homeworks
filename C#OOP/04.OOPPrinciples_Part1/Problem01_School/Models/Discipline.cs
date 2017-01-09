namespace SchoolSystem.Models
{
    using System;

    using SchoolSystem.Enumerations;

    public class Discipline
    {
        private int numberOfLectures;
        private int numberOfExercises;

        public Discipline(DisciplineType disciplineName, int lectures, int exercises)
        {
            this.DisciplineName = disciplineName;
            this.NumberOfLectures = lectures;
            this.NumberOfExercises = exercises;
        }

        public DisciplineType DisciplineName { get; set; }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Lectures can't be less than 0!");
                }

                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Exercises can't be less than 0!");
                }

                this.numberOfExercises = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Discipline: {0} | Lectures: {1} | Exercises: {2}", this.DisciplineName, this.NumberOfLectures, this.NumberOfExercises);
        }
    }
}
