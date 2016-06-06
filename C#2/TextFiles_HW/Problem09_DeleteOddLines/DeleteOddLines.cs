using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class DeleteOddLines
{
    static void Main()
    {
        string path = "../../alice.txt";
        Console.WriteLine("Current text:\n");
        foreach (string sentence in File.ReadLines(path, Encoding.UTF8))
        {
            Console.WriteLine(sentence);
        }
        
        List<string> evenLines =new List<string>();
        var readFile = new StreamReader(path);
        using (readFile)
        {
            int lineNum = 1;
            string line = readFile.ReadLine();

            while (line != null)
            {
                if (lineNum % 2 == 0)
                {
                    evenLines.Add(line);
                }               

                line = readFile.ReadLine();
                lineNum++;
            }
        }

        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Text with removed odd line:\n");
        using (var writeOnFile = new StreamWriter(path))
        {
            foreach (var line in evenLines)
            {
                writeOnFile.WriteLine(line);
                Console.WriteLine(line);
            }
        }

        ResetFile(path);
        Console.WriteLine("\nFile is reset!!!");
    }

    static void ResetFile(string path)
    {
        StreamReader readFile = new StreamReader("../../reset.txt");
        
        using (StreamWriter file = new StreamWriter(path))
        {
            using (readFile)
            {
                string line = readFile.ReadLine();

                while (line != null)
                {
                    file.WriteLine(line, true);
                    line = readFile.ReadLine();
                }
            }  
        }
    }
}


/*
Write a program that deletes from given text file all odd lines.
The result should be in the same file.
*/
