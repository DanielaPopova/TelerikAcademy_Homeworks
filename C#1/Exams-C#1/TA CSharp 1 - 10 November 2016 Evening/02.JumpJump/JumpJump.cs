using System;

class JumpJump
{
    static void Main()
    {
        string instructions = Console.ReadLine();

        int position = 0;

        for (int i = position; i < instructions.Length; i++)
        {

            if (position < 0 || position >= instructions.Length)
            {
                Console.WriteLine("Fell off the dancefloor at {0}!", position);
                break;
            }
            else
            {
                char currSymbol = instructions[position];            

                if (currSymbol == '0')
                {                   
                    Console.WriteLine("Too drunk to go on after {0}!", position);
                    break;
                }
                else if (currSymbol == '^')
                {                    
                    Console.WriteLine("Jump, Jump, DJ Tomekk kommt at {0}!", position);
                    break;
                }
                else if ((currSymbol - '0') % 2 == 0)
                {
                    position += (currSymbol - '0');
                }
                else if ((currSymbol - '0') % 2 == 1)
                {
                    position -= (currSymbol - '0');
                }                
            }            
        }
    }
}

