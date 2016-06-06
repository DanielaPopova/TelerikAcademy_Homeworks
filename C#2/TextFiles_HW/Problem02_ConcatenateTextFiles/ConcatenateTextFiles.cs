using System;
using System.IO;
using System.Text;

class ConcatenateTextFiles
{
    static void Main()
    {
        string firstFile = File.ReadAllText("../../firstFile.txt", Encoding.GetEncoding("Windows-1251"));  //file already created, content filled, direct usage
        Console.WriteLine(firstFile);

        string secondFilePath = @"../../secondFile.txt";        //create path to non-existend file       
        if (!File.Exists(secondFilePath))                   // create file and write content
        {
            File.Create(secondFilePath);
            using (TextWriter tw = new StreamWriter(secondFilePath))
            {
                tw.WriteLine("The very first line!");     //is already created after starting the programm the first time, so that sentence won't be seen again     
            }
            
        }
        else if (File.Exists(secondFilePath))           //if file is already created - rewrite content (true)
        {
            using (TextWriter tw = new StreamWriter(secondFilePath, false))    //false = rewrite text, do not concatenate
            {
                tw.WriteLine(@"""How do you know I’m mad?"" said Alice.");     //when using @ quotations are escaped with "
                tw.WriteLine("\"You must be,\" said the Cat, \"or you wouldn’t have come here.\"");      //by direct text quotation are escaped with the escape symbol 
                
            }            
        }

        //using (StreamReader sr = new StreamReader(secondFilePath))
        //{
        //    Console.WriteLine(sr.ReadToEnd());
        //}

        //line by line
        StringBuilder secondFile = new StringBuilder();   //put all line in a string format -> later the result can be concatenated

        using (StreamReader sr = new StreamReader(secondFilePath))
        {
            string line = sr.ReadLine();

            while (line != null)
            {
                Console.WriteLine(line);        //first type console.writeline() to start from the first line
                secondFile.Append(line).Append("\n");
                line = sr.ReadLine();
            }
        }

        Console.WriteLine(new string('-', 50));

        //using strings - read both files and concatenate into third file

        string outputFile = "../../thirdFile.txt";
        File.Create(outputFile);

        outputFile = firstFile + "\n" + secondFile.ToString();
        Console.WriteLine(outputFile);

        //using streams
        string otherOutPutFile = "../../forthFile.txt";  

        using (StreamWriter destination = new StreamWriter(otherOutPutFile))
        {
            using (StreamReader firstPath = new StreamReader("../../firstFile.txt"))
            {
                string line = firstPath.ReadLine();
                while (line != null)
                {
                    destination.WriteLine(line, false, Encoding.GetEncoding("Windows-1251"));
                    line = firstPath.ReadLine();
                }
                
            }

            Console.WriteLine(new string('-', 50));

            using (StreamReader secondPath = new StreamReader("../../secondFile.txt"))
            {
                string line = secondPath.ReadLine();
                while (line != null)
                {
                    destination.WriteLine(line, true, Encoding.GetEncoding("Windows-1251"));
                    line = secondPath.ReadLine();
                }
            }
        }

        //read forth file and display to console

        using (StreamReader sr = new StreamReader("../../forthFile.txt"))
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
        }

    }
}

/*
Write a program that concatenates two text files into another text file.
*/