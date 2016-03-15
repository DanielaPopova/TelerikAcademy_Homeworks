/*
Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.
Examples:

numbers	    number as words
0	        Zero
9	        Nine
10	        Ten
12	        Twelve
19	        Nineteen
25	        Twenty five
98	        Ninety eight
98	        Ninety eight
273	        Two hundred and seventy three
400	        Four hundred
501	        Five hundred and one
617	        Six hundred and seventeen
711	        Seven hundred and eleven
999	        Nine hundred and ninety nine
*/

using System;

class NumberAsWords
{
    static void Main()
    {
        Console.WriteLine("Enter number in range [0...999]");

        int number;
        

        if (int.TryParse(Console.ReadLine(), out number))
        {

            string[] onesUp = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" }; 
            string[] tensUp = { "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] teensUp = { "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

            string[] onesLow = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }; //Ctrl + U --> lower case
            string[] tensLow = { "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] teensLow = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

            int hundreds = number / 100;
            int tens = (number / 10) % 10;
            int ones = number % 10;

            string numAsWords = string.Empty;

            //Console.WriteLine((451 / 10) % 10);
            //Console.WriteLine(451 % 10);

           //1, 2, 3...9
            if (hundreds == 0 && tens == 0 && ones >= 0)
            {
                numAsWords = onesUp[ones];
                Console.WriteLine(numAsWords);
            }

            //11, 12, 13...19
            if (number >= 11 && number <= 19)
            {
                numAsWords = teensUp[number - 11];
                Console.WriteLine(numAsWords);
            }

            if (hundreds == 0)
            {
                // 10, 20, 30...90
                if (tens >= 1 /*&& tens <= 9)*/ && ones == 0)
                {
                    numAsWords = tensUp[tens - 1];
                    Console.WriteLine(numAsWords);
                }  
                // 21, 22...29...31, 32...39...91, 92...99
                else if (tens >= 2 /*&& tens <= 9)*/ && (ones >= 1 && ones <= 9))
                {
                    numAsWords = tensUp[tens - 1] + " " + onesLow[ones];
                    Console.WriteLine(numAsWords);
                }                
            }            
            
            if (hundreds >= 1 )
            {
                // 100, 200, 300...900
                if (tens == 0 && ones == 0)
                {
                    numAsWords = onesUp[hundreds] + " hundred";
                    Console.WriteLine(numAsWords);
                }
                //110, 120...190...210, 220...290...910, 920...990
                else if (tens >= 1 && ones == 0)
                {
                    numAsWords = onesUp[hundreds] + " hundred and " + tensLow[tens - 1];
                    Console.WriteLine(numAsWords);
                }
                //101, 102...109...901, 902...909
                else if (tens == 0 && ones >= 1)
                {
                    numAsWords = onesUp[hundreds] + " hundred and " + onesLow[ones];
                    Console.WriteLine(numAsWords);
                }
                //111, 112...119...911, 912...919
                else if (tens == 1 && ones >= 1)
                {
                    numAsWords = onesUp[hundreds] + " hundred and " + teensLow[ones - 1];
                    Console.WriteLine(numAsWords);
                }
                //all other cases
                else if (tens >= 2 && ones >= 1)
                {
                    numAsWords = onesUp[hundreds] + " hundred and " + tensLow[tens - 1] + " " + onesLow[ones];
                    Console.WriteLine(numAsWords);
                }
            }    
        }

        else
        {
            Console.WriteLine("Number should be in range [0...999]");
        }
    }
}

