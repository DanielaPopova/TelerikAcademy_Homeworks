using System;
using System.IO;


class Program
{
    static void Main()
    {

        StreamReader readFirstFile = new StreamReader("../../text1.txt");
        StreamReader readSecondFile = new StreamReader("../../text2.txt");

        //show which lines

        int lineNum = 1;
        
        using (readFirstFile)
        {
            string lineTxt1 = readFirstFile.ReadLine();

            using (readSecondFile)
            {
                string lineTxt2 = readSecondFile.ReadLine();                

                while (lineTxt1 != null && lineTxt2 != null)
                {
                    if (lineTxt1.Equals(lineTxt2))
                    {
                        Console.WriteLine("Lines {0} are equal", lineNum);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(lineTxt1);
                        Console.ResetColor();
                        Console.WriteLine("is equal to");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(lineTxt2);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Lines {0} are not equal", lineNum);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(lineTxt1);
                        Console.ResetColor();
                        Console.WriteLine("are not equal to");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(lineTxt2);
                        Console.ResetColor();
                    }
                    lineTxt1 = readFirstFile.ReadLine();
                    lineTxt2 = readSecondFile.ReadLine();
                    lineNum++;
                }
            }
        }

        //Count how many lines are equal/not eqaul

        //int countLine = 0;

        //using (readFirstFile)
        //{
        //    string lineTxt1 = readFirstFile.ReadLine();

        //    using (readSecondFile)
        //    {
        //        string lineTxt2 = readSecondFile.ReadLine();

        //        while (lineTxt1 != null && lineTxt2 != null)
        //        {
        //            if (lineTxt1.Equals(lineTxt2))
        //            {
        //                countLine++;
        //            }

        //            lineTxt1 = readFirstFile.ReadLine();
        //            lineTxt2 = readSecondFile.ReadLine();
        //        }
        //        Console.WriteLine("{0} line(s) is(are) equal", countLine);                
        //    }
        //}
    }
}

/*
Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different.
Assume the files have equal number of lines.
*/