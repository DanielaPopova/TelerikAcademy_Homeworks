using System;

class MutantSquirrels
{
    static void Main()
    {
        long trees = long.Parse(Console.ReadLine());
        long branchesPerTree = long.Parse(Console.ReadLine());
        long squirrelPerBranch = long.Parse(Console.ReadLine());
        long tailsPerSquirrel = long.Parse(Console.ReadLine());

        double tailsCount = trees * branchesPerTree * squirrelPerBranch * tailsPerSquirrel;
        
        if (tailsCount % 2 == 0)
        {
            tailsCount *= 376439;
        }
        else
        {
            tailsCount /= 7.0;
        }

        Console.WriteLine(tailsCount.ToString("F3"));
    }
}

