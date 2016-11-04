using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class PrefixTest
{
    static void Main()
    {
        try
        {
            string pattern = "test[a-zA-Z0-9_]+";
            string result = string.Empty;
            Regex reg = new Regex(pattern);

            string currText = File.ReadAllText("../../text.txt");
            Console.WriteLine("Current text\n{0}", currText);
            Console.WriteLine(new string('-', 40));

            using (StreamReader fileRead = new StreamReader("../../text.txt"))
            {
                string text = fileRead.ReadToEnd();
                result = reg.Replace(text, "");
            }

            Console.WriteLine("Result:\n{0}", result);
        }
        catch (DirectoryNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (FileLoadException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (EndOfStreamException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}

/*
Write a program that deletes from a text file all words that start with the prefix test.
Words contain only the symbols 0…9, a…z, A…Z, _.
*/

