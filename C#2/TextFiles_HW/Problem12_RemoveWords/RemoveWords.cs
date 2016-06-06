using System;
using System.IO;
using System.Text;

class RemoveWords
{
    static void Main()
    {
        try
        {
            StreamReader readWord = new StreamReader("../../words.txt");
            StreamReader readText = new StreamReader("../../text.txt");

            string wholeText = File.ReadAllText("../../text.txt", Encoding.UTF8);
            Console.WriteLine("Current text:\n{0}", wholeText);
            Console.WriteLine(new string('-', 60));

            string words = File.ReadAllText("../../words.txt", Encoding.UTF8);
            Console.WriteLine("Words to be removed:\n{0}", words);
            Console.WriteLine(new string('-', 60));

            using (readText)
            {
                string text = readText.ReadToEnd();

                using (readWord)
                {
                    string word = readWord.ReadLine();
                    while (word != null)
                    {
                        if (text.Contains(word))
                        {
                            text = text.Replace(word, "");
                        }
                        word = readWord.ReadLine();
                    }
                }

                Console.WriteLine("Text with remowed words:\n{0}", text);
            }
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
Write a program that removes from a text file all words listed in given another text file.
Handle all possible exceptions in your methods.
*/

