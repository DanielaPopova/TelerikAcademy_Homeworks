namespace GeometricFigures
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
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
                    throw new ArgumentException("Width cannot be less than or equal to zero!");
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
                    throw new ArgumentException("Height cannot be less than or equal to zero!");
                }

                this.height = value;
            }
        }

        public static Size GetRotatedSize(Size size, double angleOfRotation)
        {
            double newWidth = Math.Abs(Math.Cos(angleOfRotation)) * size.Width +
                              Math.Abs(Math.Sin(angleOfRotation)) * size.Height;
            double newHeight = Math.Abs(Math.Sin(angleOfRotation)) * size.Width +
                               Math.Abs(Math.Cos(angleOfRotation)) * size.Height;

            var newSize = new Size(newWidth, newHeight);

            return newSize;
        }

        public override string ToString()
        {
            string result = string.Format("Width: {0:F2}\nHeight: {1:F2}", this.Width, this.Height);

            return result;
        }
    }
}
