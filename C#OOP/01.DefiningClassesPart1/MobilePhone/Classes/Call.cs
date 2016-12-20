namespace MobilePhone.Classes
{
    using System;
    using System.Text;

    public class Call
    {
        private string dialledPhoneNumber;
        private int duration;

        public Call(DateTime dateTime, string dialledNum, int duration)
        {
            // TODO: validate DateTime dateTime for right format
            this.Date = dateTime.ToString("dd.MM.yyyy");
            this.Time = dateTime.ToString("HH:mm:ss");
            this.DialledPhoneNumber = dialledNum;
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

                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
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
            StringBuilder fullInfo = new StringBuilder();

            fullInfo.Append("Date: " + this.Date + " // ")
                    .Append("Time: " + this.Time + " // ")
                    .Append("Dialled phone number: " + this.DialledPhoneNumber + " // ")
                    .Append("Duration: " + this.Duration);

            return fullInfo.ToString();
        }
    }
}
