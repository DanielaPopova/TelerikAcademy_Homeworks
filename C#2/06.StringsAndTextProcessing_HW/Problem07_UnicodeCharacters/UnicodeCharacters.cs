using System;
using System.Globalization;
using System.Text;
using System.Threading;

class UnicodeCharacters
{
    static void Main()
    {
        //Console.OutputEncoding = Encoding.Unicode;
       Console.InputEncoding = Encoding.Unicode;   //to read cyrillic, but bgcoder doesn't like it
      
        string input = Console.ReadLine();
        //input = input.Replace(@"\", String.Empty);     //doesn't make difference
        //byte[] bytes = Encoding.Unicode.GetBytes(input);
        //input = Encoding.Unicode.GetString(Encoding.Convert(Encoding.UTF8, Encoding.Unicode, bytes));
        //Console.WriteLine(input);

        for (int i = 0; i < input.Length; i++)
        {
            char symbol = input[i];
            Console.Write("\\u{0:X4}", (ushort)symbol);
        }
    }
}

/*

//a little faster solution

using System;
using System.Text;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            string unicode = "\\u" + ((int)text[i]).ToString("X4");
            result.Append(unicode);
        }

        Console.WriteLine(result);
    }
}
*/

