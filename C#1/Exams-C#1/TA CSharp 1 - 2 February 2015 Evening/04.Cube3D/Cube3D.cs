using System;

namespace _04.Cube3D
{
    class Cube3D
    {
        static void Main()
        {
            int cubeSize = int.Parse(Console.ReadLine());
            int wholeWidth = cubeSize * 2 - 1;

            //upper part
            Console.WriteLine("{0}{1}", new string(':', cubeSize), new string(' ', wholeWidth - cubeSize));

            int innerSpace = cubeSize - 2;
            int line = 0;
            int outerSpace = wholeWidth - cubeSize - 1;

            for (int i = 1; i < wholeWidth / 2; i++)
            {
                Console.WriteLine(":{0}:{1}:{2}", new string(' ', innerSpace), new string('|', line), new string(' ', outerSpace));
                outerSpace--;
                line++;
            }

            //middle
            Console.WriteLine("{0}{1}:", new string(':', cubeSize), new string('|', cubeSize - 2));

            //lower part

            outerSpace = 1;
            innerSpace = cubeSize - 2;
            line = cubeSize - 3;

            for (int i = wholeWidth / 2 + 1; i < wholeWidth - 1; i++)
            {
                Console.WriteLine("{0}:{1}:{2}:", new string(' ', outerSpace), new string('-', innerSpace), new string('|', line));
                outerSpace++;
                line--;
            }

            Console.WriteLine("{0}{1}", new string(' ', wholeWidth - cubeSize), new string(':', cubeSize));
        }
    }
}
