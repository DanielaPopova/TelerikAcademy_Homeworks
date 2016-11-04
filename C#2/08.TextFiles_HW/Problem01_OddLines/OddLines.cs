using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("../../OddLines.cs"))
        {
            int countLines = 1;
            string line = reader.ReadLine();

            while (line != null)
            {
                if (countLines % 2 == 1)
                {
                    Console.WriteLine("Line {0}: {1}", countLines, line);
                }
                countLines++;
                line = reader.ReadLine();
            }
        }
    }
}