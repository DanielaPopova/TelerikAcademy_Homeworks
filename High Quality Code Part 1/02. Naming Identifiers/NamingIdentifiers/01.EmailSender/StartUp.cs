namespace EmailSender
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Email mail = new Email();
            mail.SendMessage(true);
        }

        public class Email
        {
            // deleted const - never used

            public void SendMessage(bool isSent)
            {
                string operationMessage = isSent.ToString();
                Console.WriteLine(operationMessage);
            }
        }
    }
}
