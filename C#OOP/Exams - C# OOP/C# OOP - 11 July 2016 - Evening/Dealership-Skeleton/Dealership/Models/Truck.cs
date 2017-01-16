namespace Dealership.Models
{
    using System;

    using Dealership.Common;
    using Dealership.Common.Enums;
    using Dealership.Contracts;

    public class Truck : Vehicle, ITruck
    {
        private const string WeightCapacityProperty = "Weight capacity";

        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(make, model, price, VehicleType.Truck)
        {
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }

            private set
            {
                Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity, string.Format(Constants.NumberMustBeBetweenMinAndMax, WeightCapacityProperty, Constants.MinCapacity, Constants.MaxCapacity));
                this.weightCapacity = value;
            }
        }

        protected override string PrintAdditionalInfo()
        {            
            return string.Format("  Weight Capacity: {0}t", this.WeightCapacity);
        }
    }
}
