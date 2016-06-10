namespace MobilePhone
{
    using System;

    public class Display
    {
        private double? displaySize; 
        private int? numberOfColors;

        public Display()
            : this(null, null)
        {

        }

        public Display(double? display, int? colors)
        {
            this.DisplaySize = display;
            this.NumberOfColors = colors;
        }

        public double? DisplaySize
        {
            get
            {
                return this.displaySize;
            }

            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Display size can't be 0 or negative!");
                }

                this.displaySize = value;
            }
        }

        public int? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of colors is a positive number!");
                }

                this.numberOfColors = value;
            }
        }

        public override string ToString()
        {
            string display = string.Empty;
            if (this.DisplaySize == null)
            {
                display = "No info";
            }
            else
            {
                display = this.DisplaySize.ToString();
            }

            string colors = string.Empty;
            if (this.NumberOfColors == null)
            {
                colors = "No info";
            }
            else
            {
                colors = this.NumberOfColors.ToString();
            }

            return string.Format("Size: {0}\"\nColors: {1}", display, colors);
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