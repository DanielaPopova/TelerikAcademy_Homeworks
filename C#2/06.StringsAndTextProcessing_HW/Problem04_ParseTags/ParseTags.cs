using System;
using System.Text;

class ParseTags
{
    static void Main()
    {
        string text = Console.ReadLine();   // "how are yu</upcase>there there <upcase>mama</upcase>"; //Console.ReadLine(); //"hi<upcase></upcase>there";
                                            //"how are yu</upcase>there there <upcase>";
        string startTag = "upcase";       //"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string endTag = "/upcase";

        StringBuilder result = new StringBuilder();
        bool toUpper = false;

        string[] sentences = text.Split(new[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var part in sentences)
        {
            if (part == startTag)
            {
                toUpper = true;
                continue;
            }
            else if (part == endTag)
            {
                toUpper = false;
                continue;
            }

            if (toUpper)
            {
                result.Append(part.ToUpper());
            }
            else
            {
                result.Append(part);
            }
        }

        Console.WriteLine(result);
    }
}

/*
Description

You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to upper-case.

Input

On the only line you will receive a string - the text
Output

Print the changed string on one line
Constraints

The tags will not be nested.
String length will be <= 10000
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                                                                                                Output
We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.	    We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
*/

/*Regex  runtime error/bgcoder
string regex = "<upcase>(.*?)<\\/upcase>";
        string textBetween = String.Empty;

        MatchCollection matches = Regex.Matches(text, regex);   //finds all matches

        for (int i = 0; i < matches.Count; i++)
        {
            string match = matches[i].ToString();      

            int startIndex = match.IndexOf('>');
            int endIndex = match.LastIndexOf('<') + 1;
            
            textBetween = match.Substring(startIndex, endIndex - startIndex);   //extract text between <upcase> and </upcase>

            text = text.Replace(textBetween, textBetween.ToUpper());
        }        
        text = text.Replace("<upcase>", "");
        text = text.Replace("</upcase>", "");

        Console.WriteLine(text);
*/

/*IndexOf 35/100/bgcoder
int startIndex = text.IndexOf(startTag) + startTag.Length;
        int endIndex = text.IndexOf(endTag);
       
        while (startIndex != -1 && endIndex != -1)
        {
            if (endIndex < startIndex)
            {
                break;
            }
            else
            {
                string textBetween = text.Substring(startIndex, endIndex - startIndex);

                if (textBetween == "")
                {
                    textBetween = " ";
                }

                text = text.Replace(textBetween, textBetween.ToUpper());

                startIndex = text.IndexOf(startTag, startIndex + 1) + startTag.Length;
                endIndex = text.IndexOf(endTag, endIndex + 1);
            }
        }
        
        text = text.Replace(startTag, "");
        text = text.Replace(endTag, "");

        Console.WriteLine(text);
*/

/*Split by <upcase> </upcase>
using System;

class ParseTags
{
    static void Main()
    {
        string text = Console.ReadLine();// "how are yu</upcase>there there <upcase>mama</upcase>";//"how are yu</upcase>there there <upcase>"; //Console.ReadLine(); //"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else."; //"hi<upcase></upcase>there";

        string startTag = "<upcase>";
        string endTag = "</upcase>";

        string[] sentences = text.Split(new[] { startTag, endTag }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 1; i < sentences.Length; i+=2)
        {
            string toUpper = sentences[i].ToUpper();
            //Console.WriteLine(toUpper);
            text = text.Replace(sentences[i], toUpper);
        }
        text = text.Replace(startTag, "");
        text = text.Replace(endTag, "");
        Console.WriteLine(text);
    }
}
*/