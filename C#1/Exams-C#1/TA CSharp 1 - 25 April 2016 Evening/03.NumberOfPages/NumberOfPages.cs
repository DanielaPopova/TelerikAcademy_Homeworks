using System;

class NumberOfPages
{
    static void Main()
    {
        int digits = int.Parse(Console.ReadLine());
        int pages = 0;

        for (int i = 1; digits != 0; i++)
        {
            pages++;
            digits -= i.ToString().Length;

            //if (i < 10)
            //{
            //    digits -= 1;
            //}
            //else if (i < 100)
            //{
            //    digits -= 2;
            //}
            //else if (i < 1000)
            //{
            //    digits -= 3;
            //}
            //else if (i < 10000)
            //{
            //    digits -= 4;
            //}
            //else if (i < 100000)
            //{
            //    digits -= 5;
            //}
            //else if (i < 1000000)
            //{
            //    digits -= 6;
            //}
        }

        Console.WriteLine(pages);
    }
}

