using System;

namespace _05.FindBits
{
    class FindBits
    {
        static void Main()
        {
            // string solution
            int search = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            string pattern = Convert.ToString(search, 2).PadLeft(5, '0');
            //Console.WriteLine(pattern);
            int occurrence = 0;

            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                string binaryRep = Convert.ToString(number, 2).PadLeft(29, '0');
                //Console.WriteLine(binaryRep);                

                for (int j = 0; j <= binaryRep.Length - pattern.Length; j++)
                {
                    int start = j;
                    int end = j + pattern.Length;
                    int count = 0;
                    int currOccurrence = 0;

                    for (int k = start; k < end; k++, count++)
                    {                        
                        if (binaryRep[k] == pattern[count])
                        {
                            currOccurrence++;

                            if (currOccurrence == pattern.Length)
                            {
                                occurrence++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(occurrence);
        }
    }
}
