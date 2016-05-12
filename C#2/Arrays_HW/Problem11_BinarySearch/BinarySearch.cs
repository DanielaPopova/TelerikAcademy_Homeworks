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

