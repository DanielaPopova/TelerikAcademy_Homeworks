using System;

class BatGoikoTower
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        int width = height * 2;

        int outerDots = height - 1;
        int innerDots = 0;
        int dashes = 0;

        int update = 1;
        int dashesRow = 1;

        for (int i = 0; i < height; i++)
        {
            if (i == dashesRow)          //(i == 1 || i == 3 || i == 6 || i == 10 || i == 15 || i == 21 || i == 28 || i == 36)
            {
                Console.WriteLine("{0}/{1}\\{0}", new string('.', outerDots), new string('-', dashes));
                update++;
                dashesRow += update;
            }
            else
	        {
                Console.WriteLine("{0}/{1}\\{0}", new string('.', outerDots), new string('.', innerDots));
	        }

            outerDots--;
            innerDots += 2;
            dashes += 2;
        }
    }
}

