using System;

class BinarySearch
{
    static void Main()
    {
        //string[] input = Console.ReadLine().Split(' ');

        //int[] nums = new int[input.Length];

        //for (int i = 0; i < input.Length; i++)
        //{
        //    nums[i] = int.Parse(input[i]);
        //    //Console.WriteLine(nums[i]);
        //}

        int len = int.Parse(Console.ReadLine());
        int[] nums = new int[len];
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(nums);

        int searchedNum = int.Parse(Console.ReadLine());

        int start = 0;
        int end = nums.Length - 1;
        int mid = 0;

        bool found = false;

        while (!found && start <= end)
        {
            mid = ((start + end) / 2);

            if (searchedNum == nums[mid])
            {
                found = true;
            }
            else
	        {
                if (searchedNum > nums[mid])
                {
                    start = mid + 1;
                }
                else if (searchedNum < nums[mid])
                {
                    end = mid - 1;
                }
	        }
        }

        if (found == true)
        {
            Console.WriteLine(mid);
        }
        else
        {
            Console.WriteLine(-1);
        }
    }
}

// other solution

//namespace Homeworks
//{
//    using System;

//    class Program
//    {
//        static void Main()
//        {
//            int length = int.Parse(Console.ReadLine());
//            int[] array = new int[length];

//            for (int i = 0; i < length; i++)
//            {
//                array[i] = int.Parse(Console.ReadLine());
//            }

//            int searchedNumber = int.Parse(Console.ReadLine());
//            int searchedIndex = 0;

//            Array.Sort(array);

//            int left = 0;
//            int right = array.Length - 1;
//            int middle = (left + right) / 2;
//            bool found = false;

//            while (left < right)
//            {
//                if (array[middle] < searchedNumber)
//                {
//                    left = middle + 1;
//                }
//                else if(array[middle] > searchedNumber)
//                {
//                    right = middle - 1;
//                }
//                else
//                {
//                    searchedIndex = middle;
//                    found = true;
//                    break;
//                }

//                for (int i = left; i < right; i++)
//                {
//                    if (array[i] == searchedNumber)
//                    {
//                        searchedIndex = i;
//                        found = true;
//                    }
//                }

//                middle = (left + right) / 2;
//            }

//            Console.WriteLine(found ? searchedIndex : -1);
//        }
//    }
//}

