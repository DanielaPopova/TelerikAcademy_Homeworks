namespace Schools.Disciplines
{
    using System;
    using Schools.Interfaces;

    public class Discipline
    {
        private DisciplineName name;
        private int numberOfLectures;
        private int numberOfExercises;

        public Discipline(DisciplineName name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public DisciplineName Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

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
    }
}
