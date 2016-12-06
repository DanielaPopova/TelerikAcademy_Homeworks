using System;
using System.Collections.Generic;
using System.Linq;

class CATastrophe
{
    static string[] keywords = {
                                   "sbyte",
                                   "byte",
                                   "short",
                                   "ushort",
                                   "int",
                                   "uint",
                                   "long",
                                   "ulong",
                                   "float",
                                   "double",
                                   "decimal",
                                   "bool",
                                   "char",
                                   "string",
                                   "sbyte?",
                                   "byte?",
                                   "short?",
                                   "ushort?",
                                   "int?",
                                   "uint?",
                                   "long?",
                                   "ulong?",
                                   "float?",
                                   "double?",
                                   "decimal?",
                                   "bool?",
                                   "char?"                                   
                               };   

    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        string[] code = new string[lines];

        for (int i = 0; i < lines; i++)
        {
            code[i] = Console.ReadLine();
        }

        var allVariablesInMethods = new List<string>();
        var allVariablesInLoops = new List<string>();
        var variablesInCondStatement = new List<string>();

        for (int i = 0; i < code.Length; i++)
        {
            string currLine = code[i];

            if (currLine.Contains(" static "))
            {
                var currVariablesInBracket = CheckInBrackets(currLine);

                if (currVariablesInBracket.Count > 0)
                {
                    for (int j = 0; j < currVariablesInBracket.Count; j++)
                    {
                        allVariablesInMethods.Add(currVariablesInBracket[j]);
                    }
                }

                int endIndex = EndIndex(i, code);

                for (int j = i + 1; j < endIndex; j++)
                {
                    //TODO: find variables in loops/cond statement here, cause i changes to i = endIndex;
                    //TODO: handle var?
                    //TODO: if in method and in loop/cond statement - DO NOT COUNT variables;
                    string lineInScope = code[j];

                    while (lineInScope.Contains("for") || lineInScope.Contains("while") || lineInScope.Contains("foreach"))
                    {
                        var variablesInLoopBracket = CheckInBrackets(lineInScope);

                        if (variablesInLoopBracket.Count > 0)
                        {
                            for (int k = 0; k < variablesInLoopBracket.Count; k++)
                            {
                                allVariablesInLoops.Add(variablesInLoopBracket[k]);
                            }
                        }
                    }

                    var currVariablesInMethodScope = CheckInMethodScope(lineInScope);

                    if (currVariablesInMethodScope.Count > 0)
                    {
                        for (int l = 0; l < currVariablesInMethodScope.Count; l++)
                        {
                            allVariablesInMethods.Add(currVariablesInMethodScope[l]);
                        }
                    }
                }

                i = endIndex;

                if (i >= code.Length)
                {
                    break;
                }
            }
        }

        Console.WriteLine("Methods -> {0} -> {1}", allVariablesInMethods.Count, String.Join(", ", allVariablesInMethods));
    }

    public static List<string> CheckInBrackets(string line)
    {
        var variablesInBracket = new List<string>();
   
        string[] splitedByOpenBracket = line.Split(new[] {'('}, StringSplitOptions.RemoveEmptyEntries);
        string[] wordsInBracket = splitedByOpenBracket[1].Split(new[]{' ', ',', ')'});

        for (int i = 0; i < wordsInBracket.Length - 1; i++)
        {
            string currWord = wordsInBracket[i];

            if (keywords.Contains(currWord))
            {
                variablesInBracket.Add(wordsInBracket[i + 1]);
            }
        }

        return variablesInBracket;
    }

    public static List<string> CheckInMethodScope(string line)
    {
        var variablesInMethodScope = new List<string>();

        string[] wordsInLine = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < wordsInLine.Length - 1; i++)
        {
            string currWord = wordsInLine[i];

            if (keywords.Contains(currWord))
            {
                variablesInMethodScope.Add(wordsInLine[i + 1]);
            }
        }

        return variablesInMethodScope;
    }

    public static int EndIndex(int startIndex, string[] code)
    {
        int endIndex = code.Length - 1;

        for (int i = startIndex + 1; i < code.Length; i++)
        {
            string currLine = code[i];

            if (currLine.Contains(" static "))
            {
                endIndex = i - 1;
                break;
            }
        }

        return endIndex;
    }
}

