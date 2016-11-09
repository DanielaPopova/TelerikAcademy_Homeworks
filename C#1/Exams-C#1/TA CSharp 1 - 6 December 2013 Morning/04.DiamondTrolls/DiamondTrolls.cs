using System;

class DiamondTrolls
{
    static void Main()
    {
        int top = int.Parse(Console.ReadLine());

        int width = top * 2 + 1;
        int height = 6 + ((top - 3) / 2) * 3;

        //top
        int outerDots = (width - top) / 2;
        Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('*', top));

        //upper part
        --outerDots;
        int innerDots = (width - 3 - 2 * outerDots) / 2;

        for (int i = 1; i < height / 3; i++)
        {
            Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            outerDots--;
            innerDots++;
        }

        //middle
        Console.WriteLine(new string('*', width));

        //lower part
        ++outerDots;
        --innerDots;

        for (int i = height / 3 + 1; i < height - 2; i++)
        {
            Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            outerDots++;
            innerDots--;
        }

        //bottom
        int star = 3;
        outerDots = (width - 3) / 2;

        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('*', star));
            star -= 2;
            outerDots++;
        }       
    }
}

