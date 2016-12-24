namespace PointTask.Models
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            this.points = new List<Point3D>();
        }      

        public int Count
        {
            get
            {
                return this.points.Count;
            }
        }

        public Point3D this[int index]
        {
            get
            {
                return this.points[index];
            }

            set
            {
                this.points[index] = value;
            }
        }

        public void AddPoint(Point3D pointToAdd)
        {
            this.points.Add(pointToAdd);
        }

        public void DeletePoint(Point3D pointToDelete)
        {
            if (this.points.Contains(pointToDelete))
            {
                this.points.Remove(pointToDelete);
            }
            else
            {
                throw new ArgumentException("There is no such point in path!");
            }

            //for (int i = 0; i < this.points.Count; i++ )  // using foreach results in "Collection was modified; enumeration operation may not execute" exception
            //{
            //    var point = this.points[i];

            //    if (point.X == pointToDelete.X && point.Y == pointToDelete.Y && point.Z == pointToDelete.Z)
            //    {
            //        this.points.Remove(pointToDelete);
            //    }
            //    else
            //    {
            //        throw new ArgumentException("There is no such point in path!");
            //    }
            //}
        }

        public string DisplayPath()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return String.Join("\n", this.points);
        }       
    }
}
