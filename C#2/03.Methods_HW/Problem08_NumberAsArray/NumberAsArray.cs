using System;
using System.Text;
using System.Collections.Generic;


//TODO: 9 9 9 + 9 9 9 => 8 9 9 ?

class NumberAsArray
{
    static void Main()
    {
        string[] inputLengths = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int firstArrLen = int.Parse(inputLengths[0]);
        int secondArrLen = int.Parse(inputLengths[1]);

        string[] firstRow = Console.ReadLine().Split(' ');
        List<string> firstList = new List<string>();        
        for (int i = 0; i < firstArrLen; i++)
        {
            firstList.Add(firstRow[i]);
        }
        //PrintArray(firstList);

        string[] secondRow = Console.ReadLine().Split(' ');
        List<string> secondList = new List<string>();
        for (int i = 0; i < secondArrLen; i++)
        {
            secondList.Add(secondRow[i]);
        }
        //PrintArray(secondList);

        //string[] firstArray = {"0", "3", "9", "3", "2"};
        //string[] secondArray = { "5", "9", "5", "1", "7" };

        //making both lists with equal lenghts
        int difference = Math.Abs(firstList.Count - secondList.Count);
        if (firstList.Count > secondList.Count)
        {
            for (int i = 0; i < difference; i++)
            {
                secondList.Add("0");
            }
        }
        else if (firstList.Count < secondList.Count)
        {
            for (int i = 0; i < difference; i++)
            {
                firstList.Add("0");
            }
        }

        StringBuilder result = SumArrays(firstList, secondList);

        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i] + " ");
        }        
        
    }

    static StringBuilder SumArrays(List<string> list1, List<string> list2)
    {
        StringBuilder result = new StringBuilder();

        int maxLength = Math.Max(list1.Count, list2.Count);
        int sumDigit = 0;
        int plusOne = 0;        

        for (int i = 0; i < maxLength; i++)
        {
            
                sumDigit = int.Parse(list1[i]) + int.Parse(list2[i]) + plusOne;

                if (sumDigit >= 10)
                {
                    plusOne = sumDigit / 10;
                    sumDigit = sumDigit % 10;                
                }
                else
                {
                    plusOne = 0;
                }

                result.Append(sumDigit);
        }

        return result;
        
    }   

    static void PrintArray(List<string> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();
    }
}


/*
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string sizes = Console.ReadLine();

        int sizeFirstArray = int.Parse(sizes.Split(' ')[0]);
        int sizeSecondArray = int.Parse(sizes.Split(' ')[1]);

        string[] firstArray = Console.ReadLine().Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] secondArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (firstArray.Length > secondArray.Length)
        {
            secondArray = AdjustArrayLength(secondArray, sizeFirstArray);
        }
        else
        {
            firstArray = AdjustArrayLength(firstArray, sizeSecondArray);
        }

        List<string> result = SumArray(firstArray, secondArray);
        Console.WriteLine(String.Join(" ", result));

    }

    static string[] AdjustArrayLength(string[] array, int length)
    {
        List<string> adjustedList = new List<string>(array);

        for (int i = array.Length; i < length; i++)
        {
            adjustedList.Add("0");
        }

        return adjustedList.ToArray();
    }

    static List<string> SumArray(string[] firstArray, string[] secondArray)
    {
        int length = firstArray.Length;
        List<string> result = new List<string>();

        int remainder = 0;

        for (int i = 0; i < length; i++)
        {
            int firstArrayCurrentDigit = int.Parse(firstArray[i]);
            int secondArrayCurrentDigit = int.Parse(secondArray[i]);

            int sum = firstArrayCurrentDigit + secondArrayCurrentDigit + remainder;           

            if (sum >= 10)
            {
                result.Add((sum % 10).ToString());
                remainder = sum / 10;
            }
            else
            {
                result.Add(sum.ToString());
                remainder = 0;
            }
        }

        return result; 
    }   
}
*/
