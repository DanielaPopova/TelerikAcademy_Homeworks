using System;

class BinaryShort
{
    static void Main(string[] args)
    {
        short number = short.Parse(Console.ReadLine());
        if (number > 0)
        {
            Console.WriteLine(ConvertToBinaryPositive(number).PadLeft(16, '0'));            
        }
        else
        {
            Console.WriteLine(ConvertToBinaryNegative(number).PadLeft(16, '0'));
        }
    }

    static string ConvertToBinaryPositive(short number) 
    {
        string binaryRep = String.Empty;

        while (number > 0)
        {
            int remainder = number % 2;
            number /= 2;
            binaryRep = remainder.ToString() + binaryRep;
        }

        return binaryRep;
    }

    static string ConvertToBinaryNegative(short number)    //TODO
    {
        number = Math.Abs(number);
        short one = 1;
        short position = 15;
        short mask = (short)(~(one << position));
        short signedMagnitude = (short)(number & mask);
        short onesCompliment = (short)~signedMagnitude;
        short twosCompliment = (short)(onesCompliment + one);
        string newNum = ConvertToBinaryPositive(twosCompliment);

        return newNum;
    }
    
    
    //static string ConvertToBinary(short number)
    //{
    //    if (number > 0)
    //    {
    //        string binaryRep = String.Empty;

    //        while (number > 0)
    //        {
    //            int remainder = number % 2;
    //            number /= 2;
    //            binaryRep = remainder.ToString() + binaryRep;            
    //        }

    //        return binaryRep;
    //    }
        //else if (number == 0)
        //{
        //    return new string('0', 16);
        //}
    //    else
    //    {
    //        string binaryRep = Convert.ToString(number, 2);
    //        return binaryRep;
    //    }

    //}
}

