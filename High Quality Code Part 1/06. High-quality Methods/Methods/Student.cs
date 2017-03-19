namespace QualityMethods
{
    using System;

    public class Student
    {
        private const string NullOrEmptyError = "{0} cannot be null or empty string!";
        private const int MinAge = 0;
        private const int MaxAge = 120;

        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private string birthPlace;
        private string otherInfo;

        public Student(string firstName, string lastName, DateTime birthDate, string birthPlace)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.BirthPlace = birthPlace;
        }

        public Student(string firstName, string lastName, DateTime birthDate, string birthPlace, string otherInfo)
            : this(firstName, lastName, birthDate, birthPlace)
        {
            this.OtherInfo = otherInfo;
        }

        // You could actually change your name - not private set
        public string FirstName 
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(NullOrEmptyError, "First name"));
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

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(NullOrEmptyError, "Last name"));
                }

                this.lastName = value;
            }
        }

        public DateTime BirthDate
        { 
            get
            {
                return this.birthDate;
            }

            private set
            {
                this.ValidateBirthDate(value);
                this.birthDate = value;
            }
        }

        public string BirthPlace
        {
            get
            {
                return this.birthPlace;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(NullOrEmptyError, "Place of birth"));
                }

                this.birthPlace = value;
            }
        }

        public string OtherInfo
        { 
            get
            {
                return this.otherInfo;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(NullOrEmptyError, "Other info"));
                }

                this.otherInfo = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            // 'other' birth year should be bigger in order for 'this' to be older (1988 < 1990)
            return this.BirthDate < other.BirthDate;
        }

        private void ValidateBirthDate(DateTime birthDate)
        {
            // Same birth year as current, but birth month/day after birth month/day of current should throw exception
            bool isBorn = birthDate.Month <= DateTime.Now.Month && birthDate.Day <= DateTime.Now.Day;
            int currentAge = DateTime.Now.Year - birthDate.Year;

            if (currentAge == MinAge && !isBorn)
            {
                throw new ArgumentException("Not born yet!");
            }           

            if (currentAge < MinAge || currentAge > MaxAge)
            {
                throw new ArgumentException("Invalid birth date!");
            }           
        }
    }
}
