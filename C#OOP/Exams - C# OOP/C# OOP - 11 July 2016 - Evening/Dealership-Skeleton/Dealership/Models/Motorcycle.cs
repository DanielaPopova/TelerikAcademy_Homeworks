namespace Dealership.Models
{
    using System;

    using Dealership.Common;
    using Dealership.Common.Enums;
    using Dealership.Contracts;

    public class Motorcycle : Vehicle, IMotorcycle
    {
        private const string CategoryProperty = "Category";

        private string category;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price, VehicleType.Motorcycle)
        {
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }

            private set
            {
                Validator.ValidateNull(value, string.Format(Constants.StringCannotBeNull, CategoryProperty));
                Validator.ValidateIntRange(value.Length, Constants.MinCategoryLength, Constants.MaxCategoryLength, string.Format(Constants.StringMustBeBetweenMinAndMax, CategoryProperty, Constants.MinCategoryLength, Constants.MaxCategoryLength));
                this.category = value;
            }
        }

        protected override string PrintAdditionalInfo()
        {
            return string.Format("  {0}: {1}", CategoryProperty, this.Category);
        }
    }
}
