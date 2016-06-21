namespace Schools.People
{
    using System;
    using System.Collections.Generic;

    public class Student : Person
    {
        private int classNumber;
        internal static List<int> uniqueClassNumber = new List<int>();

        public Student(string name, int classNum) : base(name)
        {            
            this.ClassNumber = classNum;
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            private set
            {                
                if (value <= 0)
                {
                    throw new ArgumentException("Students numbers start from 1");
                }

                if (value > 30)
                {
                    throw new ArgumentException("There are up to 30 students in a class!");                    
                }

                if (uniqueClassNumber.Contains(value))
                {
                    throw new ArgumentException("There is already a student with that class number!");
                }
                else
                {
                    uniqueClassNumber.Add(value);
                }
                
                this.classNumber = value; 
            }
        }

        public override string ToString()
        {
            return string.Format(this.Name + " Number: " + this.ClassNumber);
        }

        public override void Comment()
        {
            Console.WriteLine("I'm studying");
        }    
    }
}
