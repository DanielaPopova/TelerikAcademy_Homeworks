using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class VariableLengthCoding
{
    static void Main()
    {        
        int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int lines = int.Parse(Console.ReadLine());

        var codeTable = new List<string>();

        for (int i = 0; i < lines; i++)
        {
            string codeTableString = Console.ReadLine();
            codeTable.Add(codeTableString);
        }

        var encodedText = new StringBuilder();

        for (int i = 0; i < integers.Length; i++)
        {
            int currNumber = integers[i];
            string bits8 = ConvertToBits(currNumber);
            encodedText.Append(bits8);
        }

        string[] encodedTextCodeOnly = encodedText.ToString().Split(new char[] {'0'}, StringSplitOptions.RemoveEmptyEntries);
        var decodedText = new StringBuilder();

        foreach (var code in encodedTextCodeOnly)
        {
            char letter = FindCorrespondingLetter(code.Length, codeTable);
            decodedText.Append(letter);
        }

        Console.WriteLine(decodedText);
    }

    public static string ConvertToBits(int number)
    {
        string bitRep = Convert.ToString(number, 2).PadLeft(8, '0');

        return bitRep;
    }

    public static char FindCorrespondingLetter(int length, List<string> codeTable)
    {
        char searchedLetter = '\0';

        for (int i = 0; i < codeTable.Count; i++)
        {
            string currString = codeTable[i];
            char letter = currString[0];
            int currLength = int.Parse(currString.Substring(1));

            if (length == currLength)
            {
                searchedLetter = letter;
                break;
            }
        }

        return searchedLetter;
    }
}

