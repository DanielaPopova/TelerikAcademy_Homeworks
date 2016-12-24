namespace PointTask.Models
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        public static void SavePath(Path pointsPath)
        {
            try
            {
                using (StreamWriter writePaths = new StreamWriter("../../Models/Files/SaveTo.txt"))
                {
                    for (int i = 0; i < pointsPath.Count; i++)
                    {
                        writePaths.WriteLine(pointsPath[i]);
                    }
                }

                Console.WriteLine("Data is saved!");
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine(dnfe.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        public static Path LoadPath()
        {
            Path path = new Path();

            try
            {
                string filePath = "../../Models/Files/LoadFrom.txt";
                var eachPoint = new Point3D();

                using (StreamReader readFile = new StreamReader(filePath))
                {
                    string line = readFile.ReadLine();
                    
                    while (line != null)
                    {
                        eachPoint = ParsePoint(line);
                        path.AddPoint(eachPoint);

                        line = readFile.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine(dnfe.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }

            return path;
        }

        private static Point3D ParsePoint(string line)
        {
            string[] coordinates = line.Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            var eachPoint = new Point3D(double.Parse(coordinates[0]), double.Parse(coordinates[1]), double.Parse(coordinates[2]));

            return eachPoint;
        }
    }
}
