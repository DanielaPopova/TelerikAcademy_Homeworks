namespace Point
{
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            this.Points = new List<Point3D>();
        }

        public List<Point3D> Points
        {
            get { return this.points; }
            set { this.points = value; }
        }

        public void AddPoint(Point3D somePoint)
        {
            this.points.Add(somePoint);
        }

        public void DeletePoint(Point3D somePoint)
        {
            if (this.points.Count == 0)
            {
                throw new System.ArgumentException("There are no points to be deleted");
            }

            this.points.Remove(somePoint);
        }

        public override string ToString()
        {
            return string.Join("\n", this.points);            
        }
    }
}
