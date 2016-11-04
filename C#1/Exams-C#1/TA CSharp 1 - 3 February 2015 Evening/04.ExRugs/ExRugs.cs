using System;

namespace _04.ExRugs
{
    class ExRugs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());

            int fieldSize = 2 * n + 1;
            int middleField = n;
            int middlePattern = width / 2 + 1;

            char dot = '.';
            char X = 'X';
            char slash = '/';
            char backslash = '\\';
            char hashtag = '#';

            for (int row = 0; row < fieldSize; row++)
            {
                for (int col = 0; col < fieldSize; col++)
                {
                    //print X
                    if (row == middleField - middlePattern && col == middleField ||
                        row == middleField + middlePattern && col == middleField ||
                        col == middleField - middlePattern && row == middleField ||
                        col == middleField + middlePattern && row == middleField)
                    {
                        Console.Write(X);
                    }
                    //print backslash
                    else if (row - col == middlePattern && row < middleField ||
                             col - row == middlePattern && col < middleField ||
                             row - col == middlePattern && row > middleField + middlePattern ||
                             col - row == middlePattern && col > middleField + middlePattern)
                    {
                        Console.Write(backslash);
                    }
                    //print slash
                    else if (row + col == fieldSize - 1 - middlePattern && row < middleField - middlePattern ||
                             row + col == fieldSize - 1 - middlePattern && row > middleField ||
                             row + col == fieldSize - 1 + middlePattern && row < middleField ||
                             row + col == fieldSize - 1 + middlePattern && row > middleField + middlePattern )
                    {
                        Console.Write(slash);
                    }
                    else if(row < middleField - middlePattern && col - row > middlePattern && col + row < fieldSize - 1 - middlePattern ||
                            row > middleField + middlePattern && row - col > middlePattern && row + col > fieldSize - 1 + middlePattern ||
                            row + col < fieldSize - 1 - middlePattern && row - col > middlePattern ||
                            row + col > fieldSize - 1 + middlePattern && col - row > middlePattern)
                    {
                        Console.Write(dot);
                    }
                    else
                    {
                        Console.Write(hashtag);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
