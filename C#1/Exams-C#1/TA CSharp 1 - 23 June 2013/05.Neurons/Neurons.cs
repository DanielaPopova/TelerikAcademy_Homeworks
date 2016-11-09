using System;
using System.Collections.Generic;

class Neurons
{
    static void Main()
    {
        string input = string.Empty;
        List<long> allNumbers = new List<long>();

        while (input != "-1")
        {
            input = Console.ReadLine();

            if (input == "-1")
            {
                break;
            }

            long number = long.Parse(input);

            string binary = Convert.ToString(number, 2).PadLeft(32, '0');
            int firstOneIndex = binary.IndexOf('1');
            int lastOneIndex = binary.LastIndexOf('1');

            char[] binaryChar = new char[32];
            for (int i = 0; i < binary.Length; i++)
            {
                binaryChar[i] = binary[i];
            }

            if (firstOneIndex != -1 || lastOneIndex != -1)
            {
                for (int i = firstOneIndex; i <= lastOneIndex; i++)
                {
                    if (binaryChar[i] == '1')
                    {
                        binaryChar[i] = '0';
                    }
                    else
                    {
                        binaryChar[i] = '1';
                    }
                }
            }

            string result = new string(binaryChar);
            long resultNum = Convert.ToInt64(result, 2);
            allNumbers.Add(resultNum);
        }

        for (int i = 0; i < allNumbers.Count; i++)
        {
            Console.WriteLine(allNumbers[i]);
        }
    }
}

//bitwise 100/100

//using System;

//class Neurons
//{
//    static void Main()
//    {
//        while (true)
//        {
//            long line = long.Parse(Console.ReadLine());
//            if (line == -1)
//            {
//                break;
//            }

//            int mostLeftIndex = -1;
//            int mostRightIndex = -1;

//            for (int i = 0; i < 32; i++)
//            {
//                long bit = (line & (1 << i)) >> i;

//                if (bit == 1)
//                {
//                    if (mostRightIndex == -1)
//                    {
//                        mostRightIndex = i;
//                    }

//                    mostLeftIndex = i;
//                }
//            }

//            if (mostLeftIndex == -1)
//            {
//                Console.WriteLine(0);
//                continue;
//            }

//            long result = 0;

//            for (int i = mostRightIndex; i <= mostLeftIndex; i++)
//            {
//                long bit = (line & (1 << i)) >> i;

//                if (bit == 0)
//                {
//                    result = result | (1 << i);
//                }
//            }

//            Console.WriteLine(result);
//        }
//    }
//}

