namespace CohesionAndCoupling.Models
{
    using System;

    using Contracts;

    public class Figure3D : IFigure3D
    {
        private const string EqualOrLessThanZeroMessage = "{0} cannot be equal to or less than zero!";

        private double width;
        private double height;
        private double depth;

        public Figure3D(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(EqualOrLessThanZeroMessage, "Width");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(EqualOrLessThanZeroMessage, "Height");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(EqualOrLessThanZeroMessage, "Depth");
                }

                this.depth = value;
            }
        }

        public double Volume
        {
            get
            {
                return this.Width * this.Height * this.Depth;
            }
        }
    }
}
