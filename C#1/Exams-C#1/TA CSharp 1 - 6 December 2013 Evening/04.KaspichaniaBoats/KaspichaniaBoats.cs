using System;

class KaspichaniaBoats
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());

        int width = n * 2 + 1;
        int height = 6 + ((n - 3) / 2) * 3;

        //top
        int outerDots = width / 2;
        int star = 1;

        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('*', star));
            star += 2;
            outerDots--;
        }

        //upper part
        int innerDots = 1;

        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            outerDots--;
            innerDots++;
        }

        //middle
        Console.WriteLine(new string('*', width));

        //lower part
        outerDots = 1;
        --innerDots;

        for (int i = (n - 2) + 2 + 1; i < height - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            outerDots++;
            innerDots--;
        }

        //bottom
        Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('*', n));
    }
}

