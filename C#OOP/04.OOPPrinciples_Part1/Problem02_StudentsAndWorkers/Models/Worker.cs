namespace StudentsAndWorkers.Models
{
    using System;

    public class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            private set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException("Salary cannot be negative number");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            private set
            {
                if (value < 0.0 || value > 24.0)
                {
                    throw new ArgumentException("There are no more than 24 hours in a day!");
                }

                this.workHoursPerDay = value;
            }
        }

        public double MoneyPerHour()
        {
            return this.WeekSalary / (5 * this.WorkHoursPerDay);
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Money per hour: {0:F2} BGN/hour", this.MoneyPerHour());
        }
    }
}
