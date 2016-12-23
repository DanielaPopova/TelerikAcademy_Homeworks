namespace MobilePhone.Classes
{
    using System;
    using System.Text;

    using MobilePhone.Enums;

    public class Battery
    {
        private string model;
        private int? hoursTalk;
        private int? hoursIdle;

        public Battery(BatteryType batteryType, int? hoursTalk, int? hoursIdle)            
        {
            this.BatteryType = batteryType;
            this.HoursTalk = hoursTalk;
            this.HoursIdle = hoursIdle;
        }

        public Battery(string model, BatteryType batteryType, int? hoursTalk, int? hoursIdle)
            : this(batteryType, hoursTalk, hoursIdle)
        {
            this.Model = model;            
        }        

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty string!");
                }

                this.model = value;
            }
        }

        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hours talk cannot be negative or zero!");
                }

                this.hoursTalk = value;
            }
        }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hours idle cannot be negative or zero!");                    
                }

                this.hoursIdle = value;
            }
        }

        public BatteryType BatteryType { get; private set; }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            string model = string.Format("Battery Model: {0}", this.Model ?? "N/A");
            string batteryType = string.Format("Battery Type: {0}", this.BatteryType);
            string hoursTalk = string.Format("Hours Talk: {0}", this.HoursTalk);
            string hoursIdle = string.Format("Hours Idle: {0}", this.HoursIdle);

            info.AppendLine(model)
                .AppendLine(batteryType)
                .AppendLine(hoursTalk)
                .AppendLine(hoursIdle);

            return info.ToString();
        }
    }
}
