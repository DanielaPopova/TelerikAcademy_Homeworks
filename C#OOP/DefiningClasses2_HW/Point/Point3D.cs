namespace Point
{
    public struct Point3D
    {
        private static readonly Point3D start = new Point3D(0, 0, 0);

        public Point3D(double x, double y, double z) : this()       // automatically implemented properties -> the calling of default constructor of struct with this() is required, otherwise  -> errors!
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D Start
        {
            get
            {
                return start;
            }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0}, {1}, {2}}}", this.X, this.Y, this.Z);
        }
    }
}

/*
Automatically implemented properties

When a property is specified as an automatically implemented property, a hidden backing field is automatically available for the property,
and the accessors are implemented to read from and write to that backing field.

Because the backing field is inaccessible, it can be read and written only through the property accessors, even within the containing type.

This restriction also means that definite assignment of struct types with auto-implemented properties can only be achieved using
the standard constructor of the struct, since assigning to the property itself requires the struct to be definitely assigned.
This means that user-defined constructors must call the default constructor.
*/