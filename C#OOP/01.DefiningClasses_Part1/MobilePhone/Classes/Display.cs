namespace MobilePhone
{
    using System;    
    using System.Text;

    public class Display
    {
        private double? size;
        private uint? colors;

        public Display(double? size, uint? colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public Display(double? size)
            : this(size, null)
        {
        }

        public double? Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Display size cannot be zero or smaller!");
                }

                this.size = value;
            }
        }

        public uint? Colors
        {
            get
            {
                return this.colors;
            }

            private set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Number of colors cannot be zero!");
                }

                this.colors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            string size = string.Format("Display: {0}", this.Size);
            string colors = string.Format("Colors: {0}", this.Colors == null ? "N/A" : this.Colors.ToString());

            info.AppendLine(size)
                .AppendLine(colors);

            return info.ToString();
        }
    }
}
