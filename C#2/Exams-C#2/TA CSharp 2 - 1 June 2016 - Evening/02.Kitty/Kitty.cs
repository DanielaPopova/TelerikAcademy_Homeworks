using System;
using System.Linq;

class Kitty
{
    static void Main()
    {
        char[] symbols = Console.ReadLine().ToCharArray();
        int[] path = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int souls = 0;
        int food = 0;
        int deadlocks = 0;

        int startPosition = 0;

        int jumps = 0;
        bool deadlocked = false;

        for (int i = 0; i <= path.Length; i++)
        {
            char toCollect = symbols[startPosition];

            if (toCollect == '@')
            {
                souls++;
                symbols[startPosition] = '0';
            }
            else if (toCollect == '*')
            {
                food++;
                symbols[startPosition] = '0';
            }
            else if (toCollect == 'x')
            {
                if (startPosition % 2 == 0)
                {
                    if (souls >= 1)
                    {
                        souls--;
                        symbols[startPosition] = '@';
                        deadlocked = false;
                        deadlocks++;
                    }
                    else
                    {
                        deadlocked = true;
                        break;
                    }                    
                }
                else if (startPosition % 2 == 1)
                {
                    if (food >= 1)
                    {
                        food--;
                        symbols[startPosition] = '*';
                        deadlocked = false;
                        deadlocks++;
                    }
                    else
                    {
                        deadlocked = true;
                        break;
                    }
                }
            }

            jumps++;
            if (i == path.Length)
            {
                break;
            }
            startPosition = CalculateNewPosition(startPosition, path[i], symbols.Length);
        }

        if (deadlocked == false)
        {
            Console.WriteLine("Coder souls collected: {0}", souls);
            Console.WriteLine("Food collected: {0}", food);
            Console.WriteLine("Deadlocks: {0}", deadlocks);
        }
        else
        {
            Console.WriteLine("You are deadlocked, you greedy kitty!");
            Console.WriteLine("Jumps before deadlock: {0}", jumps);
        }
    }

    static int CalculateNewPosition(int currPosition, int step, int length)
    {
        int nextPosition = 0;

        if (step < 0)
        {
            nextPosition = (currPosition + step) % length;
            if (nextPosition < 0)
            {
                nextPosition += length;
            }
        }

        if (step > 0)
        {
            nextPosition = (currPosition + step) % length;
        }

        return nextPosition;
    }
}

