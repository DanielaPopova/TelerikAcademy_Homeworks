namespace MobilePhone
{
    using System;

    public class GSMTest
    {
        private GSM[] phones = { 
                new GSM("Galaxy S7", "Samsung", 1000.0M, new Battery("Unknown", BatteryType.LiIon, 128, 48), new Display(5.1, 16000000)),
                new GSM("Vibe X3", "Lenovo", 800.0M, new Battery("Unknown", BatteryType.LiIon, 72, 24), new Display(5.5, 16000000)),
                new GSM("One A9", "HTC", 600.0M, new Battery("Unknown", BatteryType.LiIon, 36, 12), new Display(5.0, 16000000))
                       };

        public void DisplayInfo()
        {
            foreach (var phone in phones)
            {
                Console.WriteLine(phone + "\n");
            }
        }

        public void DisplayInfoIPhone()
        {
            Console.WriteLine(GSM.iPhone6s);  
        }        

        //test, if uncomment -> comment Main() in GSMCallHistoryTest.cs
        //static void Main()
        //{
            //GSMTest gsm = new GSMTest();
            //gsm.DisplayInfo();
            //gsm.DisplayInfoIPhone();            
        //}
    }
}
