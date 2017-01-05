namespace StudentsAndWorkers.People
{
    using System;

    public class Student : Human
    {
        private double grade;

        public Student(string firstName, string lastName, double grade) : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public double Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                if (value < 2.0 || value > 6.0)
                {
                    throw new ArgumentException("Student's grade are in range 2.0 - 6.0");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Grade;
        }
    }
}
