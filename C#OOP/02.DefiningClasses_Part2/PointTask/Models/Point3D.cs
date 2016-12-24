namespace PointTask.Models
{
    public struct Point3D
    {
        private static readonly Point3D startPoint = new Point3D(0, 0, 0);      

        public Point3D(double x, double y, double z)
           : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        // using static ctor
        // private static readonly Point3D StartPoint;      
        //public static Point3D()
        //{
        //    StartPoint = new Point3D(0, 0, 0);
        //}

        public static Point3D StartPoint
        {
            get
            {
                return startPoint;
            }
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public double Z { get; private set; }

        public override string ToString()
        {
            return string.Format("{{{0}, {1}, {2}}}", this.X, this.Y, this.Z);
        }
    }
}
