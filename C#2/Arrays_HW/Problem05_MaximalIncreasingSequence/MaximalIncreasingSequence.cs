using System;

class MaximalIncreasingSequence
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        int[] arr = new int[length];
        for (int i = 0; i < length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int bestLen = 0;
        int currLen = 1;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] < arr[i + 1])
            {
                currLen++;
                if (currLen > bestLen)
                {
                    bestLen = currLen;
                }
            }
            else
            {
                currLen = 1;
            }
        }
        Console.WriteLine(bestLen);
    }
}


//using System;

//class MaximalIncreasingSequence
//{
//    static void Main()
//    {
//        int length = int.Parse(Console.ReadLine());

//        int[] arr = new int[length];
//        for (int i = 0; i < length; i++)
//        {
//            arr[i] = int.Parse(Console.ReadLine());
//        }

//        int bestLen = 1;
//        int currLen = 1;

//        int element = arr[0];
//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (element < arr[i])
//            {
//                currLen++;
//                if (currLen > bestLen)
//                {
//                    bestLen = currLen;
//                }
//            }
//            else
//            {
//                currLen = 1;
//                element = arr[i];
//            }
//        }
//        Console.WriteLine(bestLen);
//    }
//}