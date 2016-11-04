using System;
using System.IO;
using System.Text;

class ReplaceSubString
{
    static void Main()
    {
        try
        {
            StreamReader readFile = new StreamReader("../../ssubString.txt");
            string start = "start";
            string finish = "finish";

            Console.WriteLine("Current text:\n");
            foreach (string line in File.ReadLines("../../subString.txt", Encoding.UTF8))
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(new string('*', 40));

            using (readFile)
            {
                //string text = readFile.ReadToEnd();
                //Console.WriteLine("Current text:\n{0}", text);
                
                string line = readFile.ReadLine();
                while (line != null)
                {

                    for (int i = 0; i < line.Length; i++)
                    {
                        int startIndex = line.IndexOf(start, StringComparison.CurrentCultureIgnoreCase);
                        if (startIndex < 0)
                        {
                            break;
                        }
                        else
                        {
                            string subStr = line.Substring(startIndex, start.Length);
                            line = line.Replace(subStr, finish);
                            Console.WriteLine(line);
                            line = readFile.ReadLine();
                        }                      
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
    }

    static void IgnoreCase(string sentence)
    {
        for (int i = 0; i < sentence.Length; i++)
        {
            char letter = sentence[i];

            if (char.IsUpper(letter) || char.IsLower(letter))
            {
                letter = char.ToLower(letter);
            }
        }
    }
}

/*
Write a program that replaces all occurrences of the sub-string "start" with the sub-string "finish" in a text file.
Ensure it will work with large files (e.g. 100 MB).
*/

/*for (int i = 0; i < line.Length; i++)
                    {
                        int currIndex = line.IndexOf(start);
                        int indexAfterStart = currIndex + start.Length;
                        string currSub = line.Substring(currIndex, start.Length);

                        while (currIndex != -1)
                        {
                            if (char.IsLetter(line[indexAfterStart]))
                            {
                                result = line.Replace(currSub, finish);
                                //Console.WriteLine(line);
                            }
                            currIndex = line.IndexOf(start, currIndex + 1);
                            currSub = line.Substring(currIndex, start.Length);
                            indexAfterStart = currIndex + start.Length;
                        }
                    }
*/