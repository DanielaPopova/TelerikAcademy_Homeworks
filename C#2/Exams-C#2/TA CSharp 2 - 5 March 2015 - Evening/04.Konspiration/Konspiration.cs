//50/100 bgcoder - couldn't handle lines like "int    numberOfLines   =   int.   Parse   (   Console   .   ReadLine  ()   );"
using System;
using System.Collections.Generic;

class Konspiration
{
    static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());

        var codeLines = new List<string>();

        for (int i = 0; i < numberOfLines; i++)
        {
            string line = Console.ReadLine();
            if (line != "")
            {
                codeLines.Add(line);
            }
        }

        for (int i = 0; i < codeLines.Count; i++)
        {
            string currLine = codeLines[i];
            int endIndex = 0;

            if (currLine.Contains(" static "))
            {
                string methodName = FindMethodName(currLine);

                if (codeLines[i + 1].Trim() == "{")
                {
                    int startIndex = i + 1;
                    endIndex = EndOfMethodDeclaration((i + 1), codeLines);
                    var methodsInDeclaration = new List<string>();

                    for (int j = startIndex + 1; j < endIndex; j++)
                    {
                        string currDeclarationLine = codeLines[j];

                        var callMethodNames = CallMethodNames(currDeclarationLine);

                        if (callMethodNames.Count > 0)
                        {
                            foreach (var method in callMethodNames)
                            {
                                methodsInDeclaration.Add(method);
                            }
                        }
                    }

                    if (methodsInDeclaration.Count == 0)
                    {
                        Console.WriteLine("{0} -> None", methodName);
                    }
                    else
                    {
                        Console.WriteLine("{0} -> {1} -> {2}", methodName, methodsInDeclaration.Count, String.Join(", ", methodsInDeclaration));
                    }
                }
            }

            if (endIndex != 0)
            {
                i = endIndex;

                if (i >= codeLines.Count)
                {
                    break;
                }
            }
        }
    }

    public static string FindMethodName(string line)
    {
        string[] allwords = line.Split(new char[] { ' ', '(' }, StringSplitOptions.RemoveEmptyEntries);
        string methodName = allwords[2];

        return methodName;
    }

    public static int EndOfMethodDeclaration(int startIndex, List<string> code)
    {
        int indexOfLastCloseBracket = code.Count - 1;

        for (int i = startIndex; i < code.Count; i++)
        {
            string currLine = code[i];

            if (currLine.Contains(" static "))
            {
                indexOfLastCloseBracket = i - 1;
                break;
            }
        }

        return indexOfLastCloseBracket;
    }

    public static List<string> CallMethodNames(string line)
    {
        line = line.Trim();

        var callMethodNames = new List<string>();
        int indexOpenBracket = line.IndexOf('(');

        while (indexOpenBracket != -1)
        {
            string methodName = string.Empty;

            for (int i = indexOpenBracket - 1; i >= 0; i--)
            {
                char currSymbol = line[i];

                if (Char.IsLetter(currSymbol))
                {
                    methodName = currSymbol + methodName;
                }
                else
                {
                    break;
                }
            }

            if (methodName != string.Empty && methodName != "StringBuilder")
            {
                callMethodNames.Add(methodName);
            }

            indexOpenBracket = line.IndexOf("(", indexOpenBracket + 1);
        }

        return callMethodNames;
    }
}