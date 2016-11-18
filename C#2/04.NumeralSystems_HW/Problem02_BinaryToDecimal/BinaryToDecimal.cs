using System;

class BinaryToDecimal
{
    static void Main(string[] args)
    {
        string binary = Console.ReadLine();
        Console.WriteLine(ConvertBinaryToDecimal(binary));
    }

    static long ConvertBinaryToDecimal(string binaryNum)
    {
        long decimalNum = 0;
        for (int i = 0; i < binaryNum.Length; i++)
        {
            decimalNum = decimalNum + int.Parse(binaryNum[i].ToString()) * (long)Math.Pow(2, binaryNum.Length - 1 - i);
        }

        return decimalNum;
    }
}

/*
using System;
using System.Numerics;

class SortingArray
{
    static void Main()
    {
        string binary = Console.ReadLine();
        Console.WriteLine(ConvertBinaryToDecimal(binary));        
    }

    static BigInteger ConvertBinaryToDecimal(string binary)
    {        
        BigInteger decimalNumber = 0;

        for (int i = 0; i < binary.Length; i++)
        {
            int currBit = binary[i] - '0';
            decimalNumber = currBit + 2 * decimalNumber;
        }

        return decimalNumber;
    }
}
*/

