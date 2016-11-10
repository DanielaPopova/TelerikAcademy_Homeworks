using System;
using System.Text;

class HiddenMessage
{
    static void Main()
    {
       
        string firstLine = string.Empty;
        StringBuilder result = new StringBuilder();

        while (firstLine != "end")
        {
            firstLine = Console.ReadLine();

            if (firstLine == "end")
            {
                break;
            }
            else
            {
                int startIndex = int.Parse(firstLine);                
                int skip = int.Parse(Console.ReadLine());
                string text = Console.ReadLine();

                if (startIndex >= text.Length)
                {
                    continue;
                }

                if (startIndex < 0)
                {
                    startIndex = text.Length - Math.Abs(startIndex);
                }

                if (skip < 0)
                {                    
                    for (int j = startIndex; j >= 0; j -= Math.Abs(skip))
                    {
                        char currSymbol = text[j];
                        result.Append(currSymbol);
                    }                    
                }
                else
                {
                    for (int i = startIndex; i < text.Length; i += skip)
                    {
                        char currSymbol = text[i];
                        result.Append(currSymbol);
                    }   
                }                                                     
            }
        }

        Console.WriteLine(result);
    }
}

