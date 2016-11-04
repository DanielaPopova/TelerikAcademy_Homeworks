using System;
using System.IO;
using System.Text;

class ExtractTextFromXML
{
    static void Main()
    {
        try
        {
            StringBuilder textOnly = new StringBuilder();
            bool isOpen = false;
            
            using (StreamReader xmlRead = new StreamReader("../../text.xml"))
            {
                string line = xmlRead.ReadLine();

                while (line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        char currSymbol = line[i];
                        if (currSymbol == '<')
                        {
                            isOpen = true;
                            continue;
                        }
                        else if (currSymbol == '>')
                        {
                            isOpen = false;
                            continue;
                        }
                        if (isOpen == false)
                        {
                            textOnly.Append(currSymbol); 
                        }                                               
                    }

                    line = xmlRead.ReadLine();
                }

                Console.WriteLine(textOnly);
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
    }
}


/*
Write a program that extracts from given XML file all the text without the tags.
Example:

<?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3"><interest>Games</interest><interest>C#</interest><interest>Java</interest></interests></student>
*/