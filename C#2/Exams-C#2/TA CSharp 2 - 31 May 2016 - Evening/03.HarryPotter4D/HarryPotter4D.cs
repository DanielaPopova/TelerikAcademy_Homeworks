using System;
using System.Collections.Generic;
using System.Linq;

class HarryPotter4D
{
    static int[] dimensions = new int[4];
    static void Main()
    {
        dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int[] harryPosition = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();       

        int countBasilisks = int.Parse(Console.ReadLine());        
        var basiliskPositions = new List<int[]>();
        char[] basiliskNames = new char[countBasilisks];

        for (int i = 0; i < countBasilisks; i++)
        {
            string[] basiliskData = Console.ReadLine().Split(' ');

            int[] basiliskPosition = GetBasiliskPosition(basiliskData);
            char name = char.Parse(basiliskData[0]);

            basiliskPositions.Add(basiliskPosition);
            basiliskNames[i] = name;
        }

        List<string> allInstructions = new List<string>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input != "END")
            {
                allInstructions.Add(input);
            }
            else
            {
                break;
            }
        }

        int harryMoves = 0;
        char harryName = '@';
        bool hasHarryEscape = true;
        char winningBasilisk = '\0';       

        List<char> allWinningBasiliskNames = new List<char>();

        for (int i = 0; i < allInstructions.Count; i++)
        {
            string[] currInstruction = allInstructions[i].Split(' ');

            char unitToMove = char.Parse(currInstruction[0]);
            int dimension = (int)(char.Parse(currInstruction[1]) - 'A');
            int offset = int.Parse(currInstruction[2]);

            if (unitToMove == harryName)  //Harry
            {
                int countHarryBasiliskMatch = 0;

                harryMoves++;
                harryPosition = UnitNewPosition(harryPosition, dimension, offset);

                for (int l = 0; l < basiliskPositions.Count; l++)
                {
                    char basiliskName = basiliskNames[l];

                    for (int s = 0; s < dimensions.Length; s++)
                    {
                        if (basiliskPositions[l][s] == harryPosition[s])
                        {
                            countHarryBasiliskMatch++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (countHarryBasiliskMatch == 4)
                    {                        
                        allWinningBasiliskNames.Add(basiliskName);
                    }                    

                    countHarryBasiliskMatch = 0;
                }

                if (allWinningBasiliskNames.Count > 0)
                {
                    hasHarryEscape = false;
                    winningBasilisk = DetermineBasiliskWinner(allWinningBasiliskNames);
                    Console.WriteLine("{0}: \"Step {1} was the worst you ever made.\"", winningBasilisk, harryMoves);
                    Console.WriteLine("{0}: \"You will regret until the rest of your life... All 3 seconds of it!\"", winningBasilisk);
                    break;
                }
            }
            else // a-z A-Z
            {
                int countBasiliskHarryMatches = 0;
                int correspondingPositionIndex = 0;
                char basiliskName = '\0';

                for (int m = 0; m < basiliskNames.Length; m++)
                {
                    if (unitToMove == basiliskNames[m])
                    {
                        basiliskName = basiliskNames[m];
                        correspondingPositionIndex = m;
                        break;
                    }
                }

                basiliskPositions[correspondingPositionIndex] = UnitNewPosition(basiliskPositions[correspondingPositionIndex], dimension, offset);

                for (int s = 0; s < dimensions.Length; s++)
                {
                    if (basiliskPositions[correspondingPositionIndex][s] == harryPosition[s])
                    {
                        countBasiliskHarryMatches++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (countBasiliskHarryMatches == 4)
                {
                    hasHarryEscape = false;
                    winningBasilisk = basiliskName;
                    Console.WriteLine("{0}: \"You thought you could escape, didn't you?\" - {1}", winningBasilisk, harryMoves);
                    break;
                }
            }
        }

        if (hasHarryEscape)
        {
            Console.WriteLine("{0}: \"I am the chosen one!\" - {1}", harryName, harryMoves);
        } 
    }  

    // try 2
    public static int[] UnitNewPosition(int[] unitStartPosition, int dimension, int offset)
    {
        int[] newPosition = unitStartPosition;

        newPosition[dimension] = newPosition[dimension] + offset;

        if (newPosition[dimension] >= dimensions[dimension])
        {
            newPosition[dimension] = dimensions[dimension] - 1;
        }
        else if (newPosition[dimension] < 0)
        {
            newPosition[dimension] = 0;
        }

        return newPosition;
    }

    public static int[] GetBasiliskPosition(string[] data)
    {
        int[] basiliskPosition = new int[dimensions.Length];

        for (int i = 1; i < data.Length; i++)
        {
            basiliskPosition[i - 1] = int.Parse(data[i]);
        }

        return basiliskPosition;
    }

    public static char DetermineBasiliskWinner(List<char> allWinningBasiliskNames)
    {
        allWinningBasiliskNames.Sort();
        char winningBasilisk = allWinningBasiliskNames[0];

        return winningBasilisk;
    }
}

// try 1 -awlays somewhere within dimension's length borders
//public static int[] UnitNewPosition(int[] unitStartPosition, int dimension, int offset)
//{
//    int[] newPosition = unitStartPosition;

//    newPosition[dimension] = (newPosition[dimension] + offset) % dimensions[dimension];

//    if (newPosition[dimension] < 0)
//    {
//        newPosition[dimension] += dimensions[dimension];
//    }        

//    return newPosition;
//}
