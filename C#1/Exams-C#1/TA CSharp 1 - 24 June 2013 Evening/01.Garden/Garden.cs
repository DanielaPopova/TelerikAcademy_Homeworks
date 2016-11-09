using System;

class Garden
{
    static void Main()
    {
        int tomatoSeeds = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
        int cucumberSeeds = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());
        int potatoSeeds = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
        int carrotSeeds = int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
        int cabbageSeeds = int.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());
        int beansSeeds = int.Parse(Console.ReadLine());

        int totalArea = 250;

        decimal totalSeedsCost = tomatoSeeds * 0.5M + cucumberSeeds * 0.4M + potatoSeeds * 0.25M + carrotSeeds * 0.6M + cabbageSeeds * 0.3M + beansSeeds * 0.4M;

        int beansArea = totalArea - (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea);

        Console.WriteLine("Total costs: {0:F2}", totalSeedsCost);

        if (beansArea > 0)
        {
            Console.WriteLine("Beans area: {0}", beansArea);
        }
        else if (beansArea == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Insufficient area");
        }
    }
}

