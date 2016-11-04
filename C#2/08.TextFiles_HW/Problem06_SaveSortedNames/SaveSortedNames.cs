using System;
using System.Collections.Generic;
using System.IO;

class SaveSortedNames
{
    static void Main()
    {
        try
        {
            List<string> names = new List<string>();
            using (StreamReader readNames = new StreamReader("../../input.txt"))
            {
                string name = readNames.ReadLine();                
                while (name != null)
                {
                    names.Add(name);
                    name = readNames.ReadLine();
                }
            }

            //NICE

            //for (string currName = unsorted.ReadLine(); currName != null; currName = unsorted.ReadLine())
            //{
            //    names.Add(currName);
            //}

            names.Sort();
            
            using (StreamWriter writeNames = new StreamWriter("../../output.txt"))
            {
                foreach (var name in names)
                {
                    writeNames.WriteLine(name);
                }
            }

            Console.WriteLine("Done! Check output.txt");
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
}

/*
Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
Example:

input.txt	output.txt
Ivan        Ivan
Peter       George
Maria       Maria 
George      Peter
*/

