namespace Abstraction
{
    using System;

    using Abstraction.Contracts;

    public class Circle : Figure, ICircle
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius cannot be equal to or less than zero!");
                }

                this.radius = value;
            }
        }
      
        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }

        public override string ToString()
        {
            return string.Format("I am a circle. " +
                "My perimeter is {0:f2}. My surface is {1:f2}.",
                this.CalculatePerimeter(), this.CalculateSurface());
        }
    }
}
