using System;
using System.IO;
using System.Text;

class LineNumbers
{
    static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("lineNums.txt");
        StreamWriter writer = new StreamWriter("output.txt");

        using (writer)
        {
            using (reader)
            {
                string line = reader.ReadLine();
                int count = 1;
                while (line != null)
                {
                    line = String.Format("Line {0}: {1}", count, line);
                    count++;
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }
            }            
        }

        Console.WriteLine("Line numbers are added! Check file!");
    }
}

/*
Write a program that reads a text file and inserts line numbers in front of each of its lines.
The result should be written to another text file.
*/

