// 70/100 timelimit/memory
using System;
using System.Collections.Generic;
using System.Linq;

class Cards
{
    static string[] cards = {"2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "Tc", "Jc", "Qc", "Kc", "Ac",
                          "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "Td", "Jd", "Qd", "Kd", "Ad",
                          "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "Th", "Jh", "Qh", "Kh", "Ah",
                          "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "Ts", "Js", "Qs", "Ks", "As"};

    static void Main()
    {
        int hands = int.Parse(Console.ReadLine());       

        var cardsFromAllHands = new List<string>();

        for (int i = 0; i < hands; i++)
        {
            long currHand = long.Parse(Console.ReadLine());
            //string binary = Convert.ToString(currHand, 2);

            for (int j = 0; j < 52; j++)
            {
                long set = currHand & 1;
                if (set == 1)
                {                    
                    cardsFromAllHands.Add(cards[j]);
                }

                currHand >>= 1;
            }
        }
       
        string[] fullDeck = new string[cards.Length];

        for (int i = 0; i < cards.Length; i++)
        {
            string card = cards[i];

            if (cardsFromAllHands.Contains(card))
            {
                fullDeck[i] = card;
            }
        }        

        if (!fullDeck.Contains(null))
        {
            Console.WriteLine("Full deck");
        }
        else
        {
            Console.WriteLine("Wa wa!");
        }

        Console.WriteLine(String.Join(" ", OddOccurances(cardsFromAllHands)));
    }

    public static List<string> OddOccurances(List<string> cardsFromAllHands)
    {
        string[] allCards = new string[52];

        for (int i = 0; i < cards.Length; i++)
        {
            string currCard = cards[i];
            int countMatch = 0;

            if (cardsFromAllHands.Contains(currCard))
            {
                for (int j = 0; j < cardsFromAllHands.Count; j++)
                {
                    if (currCard == cardsFromAllHands[j])
                    {
                        countMatch++;
                    }
                }

                if (countMatch % 2 == 1)
                {
                    allCards[i] = currCard;
                }
            }           
        }

        var oddOccurances = new List<string>(allCards);

        oddOccurances.RemoveAll(s => s == null);        

        return oddOccurances;
    }

}