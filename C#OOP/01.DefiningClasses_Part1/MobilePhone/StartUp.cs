namespace MobilePhone
{
    using System;
    using System.Collections.Generic;

    using MobilePhone.Classes;
    using MobilePhone.Enums;

    public class StartUp
    {
        public static void Main()
        {
            // GSM TEST
            GSM[] phones =
                        { 
                new GSM("Galaxy S7", "Samsung", 1000.0M, "Ivan Peshev", new Display(5.1, 16000000), new Battery("Unknown", BatteryType.LiIon, 128, 48)),
                new GSM("Vibe X3", "Lenovo", 800.0M, "Maria Lalova", new Display(5.5, 16000000), new Battery("Unknown", BatteryType.LiIon, 72, 24)),
                new GSM("One A9", "HTC", 600.0M, "Stoian Kirov", new Display(5.0, 16000000), new Battery("Unknown", BatteryType.LiIon, 36, 12))
                       };

            foreach (var phone in phones)
            {
                Console.WriteLine(phone.DisplayInfo());
            }
           
            // display iPhone info
            Console.WriteLine(GSM.IPhoneS6.DisplayInfo());

            // CALL HISTORY TEST
            decimal pricePerMinute = 0.37M;
            GSM phoneSamsung = new GSM("Galaxy S7", "Samsung", 1000.0M, "Ivan Peshev", new Display(5.1, 16000000), new Battery("Unknown", BatteryType.LiIon, 128, 48));

            phoneSamsung.AddCall(new Call(new DateTime(2016, 6, 8, 15, 45, 24), "0894 456 123", 56));
            phoneSamsung.AddCall(new Call(new DateTime(2016, 6, 8, 6, 30, 18), "0887 004 478", 180));
            phoneSamsung.AddCall(new Call(new DateTime(2016, 6, 9, 18, 14, 11), "0886 746 167", 456));
            phoneSamsung.AddCall(new Call(new DateTime(2016, 6, 7, 8, 10, 41), "0895 557 230", 546));
            phoneSamsung.AddCall(new Call(new DateTime(2016, 6, 7, 15, 28, 35), "0896 994 555", 1018));

            phoneSamsung.PrintCallHistory();

            Console.WriteLine("Total price: {0:F2} BGN", phoneSamsung.CalculateCallPrice(pricePerMinute));

            Call longestCall = phoneSamsung.CallHistory[0];

            foreach (var call in phoneSamsung.CallHistory)
            {
                if (call.Duration > longestCall.Duration)
                {
                    longestCall = call;
                }
            }

            Console.WriteLine("The longest call is: \n{0}", longestCall.ToString());

            phoneSamsung.DeleteCall(longestCall);

            // without longest call
            phoneSamsung.PrintCallHistory();

            Console.WriteLine("New total price: {0:F2} BGN", phoneSamsung.CalculateCallPrice(pricePerMinute));

            phoneSamsung.ClearHistory();
            phoneSamsung.PrintCallHistory();
        }
    }
}
