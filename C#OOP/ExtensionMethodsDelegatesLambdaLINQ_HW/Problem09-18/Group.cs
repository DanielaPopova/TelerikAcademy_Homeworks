namespace Problem09_15
{
    using System;

    public class Group
    {
        private int groupNumber;
        private string departmentName;

        public Group(int groupNum, string department)
        {
            this.GroupNumber = groupNum;
            this.departmentName = department;
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }

            private set
            {
                if (value <= 0 || value > 11)
                {
                    throw new ArgumentException("Groups are from 1 to 10");
                }

                this.groupNumber = value;
            }
        }

        public string Department
        {
            get
            {
                return this.departmentName;
            }

            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("There is no such department!");
                }

                this.departmentName = value;
            }
        }        
    }
}