namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Student : Person
    {
        internal static List<int> uniqueClassNumbers = new List<int>();
        private int classNumber;

        public Student(string name, int classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            private set
            {
                if (value <= 0 || value > 30)
                {
                    throw new ArgumentException("Students have class numbers from 1 to 30!");
                }

                this.ValidateClassNumber(value);

                this.classNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" \u2116{0}", this.ClassNumber);
        }

        public override string Comment()
        {
            return "I'm learning";
        }

        private void ValidateClassNumber(int classNum)
        {
            if (!uniqueClassNumbers.Contains(classNum))
            {
                uniqueClassNumbers.Add(classNum);               
            }
            else
            {
                throw new ArgumentException("There can't be students with same class number!");
            }           
        }
    }
}
