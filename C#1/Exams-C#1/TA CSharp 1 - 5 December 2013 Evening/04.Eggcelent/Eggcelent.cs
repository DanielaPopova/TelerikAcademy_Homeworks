using System;

class Eggcelent
{
    static void Main()
    {
        int middle = int.Parse(Console.ReadLine());

        int height = 2 * middle;
        int width = 3 * middle - 1;
        int topAndBottom = middle - 1;

        int fieldWidth = 3 * middle + 1;

        //top
        int outerDots = middle + 1;

        Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('*', topAndBottom));

        //upper part
        outerDots -= 2;
        int innerDots = middle + 1;

        for (int i = 1; i < (height - middle) / 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            outerDots -= 2;
            innerDots += 4;
        }

        //middle
        for (int i = 0; i < middle; i++)
        {
            if (i == middle / 2 - 1)
            {
                Console.Write(".*");
                for (int row = 0; row < 1; row++)
                {
                    for (int col = 2; col < width; col++)
                    {
                        if (col % 2 == 0)
                        {
                            Console.Write('@');
                        }
                        else
                        {
                            Console.Write('.');
                        }
                    }
                }
                Console.Write("*.");
                Console.WriteLine();
            }
            else if (i == middle / 2)
            {
                Console.Write(".*");
                for (int row = 0; row < 1; row++)
                {
                    for (int col = 2; col < width; col++)
                    {
                        if (col % 2 == 0)
                        {
                            Console.Write('.');
                        }
                        else
                        {
                            Console.Write('@');
                        }
                    }
                }
                Console.Write("*.");
                Console.WriteLine();                
            }
            else
            {
                Console.WriteLine(".*{0}*.", new string('.', width - 2));
            }
        }

        //lower part
        outerDots += 2;
        innerDots -= 4; 
        for (int i = (height + middle) / 2; i < height - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            outerDots += 2;
            innerDots -= 4;
        }

        //bottom
        Console.WriteLine("{0}{1}{0}", new string('.', middle + 1), new string('*', topAndBottom));
    }
}

