using System;

class CorrectBrackets
{
    static void Main()
    {
        string expression = Console.ReadLine(); //"((a+b)/5-d)"; //"))a + b(("; //"(a+b)+d+)("; //"(a+b)+d+)(b( * c)"; //)(a+b))//(a+b+(b*c)+(d/s) + (-5)) + ()()

        bool proceed = CountBrackets(expression);
        if (proceed == false)
        {
            Console.WriteLine("Incorrect");   
        }
        else
        {
            bool isCorrect = true;
            int count = 0;

            int indexRightBracket = expression.IndexOf('(');
            int indexLeftBracket = expression.IndexOf(')');

            while (indexRightBracket != -1 && indexLeftBracket != -1)
            {

                if (indexRightBracket < indexLeftBracket)
                {
                    isCorrect = true;
                }
                else
                {
                    isCorrect = false;
                    count++;
                }

                indexRightBracket = expression.IndexOf('(', indexRightBracket + 1);
                indexLeftBracket = expression.IndexOf(')', indexLeftBracket + 1);
            }

            if (isCorrect == true && count == 0)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        } 
    }

    static bool CountBrackets(string expression)
    {
        int rightBracket = 0;
        int leftBracket = 0;

        bool proceed = false;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                rightBracket++;
            }
            else if (expression[i] == ')')
            {
                leftBracket++;
            }
        }

        if (rightBracket == leftBracket)
        {
            proceed = true;
        }
        else
        {
            proceed = false;
        }

        return proceed;
    }
} 

/*
Description

Write a program to check if in a given expression the ( and ) brackets are put correctly.

Input

On the only line you will receive an expression
Output

Print Correct if the brackets are correct
Incorrect otherwise
Constraints

1 <= length of expression <= 10000
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	        Output
((a+b)/5-d) 	Correct
)(a+b))	        Incorrect
*/
