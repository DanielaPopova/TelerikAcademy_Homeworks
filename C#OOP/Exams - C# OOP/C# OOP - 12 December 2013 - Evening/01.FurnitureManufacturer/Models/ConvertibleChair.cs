namespace FurnitureManufacturer.Models
{
    using System;

    using Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10m;

        private bool isConverted;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.isConverted = false;
        }
       
        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }            
        }

        public override decimal Height
        {
            get
            {
                if (this.IsConverted)
                {
                    return ConvertedHeight;
                }
                else
                {
                    return base.Height;
                }
            }

            protected set
            {
                base.Height = value;
            }
        }

        public void Convert()
        {
            this.isConverted = !this.isConverted;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
