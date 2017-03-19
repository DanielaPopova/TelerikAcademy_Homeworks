namespace CohesionAndCoupling.Utilities
{
    using System;

    public static class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("Input file does not have file extension!");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("Input file does not have file extension!");
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
