using System;

namespace _04.Cube
{
    class Cube
    {
        static void Main()
        {
            int cubeSize = int.Parse(Console.ReadLine());

            int width = 2 * cubeSize - 1;

            int spaces = width - cubeSize;

            //upper part
            Console.WriteLine("{0}{1}", new string(' ', spaces), new string(':', cubeSize));

            int slashes = cubeSize - 2;
            int xes = 0;
            spaces--;

            for (int i = 1; i < width / 2; i++)
            {
                Console.WriteLine("{0}:{1}:{2}:",new string(' ', spaces), new string('/', slashes), new string('X', xes));
                xes++;
                spaces--;
            }

            //middle
            Console.WriteLine("{0}{1}:", new string(':', cubeSize), new string('X', width - cubeSize - 1));

            //lower part
            int spacesInner = cubeSize - 2;
            xes = cubeSize - 3;
            spaces = 1;

            for (int i = width / 2 + 1; i < width - 1; i++)
            {
                Console.WriteLine(":{0}:{1}:{2}", new string(' ', spacesInner), new string('X', xes), new string(' ', spaces));
                xes--;
                spaces++;
            }

            Console.WriteLine("{0}{1}", new string(':', cubeSize), new string(' ', cubeSize - 1));
        }
    }
}
