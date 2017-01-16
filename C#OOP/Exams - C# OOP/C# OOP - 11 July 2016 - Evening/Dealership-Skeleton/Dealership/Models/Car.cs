namespace Dealership.Models
{
    using System;

    using Dealership.Common;
    using Dealership.Common.Enums;
    using Contracts;

    public class Car : Vehicle, ICar
    {
        private const string SeatsProperty = "Seats";

        private int seats;

        public Car(string make, string model, decimal price, int seats)
            : base(make, model, price, VehicleType.Car)
        {
            this.Seats = seats;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }

            private set
            {
                Validator.ValidateIntRange(value, Constants.MinSeats, Constants.MaxSeats, string.Format(Constants.NumberMustBeBetweenMinAndMax, SeatsProperty, Constants.MinSeats, Constants.MaxSeats));
                this.seats = value;
            }
        }

        protected override string PrintAdditionalInfo()
        {
            return string.Format("  {0}: {1}", SeatsProperty, this.Seats);
        }
    }
}
