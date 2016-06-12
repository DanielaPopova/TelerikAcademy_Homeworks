namespace Point
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        public static void SavePath(Path pointsPath)
        {
            try
            {
                using (StreamWriter writePaths = new StreamWriter("../../toSave.txt"))
                {
                    for (int i = 0; i < pointsPath.Points.Count; i++)
                    {
                        writePaths.WriteLine(pointsPath.Points[i]);
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
                string filePath = "../../toLoadFrom.txt";
                var eachPoint = new Point3D();
                using (StreamReader readFile = new StreamReader(filePath))
                {
                    string coordinates = readFile.ReadLine();
                    eachPoint = FindPointsInFile(coordinates);
                    while (coordinates != null)
                    {
                        if (!path.Points.Contains(eachPoint))
                        {
                            path.AddPoint(eachPoint);
                        }
                        else
                        {
                            Console.WriteLine("This point is already in the list!");
                            break;
                        }

                        coordinates = readFile.ReadLine();
                        if (coordinates == null)
                        {
                            break;
                        }
                        else
                        {
                            eachPoint = FindPointsInFile(coordinates);
                        }
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

        private static Point3D FindPointsInFile(string coordinates)
        {
            var eachPoint = new Point3D();
            string[] pointsInLine = coordinates.Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            eachPoint = new Point3D(double.Parse(pointsInLine[0]), double.Parse(pointsInLine[1]), double.Parse(pointsInLine[2]));

            return eachPoint;
        }
    }
}