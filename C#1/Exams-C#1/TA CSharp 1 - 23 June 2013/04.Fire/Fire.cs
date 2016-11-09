using System;

class Fire
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());

        //top
        int outerDots = (width - 2) / 2;
        int innerDots = 0;
        
        //upper fire
        for (int i = 0; i < width / 2; i++)
        {
            Console.WriteLine("{0}#{1}#{0}", new string('.', outerDots), new string('.', innerDots));
            outerDots--;
            innerDots += 2;
        }

        //lower fire
        outerDots = 0;
        innerDots -= 2;

        for (int i = width / 2; i < (width / 2 + width / 4); i++)
        {
            Console.WriteLine("{0}#{1}#{0}", new string('.', outerDots), new string('.', innerDots));
            outerDots++;
            innerDots -= 2;
        }

        //middle
        Console.WriteLine(new string('-', width));

        //torch

        outerDots = 0;
        int backSlash = width / 2;
        int slash = width / 2;

        for (int i = 0; i < width / 2; i++)
        {
            Console.WriteLine("{0}{1}{2}{0}", new string('.', outerDots), new string('\\', backSlash), new string('/', slash));
            outerDots++;
            backSlash--;
            slash--;
        }        
    }
}

