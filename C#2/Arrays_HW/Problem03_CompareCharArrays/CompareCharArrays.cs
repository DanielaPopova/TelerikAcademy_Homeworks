using System;

class CompareCharArrays
{
    static void Main()
    {
        string firstArr = Console.ReadLine();
        string secondArr = Console.ReadLine();

        char[] arr1 = new char[firstArr.Length];
        char[] arr2 = new char[secondArr.Length];

        bool firstSmaller = false;
        bool secondSmaller = false;
        bool equal = true;

        for (int i = 0; i < firstArr.Length; i++)
        {
            arr1[i] = char.Parse(firstArr[i].ToString());
            //Console.WriteLine(arr1[i]);
        }

        for (int i = 0; i < secondArr.Length; i++)
        {
            arr2[i] = char.Parse(secondArr[i].ToString());
            //Console.WriteLine(arr2[i]);
        }

        int minLen = arr1.Length;

        if (arr1.Length < arr2.Length)
        {
            minLen = arr1.Length;
        }
        else if (arr1.Length > arr2.Length)
        {
            minLen = arr2.Length;
        }
        
            for (int i = 0; i < minLen; i++)
            {
                if (arr1[i] < arr2[i])
                {
                    firstSmaller = true;
                    secondSmaller = false;
                    equal = false;
                    //Console.WriteLine("<");
                }
                else if (arr1[i] > arr2[i])
                {
                    secondSmaller = true;
                    firstSmaller = false;
                    equal = false;
                    //Console.WriteLine(">");
                }
                else
                {
                    equal = true;
                    firstSmaller = false;
                    secondSmaller = false;
                    //Console.WriteLine("=");
                }
            }

            if (firstSmaller == true && secondSmaller == false && equal == false)
            {
                Console.WriteLine("<");
            }
            else if (firstSmaller == false && secondSmaller == true && equal == false)
            {
                Console.WriteLine(">");
            }
            else if (firstSmaller == false && secondSmaller == false && equal == true)
            {
                Console.WriteLine("=");
            }
       
    }
}

 //Different approach compared to the previous problem
        
        //char[] delimiters = {' ', ','};

        //Console.WriteLine("Enter letters for the the first array, separated by space");
        //string[] inputFirstArr = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        //Console.WriteLine("Enter letters for the second array, separated by space");
        //string[] inputSecondArr = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        

        //char[] arr1 = new char[inputFirstArr.Length];
        //char[] arr2 = new char[inputSecondArr.Length];        

        //for (int i = 0; i < inputFirstArr.Length; i++)
        //{
        //    arr1[i] = char.Parse(inputFirstArr[i]);            
        //}

        //for (int i = 0; i < inputSecondArr.Length; i++)
        //{
        //    arr2[i] = char.Parse(inputSecondArr[i]);
        //}

        //if (arr1.Length == arr2.Length)
        //{
        //    bool isEqual = true;
        //    for (int i = 0; i < arr1.Length; i++)
        //    {
        //        if (arr1[i].Equals(arr2[i]))
        //        {
        //            isEqual = true;
        //        }
        //        else
        //        {
        //            isEqual = false;
        //        }
        //    }
        //    Console.WriteLine("Equal arrays? --> {0}", isEqual);
        //}
        //else
        //{
        //    Console.WriteLine("The arrays should have equal number elements");
        //}

