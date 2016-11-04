/*
Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, int, uint, long, ulong
to represent the following values: 52130, -115, 4825932, 97, -10000.
Choose a large enough type for each number to ensure it will fit in it. Try to compile the code.
*/

using System;

class DeclareVariables
{
    static void Main()
    {
        sbyte signedByte = -115;
        byte unsignedByte = 97;
        ushort unsignedShort = 52130;
        short signedShort = -10000;
        uint unsignedInt = 4825932;

        Console.WriteLine(signedByte);
        Console.WriteLine(unsignedByte);
        Console.WriteLine(unsignedShort);
        Console.WriteLine(signedShort);
        Console.WriteLine(unsignedInt);
    }
}

