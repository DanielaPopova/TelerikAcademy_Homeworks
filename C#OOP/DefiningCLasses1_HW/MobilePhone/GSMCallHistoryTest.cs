namespace MobilePhone
{
    using System;
    using System.Collections.Generic;

    public class GSMCallHistoryTest
    {
        static void Main()
        {
            decimal pricePerMinute = 0.37M;
            GSM phone = new GSM("Galaxy S7", "Samsung", 1000.0M, new Battery("Unknown", BatteryType.LiIon, 128, 48), new Display(5.1, 16000000));

            phone.AddCall(new Call(new DateTime(2016, 6, 8, 15, 45, 24), "0894 456 123", 56));
            phone.AddCall(new Call(new DateTime(2016, 6, 8, 6, 30, 18), "0887 004 478", 180));
            phone.AddCall(new Call(new DateTime(2016, 6, 9, 18, 14, 11), "0886 746 167", 456));
            phone.AddCall(new Call(new DateTime(2016, 6, 7, 8, 10, 41), "0895 557 230", 546));
            phone.AddCall(new Call(new DateTime(2016, 6, 7, 15, 28, 35), "0896 994 555", 1018));

            phone.PrintCallHistory();

            Console.WriteLine("Total price: {0:F2} BGN", phone.CalculateCallPrice(pricePerMinute));

            Call longestCall = phone.CallHistory[0];

            foreach (var call in phone.CallHistory)
            {
                if (call.Duration > longestCall.Duration)
                {
                    longestCall = call;
                }
            }
            Console.WriteLine("The longest call is: \n{0}", longestCall.ToString());

            phone.DeleteCall(longestCall);

            //without longest call
            phone.PrintCallHistory();
            
            Console.WriteLine("New total price: {0:F2} BGN", phone.CalculateCallPrice(pricePerMinute));

            phone.ClearHistory();
            phone.PrintCallHistory();
        }
    }
}
