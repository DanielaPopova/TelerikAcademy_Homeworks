namespace Problem7_Timer
{
    using System;
    using System.Threading;

    public class StartUp
    {
        public static void Main()
        {
            TimerDelegate timerDelegate = new TimerDelegate(Print);

            Timer timer = new Timer(5, 1000, timerDelegate);
            Thread separateProcess = new Thread(new ThreadStart(timer.Run));
            separateProcess.Start();
        }

        public static void Print(int ticks)
        {
            Console.WriteLine("Hello (will print another {0} times)!", ticks);
        }
    }
}
