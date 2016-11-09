using System;

class CoffeeMachine
{
    static void Main()
    {
        long coinsFirstTray = long.Parse(Console.ReadLine());
        long coinsSecondTray = long.Parse(Console.ReadLine());
        long coinsThirdTray = long.Parse(Console.ReadLine());
        long coinsFourthTray = long.Parse(Console.ReadLine());
        long coinsFifthTray = long.Parse(Console.ReadLine());

        decimal money = decimal.Parse(Console.ReadLine());
        decimal price = decimal.Parse(Console.ReadLine());

        decimal moneyInMachine = coinsFirstTray * 0.05M + coinsSecondTray * 0.10M + coinsThirdTray * 0.20M + coinsFourthTray * 0.50M + coinsFifthTray * 1.0M;
        
        if (price > money)
        {
            decimal additionalMoney = price - money;
            Console.WriteLine("More {0:F2}", additionalMoney);
        }
        else if (price <= money)
        {
            decimal change = money - price;         

            if (change <= moneyInMachine)
            {
                Console.WriteLine("Yes {0}", (moneyInMachine - change).ToString("F2"));
            }
            else
            {
                Console.WriteLine("No {0}", (change - moneyInMachine).ToString("F2"));
            }            
        }
    }
}

