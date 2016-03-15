/*
A bank account has a holder name (first name, middle name and last name), available amount of money (balance),
bank name, IBAN, 3 credit card numbers associated with the account.
Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.
*/

using System;

class BankAccountData
{
    static void Main()
    {
        string holderName = "Dimityr Ivanov Petrov";
        int balance = 240;
        string bankName = "UniCredit Bulbank";
        string iban = "BG38UNCR96601051876629";
        string creditCard1 = "7880 8899 5462 4535";
        string creditCard2 = "7890 8766 3469 4589";
        string creditCard3 = "7860 8755 5541 4500";

        Console.WriteLine("{0} has {1}lv. in {2} with IBAN: {3}.\nHis credit cards numbers are respectively:\n{4}\n{5}\n{6}",
                            holderName, balance, bankName, iban, creditCard1, creditCard2, creditCard3);
    }
}

