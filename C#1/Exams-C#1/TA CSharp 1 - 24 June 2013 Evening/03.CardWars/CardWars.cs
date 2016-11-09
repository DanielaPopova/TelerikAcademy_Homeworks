using System;
using System.Numerics;

class CardWars
{
    static void Main(string[] args)
    {
        int games = int.Parse(Console.ReadLine());

        BigInteger player1TotalScore = 0;
        BigInteger player2TotalScore = 0;

        int countPlayer1 = 0;
        int countPlayer2 = 0;

        for (int i = 0; i < games; i++)
        {
            BigInteger player1Score = 0;
            BigInteger player2Score = 0;

            bool player1X = false;
            bool player2X = false;
           
            for (int j = 0; j < 3; j++)
            {
                string card = Console.ReadLine();

                switch (card)
                {
                    case "A": player1Score += 1; break;
                    case "J": player1Score += 11; break;
                    case "Q": player1Score += 12; break;
                    case "K": player1Score += 13; break;
                    case "Z": player1TotalScore *= 2; break;
                    case "Y": player1TotalScore -= 200; break;
                    case "X": player1X = true; break;
                    default: player1Score += 12 - int.Parse(card); break;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                string card = Console.ReadLine();

                switch (card)
                {
                    case "A": player2Score += 1; break;
                    case "J": player2Score += 11; break;
                    case "Q": player2Score += 12; break;
                    case "K": player2Score += 13; break;
                    case "Z": player2TotalScore *= 2; break;
                    case "Y": player2TotalScore -= 200; break;
                    case "X": player2X = true; break;
                    default: player2Score += 12 - int.Parse(card); break;
                }
            }

            if (player1X && player2X)
            {
                player1TotalScore += 50;
                player2TotalScore += 50;
            }

            if (player1X && !player2X)
            {                
                Console.WriteLine("X card drawn! Player one wins the match!");
                return;
            }

            if (player2X && !player1X)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                return;
            }

            if (player1Score > player2Score)
            {                
                countPlayer1++;
                player1TotalScore += player1Score;
            }
            else if (player1Score < player2Score)
            {               
                countPlayer2++;
                player2TotalScore += player2Score;
            }            
        }

        if (player1TotalScore > player2TotalScore)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", player1TotalScore);
            Console.WriteLine("Games won: {0}", countPlayer1);
        }
        else if (player1TotalScore < player2TotalScore)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", player2TotalScore);
            Console.WriteLine("Games won: {0}", countPlayer2);
        }
        else
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", player1TotalScore);
        }       
    }
}

