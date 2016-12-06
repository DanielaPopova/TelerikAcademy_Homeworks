// 95/100 bgcoder - timelimit - getNewposition() slows down
using System;
using System.Linq;

class DancingMoves
{
    static void Main(string[] args)
    {
        int[] points = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        double sum = 0;
        int rounds = 0;
        int currPosition = 0;

        while (true)
        {
            string commands = Console.ReadLine();
            if (commands == "stop")
            {
                break;
            }

            int times = int.Parse(commands.Split(' ')[0]);
            string direction = commands.Split(' ')[1];
            int step = int.Parse(commands.Split(' ')[2]);

            double currSum = 0;

            for (int i = 0; i < times; i++)
            {
                int nextPosition = GetNextPosition(direction, currPosition, step, points.Length);
                currSum += points[nextPosition];
                currPosition = nextPosition;
            }

            rounds++;
            sum += currSum;            
        }
        
        Console.WriteLine("{0:F1}", sum / rounds);
    }

    static int GetNextPosition(string direction, int currPosition, int step, int length)
    {
        int nextPosition = 0;

        if (direction == "right")
        {
            nextPosition = (currPosition + step) % length;
        }

        if (direction == "left")
        {
            nextPosition = (currPosition - step) % length;
            if (nextPosition < 0)
            {
                nextPosition += length;
            }
        }

        return nextPosition;
    }
}

/*
// 100/100 forum solution
using System;
using System.Linq;
 
class DancingMoves
{
    static int Modulo(int x, int m)
    {
        int r = x % m;
        return r < 0 ? r + m : r;
    }
 
    static void Main(string[] args)
    {
        int[] points = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
 
        double sum = 0;
        int rounds = 0;
        int currPosition = 0;
 
        while (true)
        {
            string commands = Console.ReadLine();
            if (commands == "stop")
            {
                break;
            }
 
            var all = commands.Split(' ');
            int times = int.Parse(all[0]);
            string direction = all[1];
            int step = int.Parse(all[2]);
 
            double currSum = 0;
           
          if (direction == "right")
          {  
            for (int i = 0; i < times; i++)
            {
                currPosition = (currPosition + step) % points.Length;
                currSum += points[currPosition];        
            }
          }
          else if (direction == "left")
          {
            for (int i = 0; i < times; i++)
            {
                currPosition = Modulo(currPosition - step, points.Length);
                currSum += points[currPosition];      
            }
          }
 
            rounds++;
            sum += currSum;            
        }
       
        Console.WriteLine("{0:F1}", sum / rounds);
    }
}
*/

