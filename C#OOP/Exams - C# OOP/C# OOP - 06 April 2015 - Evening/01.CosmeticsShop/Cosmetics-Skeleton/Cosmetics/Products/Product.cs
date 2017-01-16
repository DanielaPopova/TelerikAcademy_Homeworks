namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        private const int NameLengthMin = 3;
        private const int BrandLengthMin = 2;
        private const int StringLengthMax = 10;
        private const string ProductName = "Product name";
        private const string ProductBrand = "Product brand";

        private string name;
        private string brand;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, GlobalErrorMessages.StringCannotBeNullOrEmpty);
                Validator.CheckIfStringLengthIsValid(value, StringLengthMax, NameLengthMin, string.Format(GlobalErrorMessages.InvalidStringLength, ProductName, NameLengthMin, StringLengthMax));
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            protected set
            {
                Validator.CheckIfStringIsNullOrEmpty(GlobalErrorMessages.StringCannotBeNullOrEmpty);
                Validator.CheckIfStringLengthIsValid(value, StringLengthMax, BrandLengthMin, string.Format(GlobalErrorMessages.InvalidStringLength, ProductBrand, BrandLengthMin, StringLengthMax));
                this.brand = value;
            }
        }

        public decimal Price { get; protected set; }        

        public GenderType Gender { get; protected set; }       

        public virtual string Print()
        {            
            var result = new StringBuilder();
            result.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(string.Format("  * Price: ${0}", this.Price));
            result.AppendLine(string.Format("  * For gender: {0}", this.Gender));

            return result.ToString().Trim();
        }
    }
}
