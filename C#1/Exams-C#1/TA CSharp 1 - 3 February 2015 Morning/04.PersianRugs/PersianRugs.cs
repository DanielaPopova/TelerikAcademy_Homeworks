using System;

namespace _04.PersianRugs
{
    class PersianRugs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());

            int size = 2 * n + 1;

            for (int i = 0; i < n; i++)
            {
                int space = size - 2 * distance - 2 * i - 2; 

                Console.Write(new string('#', i));
                Console.Write("\\");

                if (space >= 3)
                {
                    Console.Write(new string(' ', distance));
                    Console.Write("\\");
                    Console.Write(new string('.', space - 2));
                    Console.Write("/");
                    Console.Write(new string(' ', distance));                                                   
                }
                else
                {
                    Console.Write(new string(' ', size - 2 - i - i));
                }

                Console.Write("/");
                Console.Write(new string('#', i));

                Console.WriteLine();
            }

            //middle
            Console.WriteLine("{0}X{0}", new string('#', n));

            //lower part
            for (int i = n - 1; i >= 0; i--)
            {
                int space = size - 2 * distance - 2 * i - 2;

                Console.Write(new string('#', i));
                Console.Write("/");

                if (space >= 3)
                {
                    Console.Write(new string(' ', distance));
                    Console.Write("/");
                    Console.Write(new string('.', space - 2));
                    Console.Write("\\");
                    Console.Write(new string(' ', distance));
                }
                else
                {
                    Console.Write(new string(' ', size - i - i - 2));
                }

                Console.Write("\\");
                Console.Write(new string('#', i));

                Console.WriteLine();
            }     
        }
    }
}
