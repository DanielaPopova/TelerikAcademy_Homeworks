using System;

class Warhead
{
    static void Main()
    {
        int[,] board = new int[16, 16];

        for (int i = 0; i < 16; i++)
        {
            string currLine = Console.ReadLine();
            for (int j = 0; j < 16; j++)
            {
                char currSymbol = currLine[j];
                board[i, j] = currSymbol - '0';
            }
        }

        while (true)
        {
            string currOperation = Console.ReadLine();

            if (currOperation == "cut")
            {
                string wire = Console.ReadLine();

                if (wire == "blue")
                {
                    int countBlue = 0;
                    int countRed = 0;

                    for (int row = 1; row < 15; row++)
                    {
                        for (int col = 8; col < 15; col++)
                        {
                            int currRow = row;
                            int currCol = col;

                            int aboveRow = row - 1;
                            int belowRow = row + 1;

                            int beforeCol = col - 1;
                            int afterCol = col + 1;

                            bool topLeft = false;
                            bool topMiddle = false;
                            bool topRight = false;
                            bool currLeft = false;
                            bool currRight = false;
                            bool bottomLeft = false;
                            bool bottomMiddle = false;
                            bool bottomRight = false;

                            //check if all are ones
                            if (aboveRow >= 0 && beforeCol >= 0 && board[aboveRow, beforeCol] == 1)
                            {
                                topLeft = true;
                            }

                            if (aboveRow >= 0 && board[aboveRow, currCol] == 1)
                            {
                                topMiddle = true;
                            }

                            if (aboveRow >= 0 && afterCol < 16 && board[aboveRow, afterCol] == 1)
                            {
                                topRight = true;
                            }

                            if (beforeCol >= 0 && board[currRow, beforeCol] == 1)
                            {
                                currLeft = true;
                            }

                            if (afterCol < 16 && board[currRow, afterCol] == 1)
                            {
                                currRight = true;
                            }

                            if (belowRow < 16 && beforeCol >= 0 && board[belowRow, beforeCol] == 1)
                            {
                                bottomLeft = true;
                            }

                            if (belowRow < 16 && board[belowRow, currCol] == 1)
                            {
                                bottomMiddle = true;
                            }

                            if (belowRow < 16 && afterCol < 16 && board[belowRow, afterCol] == 1)
                            {
                                bottomRight = true;
                            }

                            //if all are ones, make them 0
                            if (topLeft && topMiddle && topRight && currLeft && currRight && bottomLeft && bottomMiddle && bottomRight)
                            {
                                countBlue++;
                            }
                        }
                    }

                    for (int row = 1; row < 15; row++)
                    {
                        for (int col = 1; col < 8; col++)
                        {
                            int currRow = row;
                            int currCol = col;

                            int aboveRow = row - 1;
                            int belowRow = row + 1;

                            int beforeCol = col - 1;
                            int afterCol = col + 1;

                            bool topLeft = false;
                            bool topMiddle = false;
                            bool topRight = false;
                            bool currLeft = false;
                            bool currRight = false;
                            bool bottomLeft = false;
                            bool bottomMiddle = false;
                            bool bottomRight = false;

                            //check if all are ones
                            if (aboveRow >= 0 && beforeCol >= 0 && board[aboveRow, beforeCol] == 1)
                            {
                                topLeft = true;
                            }

                            if (aboveRow >= 0 && board[aboveRow, currCol] == 1)
                            {
                                topMiddle = true;
                            }

                            if (aboveRow >= 0 && afterCol < 16 && board[aboveRow, afterCol] == 1)
                            {
                                topRight = true;
                            }

                            if (beforeCol >= 0 && board[currRow, beforeCol] == 1)
                            {
                                currLeft = true;
                            }

                            if (afterCol < 16 && board[currRow, afterCol] == 1)
                            {
                                currRight = true;
                            }

                            if (belowRow < 16 && beforeCol >= 0 && board[belowRow, beforeCol] == 1)
                            {
                                bottomLeft = true;
                            }

                            if (belowRow < 16 && board[belowRow, currCol] == 1)
                            {
                                bottomMiddle = true;
                            }

                            if (belowRow < 16 && afterCol < 16 && board[belowRow, afterCol] == 1)
                            {
                                bottomRight = true;
                            }

                            //if all are ones, make them 0
                            if (topLeft && topMiddle && topRight && currLeft && currRight && bottomLeft && bottomMiddle && bottomRight)
                            {
                                countRed++;
                            }
                        }
                    }

                    if (countBlue == 0)
                    {
                        Console.WriteLine(countRed);
                        Console.WriteLine("disarmed");
                    }
                    else
                    {
                        Console.WriteLine(countBlue);
                        Console.WriteLine("BOOM");
                    }
                }
                else
                {
                    int countBlue = 0;
                    int countRed = 0;

                    //count red
                    for (int row = 1; row < 15; row++)
                    {
                        for (int col = 1; col < 8; col++)
                        {
                            int currRow = row;
                            int currCol = col;

                            int aboveRow = row - 1;
                            int belowRow = row + 1;

                            int beforeCol = col - 1;
                            int afterCol = col + 1;

                            bool topLeft = false;
                            bool topMiddle = false;
                            bool topRight = false;
                            bool currLeft = false;
                            bool currRight = false;
                            bool bottomLeft = false;
                            bool bottomMiddle = false;
                            bool bottomRight = false;

                            //check if all are ones
                            if (aboveRow >= 0 && beforeCol >= 0 && board[aboveRow, beforeCol] == 1)
                            {
                                topLeft = true;
                            }

                            if (aboveRow >= 0 && board[aboveRow, currCol] == 1)
                            {
                                topMiddle = true;
                            }

                            if (aboveRow >= 0 && afterCol < 16 && board[aboveRow, afterCol] == 1)
                            {
                                topRight = true;
                            }

                            if (beforeCol >= 0 && board[currRow, beforeCol] == 1)
                            {
                                currLeft = true;
                            }

                            if (afterCol < 16 && board[currRow, afterCol] == 1)
                            {
                                currRight = true;
                            }

                            if (belowRow < 16 && beforeCol >= 0 && board[belowRow, beforeCol] == 1)
                            {
                                bottomLeft = true;
                            }

                            if (belowRow < 16 && board[belowRow, currCol] == 1)
                            {
                                bottomMiddle = true;
                            }

                            if (belowRow < 16 && afterCol < 16 && board[belowRow, afterCol] == 1)
                            {
                                bottomRight = true;
                            }

                            //if all are ones, make them 0
                            if (topLeft && topMiddle && topRight && currLeft && currRight && bottomLeft && bottomMiddle && bottomRight)
                            {
                                countRed++;
                            }
                        }
                    }

                    for (int row = 1; row < 15; row++)
                    {
                        for (int col = 8; col < 15; col++)
                        {
                            int currRow = row;
                            int currCol = col;

                            int aboveRow = row - 1;
                            int belowRow = row + 1;

                            int beforeCol = col - 1;
                            int afterCol = col + 1;

                            bool topLeft = false;
                            bool topMiddle = false;
                            bool topRight = false;
                            bool currLeft = false;
                            bool currRight = false;
                            bool bottomLeft = false;
                            bool bottomMiddle = false;
                            bool bottomRight = false;

                            //check if all are ones
                            if (aboveRow >= 0 && beforeCol >= 0 && board[aboveRow, beforeCol] == 1)
                            {
                                topLeft = true;
                            }

                            if (aboveRow >= 0 && board[aboveRow, currCol] == 1)
                            {
                                topMiddle = true;
                            }

                            if (aboveRow >= 0 && afterCol < 16 && board[aboveRow, afterCol] == 1)
                            {
                                topRight = true;
                            }

                            if (beforeCol >= 0 && board[currRow, beforeCol] == 1)
                            {
                                currLeft = true;
                            }

                            if (afterCol < 16 && board[currRow, afterCol] == 1)
                            {
                                currRight = true;
                            }

                            if (belowRow < 16 && beforeCol >= 0 && board[belowRow, beforeCol] == 1)
                            {
                                bottomLeft = true;
                            }

                            if (belowRow < 16 && board[belowRow, currCol] == 1)
                            {
                                bottomMiddle = true;
                            }

                            if (belowRow < 16 && afterCol < 16 && board[belowRow, afterCol] == 1)
                            {
                                bottomRight = true;
                            }

                            //if all are ones, make them 0
                            if (topLeft && topMiddle && topRight && currLeft && currRight && bottomLeft && bottomMiddle && bottomRight)
                            {
                                countBlue++;
                            }
                        }
                    }

                    if (countRed == 0)
                    {
                        Console.WriteLine(countBlue);
                        Console.WriteLine("disarmed");
                    }
                    else
                    {
                        Console.WriteLine(countRed);
                        Console.WriteLine("BOOM");
                    }
                }

                break;
            }

            if (currOperation == "hover" || currOperation == "operate")
            {
                int currRow = int.Parse(Console.ReadLine());
                int currCol = int.Parse(Console.ReadLine());

                if (currOperation == "hover")
                {
                    int currNumber = board[currRow, currCol];

                    if (currNumber == 1)
                    {
                        Console.WriteLine("*");
                    }
                    else
                    {
                        Console.WriteLine("-");
                    }
                }

                if (currOperation == "operate")
                {
                    int currNumber = board[currRow, currCol];

                    if (currNumber == 1)
                    {
                        Console.WriteLine("missed");

                        int count = 0;

                        for (int row = 1; row < 15; row++)
                        {
                            for (int col = 1; col < 15; col++)
                            {
                                int aboveRow = row - 1;
                                int belowRow = row + 1;

                                int beforeCol = col - 1;
                                int afterCol = col + 1;

                                bool topLeft = false;
                                bool topMiddle = false;
                                bool topRight = false;
                                bool currLeft = false;
                                bool currRight = false;
                                bool bottomLeft = false;
                                bool bottomMiddle = false;
                                bool bottomRight = false;

                                //check if all are ones
                                if (aboveRow >= 0 && beforeCol >= 0 && board[aboveRow, beforeCol] == 1)
                                {
                                    topLeft = true;
                                }

                                if (aboveRow >= 0 && board[aboveRow, col] == 1)
                                {
                                    topMiddle = true;
                                }

                                if (aboveRow >= 0 && afterCol < 16 && board[aboveRow, afterCol] == 1)
                                {
                                    topRight = true;
                                }

                                if (beforeCol >= 0 && board[row, beforeCol] == 1)
                                {
                                    currLeft = true;
                                }

                                if (afterCol < 16 && board[row, afterCol] == 1)
                                {
                                    currRight = true;
                                }

                                if (belowRow < 16 && beforeCol >= 0 && board[belowRow, beforeCol] == 1)
                                {
                                    bottomLeft = true;
                                }

                                if (belowRow < 16 && board[belowRow, col] == 1)
                                {
                                    bottomMiddle = true;
                                }

                                if (belowRow < 16 && afterCol < 16 && board[belowRow, afterCol] == 1)
                                {
                                    bottomRight = true;
                                }

                                //if all are ones, make them 0
                                if (topLeft && topMiddle && topRight && currLeft && currRight && bottomLeft && bottomMiddle && bottomRight)
                                {
                                    count++;
                                }
                            }
                        }
                      
                        Console.WriteLine(count);
                        Console.WriteLine("BOOM");
                        break;                                               
                    }
                    else
                    {
                        int aboveRow = currRow - 1;
                        int belowRow = currRow + 1;

                        int beforeCol = currCol - 1;
                        int afterCol = currCol + 1;

                        bool topLeft = false;
                        bool topMiddle = false;
                        bool topRight = false;
                        bool currLeft = false;                        
                        bool currRight = false;
                        bool bottomLeft = false;
                        bool bottomMiddle = false;
                        bool bottomRight = false;

                        //check if all are ones
                        if (aboveRow >= 0 && beforeCol >= 0 && board[aboveRow, beforeCol] == 1)
                        {
                            topLeft = true;
                        }

                        if (aboveRow >= 0 && board[aboveRow, currCol] == 1)
                        {
                            topMiddle = true;
                        }

                        if (aboveRow >= 0 && afterCol < 16 && board[aboveRow, afterCol] == 1)
                        {
                            topRight = true;
                        }

                        if (beforeCol >= 0 && board[currRow, beforeCol] == 1)
                        {
                            currLeft = true;
                        }

                        if (afterCol < 16 && board[currRow, afterCol] == 1)
                        {
                            currRight = true;
                        }

                        if (belowRow < 16 && beforeCol >= 0 && board[belowRow, beforeCol] == 1)
                        {
                            bottomLeft = true;
                        }

                        if (belowRow < 16 && board[belowRow, currCol] == 1)
                        {
                            bottomMiddle = true;
                        }

                        if (belowRow < 16 && afterCol < 16 && board[belowRow, afterCol] == 1)
                        {
                            bottomRight = true;
                        }

                        //if all are ones, make them 0
                        if (topLeft && topMiddle && topRight && currLeft && currRight && bottomLeft && bottomMiddle && bottomRight)
                        {
                            for (int row = aboveRow; row <= belowRow; row++)
                            {
                                for (int col = beforeCol; col <= afterCol; col++)
                                {
                                    board[row, col] = 0;
                                }
                            }
                        }
                    }
                }

            }
        }      
    }   
}

