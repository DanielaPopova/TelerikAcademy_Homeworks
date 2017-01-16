namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Dealership.Common;
    using Dealership.Common.Enums;
    using Dealership.Contracts;

    public abstract class Vehicle : IVehicle, ICommentable, IPriceable
    {
        private const string MakeProperty = "Make";
        private const string ModelProperty = "Model";
        private const string WheelsProperty = "Wheels";
        private const string PriceProperty = "Price";
        private const string NoCommentsHeader = "    --NO COMMENTS--";
        private const string CommentsHeader = "    --COMMENTS--";

        private string make;
        private string model;
        private int wheels;
        private decimal price;

        public Vehicle(string make, string model, decimal price, VehicleType type)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Type = type;
            this.Wheels = (int)type;
            this.Comments = new List<IComment>();
        }

        public string Make
        {
            get
            {
                return this.make;
            }

            private set
            {
                Validator.ValidateNull(value, string.Format(Constants.StringCannotBeNull, MakeProperty));
                Validator.ValidateIntRange(value.Length, Constants.MinMakeLength, Constants.MaxMakeLength, string.Format(Constants.StringMustBeBetweenMinAndMax, MakeProperty, Constants.MinMakeLength, Constants.MaxMakeLength));
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validator.ValidateNull(value, string.Format(Constants.StringCannotBeNull, ModelProperty));
                Validator.ValidateIntRange(value.Length, Constants.MinModelLength, Constants.MaxModelLength, string.Format(Constants.StringMustBeBetweenMinAndMax, ModelProperty, Constants.MinModelLength, Constants.MaxModelLength));
                this.model = value;
            }
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }

            private set
            {
                Validator.ValidateIntRange(value, Constants.MinWheels, Constants.MaxWheels, string.Format(Constants.NumberMustBeBetweenMinAndMax, WheelsProperty, Constants.MinWheels, Constants.MaxWheels));
                this.wheels = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                Validator.ValidateDecimalRange(value, Constants.MinPrice, Constants.MaxPrice, string.Format(Constants.NumberMustBeBetweenMinAndMax, PriceProperty, Constants.MinPrice, Constants.MaxPrice));
                this.price = value;
            }
        }        

        public VehicleType Type { get; protected set; }
        
        public IList<IComment> Comments { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("{0}:", this.GetType().Name));
            result.AppendLine(string.Format("  {0}: {1}", MakeProperty, this.Make));
            result.AppendLine(string.Format("  {0}: {1}", ModelProperty, this.Model));
            result.AppendLine(string.Format("  {0}: {1}", WheelsProperty, this.Wheels));
            result.AppendLine(string.Format("  {0}: ${1}", PriceProperty, this.Price));
            result.AppendLine(this.PrintAdditionalInfo());
            result.AppendLine(this.PrintComments());

            return result.ToString().TrimEnd();
        }

        protected abstract string PrintAdditionalInfo();

        private string PrintComments()
        {
            var result = new StringBuilder();

            if (this.Comments.Count <= 0)
            {
                result.AppendLine(string.Format("{0}", NoCommentsHeader));
            }
            else
            {
                result.AppendLine(string.Format("{0}", CommentsHeader));

                foreach (var comment in this.Comments)
                {
                    result.AppendLine(comment.ToString());
                }

                result.AppendLine(string.Format("{0}", CommentsHeader));
            }

            return result.ToString().TrimEnd();
        }
    }
}
