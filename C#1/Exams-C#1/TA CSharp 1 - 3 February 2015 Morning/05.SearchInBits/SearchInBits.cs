using System;

namespace _05.SearchInBits
{
    class SearchInBits
    {
        static void Main()
        {
            int search = int.Parse(Console.ReadLine());
            //string binarySearch = Convert.ToString(search, 2).PadLeft(4, '0');
            int length = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                //string binaryNum = Convert.ToString(number, 2).PadLeft(30, '0');

                for (int j = 0; j <= 26; j++)
                {
                    bool found = true;

                    for (int k = 0; k <= 3; k++)
                    {
                        int positionInNum = j + k;
                        int positionInSearch = k;

                        int numberBit = (number & (1 << positionInNum)) >> positionInNum;
                        int numberSearch = (search & (1 << positionInSearch)) >> positionInSearch;

                        if (numberBit != numberSearch)
                        {
                            found = false;
                            break;
                        }
                    }

                    if (found)
                    {
                        count++;
                    }
                    
                }
            }

            Console.WriteLine(count);


        }
    }
}
