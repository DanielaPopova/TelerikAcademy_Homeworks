namespace MobilePhone
{
    using System;
    using System.Text;

    public enum BatteryType
    {
        LiIon,
        NiMH,
        NiCd,
        Unknown
    }

    public class Battery
    {
        private double? hoursIdle;
        private double? hoursTalk;

        public Battery()
            : this(null, new BatteryType(), null, null)
        {

        }

        public Battery(BatteryType battType)
            : this(null, battType, null, null)
        {

        }

        public Battery(string model, BatteryType batteryType, double? hoursIdle, double? hoursTalk)
        {
            this.Model = model;
            this.BatteryType = batteryType;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public string Model { get; set; }

        public BatteryType BatteryType { get; set; }

        public double? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hours can't be negative!");
                }

                this.hoursIdle = value;
            }
        }

        public double? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hours can't be negative!");
                }

                this.hoursTalk = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append("Battery model: " + this.Model);

            output.Append("\nBattery type: " + this.BatteryType);

            output.Append("\nHours idle/talk: ");

            if (this.HoursIdle == null)
            {
                output.Append("No info/");
            }
            else
            {
                output.Append(this.HoursIdle + "/");
            }

            if (this.HoursTalk == null)
            {
                output.Append("No info");
            }
            else
            {
                output.Append(this.HoursTalk);
            }

            return output.ToString();
        }
    }
}

/* 
Layout convention

Fields
Constructors
Finalizers (Destructors)
Delegates
Events
Enums
Interfaces
Properties
Indexers
Methods
Structs
Classes
*/