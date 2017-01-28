namespace Problem09_18.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;    

    public class Student
    {
        private string firstName;
        private string lastName;
        private int facultyNumber;        
        private string email;
        private List<int> marks;
        private int groupNumber;

        public Student()
        {

        }
        
        public Student(string firstName, string lastName, int facultyNumber, string phoneNumber, string email, List<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("First name should be longer than 2 symbols!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Last name should be longer than 2 symbols!");
                }

                this.lastName = value;
            }
        }

        public int FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            private set
            {
                if (Math.Floor(Math.Log10(value) + 1) != 6)
                {
                    throw new ArgumentOutOfRangeException("Faculty number is a 6-digit number!");
                }

                this.facultyNumber = value;
            }
        }

        public string PhoneNumber { get; private set; }

        public string Email
        {
            get
            {
                return this.email;
            }

            private set
            {
                if (!value.Contains("@"))
                {
                    throw new ArgumentException("Wrong email address!");
                }

                this.email = value;
            }
        }

        public List<int> Marks
        {
            get
            {
                if (this.marks.Count == 0)
                {
                    throw new ArgumentException("The student doesn't have marks!");
                }

                return this.marks;
            }

            set
            {
                foreach (var mark in value)
                {
                    if (mark < 2 || mark > 7)
                    {
                        throw new ArgumentException("Student's mark are in range from 2 to 6!");
                    }
                }

                this.marks = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }

            private set
            {
                if (value <= 0 || value >= 11)
                {
                    throw new ArgumentOutOfRangeException("Groups are numbered 1 to 10!");
                }

                this.groupNumber = value;
            }
        } 
       
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append("First name: " + this.FirstName + Environment.NewLine);
            info.Append("Last name: " + this.LastName + Environment.NewLine);
            info.Append("Faculty number: " + this.FacultyNumber + Environment.NewLine);
            info.Append("Phone number: " + this.PhoneNumber + "\n");
            info.Append("Email: " + this.Email + "\n");
            info.Append("Marks: " + string.Join(" ", this.Marks) + "\n");
            info.Append("Group number: " + this.GroupNumber + "\n");

            return info.ToString();
        }       
    }
}