using System;
using System.Numerics;

class TwoGirlsOnePath
{
    static void Main()
    {      
        string[] field = Console.ReadLine().Split(' ');
        long[] fieldNumbers = Array.ConvertAll(field, s => long.Parse(s));
      
        int mollyPosition = 0;
        int dollyPosition = fieldNumbers.Length - 1;

        BigInteger mollyFlowers = 0;
        BigInteger dollyFlowers = 0;

        string endGame = string.Empty;

        while (true)
        {
            if (fieldNumbers[mollyPosition] == 0 || fieldNumbers[dollyPosition] == 0)
            {
                if (fieldNumbers[mollyPosition] == 0 && fieldNumbers[dollyPosition] == 0)
                {
                    endGame = "Draw";
                }
                else if (fieldNumbers[mollyPosition] == 0)
                {
                    endGame = "Dolly";
                }
                else if (fieldNumbers[dollyPosition] == 0)
                {
                    endGame = "Molly";
                }

                mollyFlowers += fieldNumbers[mollyPosition];
                dollyFlowers += fieldNumbers[dollyPosition];
                break;
            }                  

            BigInteger currFlowersMolly = fieldNumbers[mollyPosition];
            BigInteger currFlowersDolly = fieldNumbers[dollyPosition];

            if (mollyPosition == dollyPosition)
            {
                if (currFlowersMolly % 2 == 0)
                {
                    fieldNumbers[mollyPosition] = 0;                    
                }
                else
                {
                    fieldNumbers[mollyPosition] = 1;
                }

                mollyFlowers += currFlowersMolly / 2;
                dollyFlowers += currFlowersDolly / 2;
            }
            else
            {
                fieldNumbers[mollyPosition] = 0;
                fieldNumbers[dollyPosition] = 0;

                mollyFlowers += currFlowersMolly;
                dollyFlowers += currFlowersDolly;
            }           

            mollyPosition = (int)((mollyPosition + currFlowersMolly) % fieldNumbers.Length);
            dollyPosition = (int)((dollyPosition - currFlowersDolly) % fieldNumbers.Length);
            if (dollyPosition < 0)
            {
                dollyPosition += fieldNumbers.Length;
            }            
        }

        Console.WriteLine(endGame);
        Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
    }
}

