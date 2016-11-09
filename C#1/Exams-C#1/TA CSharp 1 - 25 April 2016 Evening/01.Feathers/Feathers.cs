using System;

class Feathers
{
    static void Main()
    {
        int birds = int.Parse(Console.ReadLine());
        int birdFeathers = int.Parse(Console.ReadLine());

        double averageFeathers;

        if (birds % 2 == 0)
        {
            averageFeathers = (birdFeathers / (double)birds) * 123123123123;
        }
        else
        {
            averageFeathers = (birdFeathers / (double)birds) / 317;
        }

        Console.WriteLine(averageFeathers.ToString("F4"));
    }
}
