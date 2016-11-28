using System;
using System.Text;

class ReplaceTags
{
    static void Main()
    {
        string text = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        
        string openTag = "<a href=";
        string endTag = "</a>";

        int startIndexOpenTag = text.IndexOf(openTag);
        int indexCloseTag = text.IndexOf(endTag);
        int indexCurrPart = 0;

        while (startIndexOpenTag != -1 || indexCloseTag != -1)
        {
            string currPart = text.Substring(indexCurrPart, startIndexOpenTag - indexCurrPart);            
            string toEdit = text.Substring(startIndexOpenTag, indexCloseTag - startIndexOpenTag + endTag.Length);            
            string url = "(" + toEdit.Substring(openTag.Length + 1, (toEdit.IndexOf(">") - openTag.Length - 1 - 1)) + ")";
            string innerText = "[" + toEdit.Substring(toEdit.IndexOf(">") + 1, toEdit.LastIndexOf("<") - toEdit.IndexOf(">") - 1) + "]";

            result.Append(currPart);   //result.Replace(toEdit, innerText + url); //timelimit for every test
            result.Append(innerText);
            result.Append(url);
            
            indexCurrPart = indexCloseTag + endTag.Length;            
            startIndexOpenTag = text.IndexOf(openTag, startIndexOpenTag + 1);
            indexCloseTag = text.IndexOf(endTag, indexCloseTag + 1);

            if (startIndexOpenTag == -1 && indexCloseTag == -1)
            {
                currPart = text.Substring(indexCurrPart);
                result.Append(currPart);
            }
        }

        Console.WriteLine(result);
    }
}

