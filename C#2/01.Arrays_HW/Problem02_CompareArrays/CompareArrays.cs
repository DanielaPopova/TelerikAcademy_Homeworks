using System;

class CompareArrays
{
    static void Main()
    {
        //Console.Write("Enter the length of the first array: ");
        int arrLength = int.Parse(Console.ReadLine());
        //Console.Write("Enter the length of the second array: ");
        //int arr2Length = int.Parse(Console.ReadLine());

        double[] arr1 = new double[arrLength];
        double[] arr2 = new double[arrLength];

       bool isEqual = false;
       int count = 0;

        //Console.WriteLine("Enter {0} integer numbers for the first array, each on separate line:", arrLength);
        for (int i = 0; i < arr1.Length; i++)
        {            
            arr1[i] = double.Parse(Console.ReadLine());            
        }

        //Console.WriteLine("Enter {0} integer numbers for the second array, each on a separate line:", arrLength);
        for (int i = 0; i < arr2.Length; i++)
        {
            arr2[i] = double.Parse(Console.ReadLine());
        }

        //if (arr1.Length == arr2.Length)
        //{
            for (int i = 0; i < arrLength; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    isEqual = true;
                    //Console.WriteLine("Index [{0}] = {1}\nIndex [{2}] = {3}\n --> equal\n", i, arr1[i], i, arr2[i]);                    
                }
                else 
                {                    
                    isEqual = false;
                    count++;
                    //Console.WriteLine("Index [{0}] = {1}\nIndex [{2}] = {3}\n --> not equal\n", i, arr1[i], i, arr2[i]);                   
                }
                
            }
            //Console.WriteLine("Are the arrays equal? --> {0}", isEqual);
            if (isEqual && count == 0)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not equal");
            }
        //}

        
        //else
        //{
        //    Console.WriteLine("The arrays should have equal lengths, but still...");
        //    int smallerLength = arr2.Length;

        //    if (arr1.Length < arr2.Length)
        //    {
        //        smallerLength = arr1.Length;                
        //    }
            
        //    for (int i = 0; i < smallerLength; i++)
        //    {
        //        if (arr1[i] == arr2[i])
        //        {
        //            Console.WriteLine("Index [{0}] = {1}\nIndex [{2}] = {3}\n --> equal\n", i, arr1[i], i, arr2[i]);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Index [{0}] = {1}\nIndex [{2}] = {3}\n --> not equal\n", i, arr1[i], i, arr2[i]);
        //        }
        //    }            
        //}
   }
}

