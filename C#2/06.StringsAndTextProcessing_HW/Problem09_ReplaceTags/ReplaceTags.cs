using System;
using System.Text;

class ReplaceTags
{
    static void Main()                 //time limit/bgcoder
    {
        string input = Console.ReadLine(); //"<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        int startIndex = input.IndexOf("<a");
        int endIndex = input.IndexOf("</a>") + 4;
        string toEdit = String.Empty;

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            while (startIndex > 0)
            {
                toEdit = input.Substring(startIndex, endIndex - startIndex);    //<a href=\"http://academy.telerik.com\">our site</a>

                int startURL = toEdit.IndexOf("\"") + 1;
                int endURL = toEdit.LastIndexOf("\"");
                string url = toEdit.Substring(startURL, endURL - startURL);    //http://academy.telerik.com
                //Console.WriteLine(url);

                int startText = toEdit.IndexOf(">") + 1;
                int endText = toEdit.IndexOf("</a>");
                string text = toEdit.Substring(startText, endText - startText);    //our site
                //Console.WriteLine(text);

                string edited = String.Format("[{0}]({1})", text, url);

                input = input.Replace(toEdit, edited);
                //Console.WriteLine(result);

                startIndex = input.IndexOf("<a", startIndex + 1);
                endIndex = input.IndexOf("</a>", endIndex) + 4;

                //Console.WriteLine(toEdit);
            }
        }

        Console.WriteLine(input);
    }
}

/*
Write a program that replaces in a HTML document given as string all the tags <a href="URL">TEXT</a> with corresponding markdown notation [TEXT](URL).

Input

On the only input line you will receive a string
Output

Print the string with replaced tags
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                                                                                        Output
<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course.  <p>Please visit [our site](http://academy.telerik.com) to choose a training course. 
Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>	                Also visit [our forum](www.devbg.org) to discuss the courses.</p>
*/

