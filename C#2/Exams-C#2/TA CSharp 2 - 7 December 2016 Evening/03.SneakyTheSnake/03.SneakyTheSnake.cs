// 70/100
using System;

class SneakyTheSnake
{
    static string[] directions;
   
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split('x');
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);
        char[,] den = new char[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            string line = Console.ReadLine();

            for (int col = 0; col < cols; col++)
            {
                den[row, col] = line[col];
            }
        }

        directions = Console.ReadLine().Split(',');

        int sneakyLength = 3;
        int sneakyMoves = 1;

        bool lostIntoDepths = false;
        bool hitARock = false;
        bool starveInDen = false;

        char rock = '%';
        char egg = '@';
        char freeSpace = '-';
        char entrance = 'e';

        int startRow = 0;
        int startCol = 0;        
        for (int i = 0; i < cols; i++)
        {
            if (den[startRow, i] == entrance)
            {
                startCol = i;
            }
        }

        int currRow = startRow;
        int currCol = startCol;

        for (int i = 0; i < directions.Length; i++)
        {
            string currDirection = directions[i];

            if (sneakyMoves % 5 == 0)
            {
                sneakyLength--;
                if (sneakyLength <= 0)
                {
                    starveInDen = true;
                    Console.WriteLine("Sneaky is going to starve at [{0},{1}]", currRow, currCol);
                    break;
                }
            }
           
            switch (currDirection)
            {
                case "s":
                    currRow++;
                    if (currRow >= rows)
                    {
                        lostIntoDepths = true;
                    }
                    break;
                case "w": currRow--; break;
                case "a":
                    currCol--;
                    if (currCol < 0)
                    {
                        currCol = cols - 1;
                    }
                    break;
                case "d":
                    currCol++;
                    if (currCol >= cols)
                    {
                        currCol = 0;
                    }
                    break;
            }

            if (lostIntoDepths == true)
            {
                Console.WriteLine("Sneaky is going to be lost into the depths with length {0}", sneakyLength);
                break;
            }
            else if (den[currRow, currCol] == rock)
            {
                hitARock = true;
                Console.WriteLine("Sneaky is going to hit a rock at [{0},{1}]", currRow, currCol);
                break;
            }
            else if (den[currRow, currCol] == egg)
            {
                sneakyLength++;
                den[currRow, currCol] = freeSpace;
            }

            sneakyMoves++;
        }

        if (!hitARock && !lostIntoDepths && !starveInDen)
        {
            if (den[currRow, currCol] == den[startRow, startCol])
            {
                Console.WriteLine("Sneaky is going to get out with length {0}", sneakyLength);
            }
            else if (den[currRow, currCol] != den[startRow, startCol])
            {
                Console.WriteLine("Sneaky is going to be stuck in the den at [{0},{1}]", currRow, currCol);
            }
        }
    }
}

