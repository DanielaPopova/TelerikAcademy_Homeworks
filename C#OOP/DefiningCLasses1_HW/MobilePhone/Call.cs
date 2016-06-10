namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class Call
    {        
        private string dialledPhoneNumber;
        private int duration;

        public Call(DateTime dateTime)
            : this(dateTime, null, 0)
        {

        }

        public Call(DateTime dateTime, string diallednum, int duration)
        {      
            // TODO: validate DateTime dateTime for right format
            this.Date = dateTime.ToString("dd.MM.yyyy");
            this.Time = dateTime.ToString("HH:mm:ss");
            this.DialledPhoneNumber = diallednum;
            this.Duration = duration;
        }

        public string Date { get; private set; }

        public string Time { get; private set; }

        public string DialledPhoneNumber
        {
            get
            {
                return this.dialledPhoneNumber;
            }

            private set
            {
                if (value.Length < 9)
                {
                    throw new ArgumentException("Phone number is too short!");
                }
                else if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please add information about the dialled phone number!");
                }

                this.dialledPhoneNumber = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Duration can't be negative!");
                }               

                this.duration = value;
            }
        }

        public override string ToString()
        {
            List<string> fullInfo = new List<string>();

            fullInfo.Add("Date: " + this.Date);
            fullInfo.Add("Time: " + this.Time);
            fullInfo.Add("Dialled phone number: " + this.DialledPhoneNumber);
            fullInfo.Add("Duration: " + this.Duration);

            return string.Join("\t", fullInfo);
        }
    }
}
