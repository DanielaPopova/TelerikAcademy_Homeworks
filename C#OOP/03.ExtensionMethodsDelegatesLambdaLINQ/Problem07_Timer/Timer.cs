namespace Problem7_Timer
{
    using System;
    using System.Threading;

    public delegate void TimerDelegate(int ticks);

    public class Timer
    {
        private int ticksCount;
        private int interval;
        private TimerDelegate callDelegate;

        public Timer(int ticksCount, int interval, TimerDelegate callDelegate)
        {
            this.TicksCount = ticksCount;
            this.Interval = interval;
            this.callDelegate = callDelegate;
        }

        public int TicksCount
        {
            get
            { 
                return this.ticksCount;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Enter at least 1 tick");
                }

                this.ticksCount = value;
            }
        }

        public int Interval
        {
            get 
            { 
                return this.interval; 
            }

            private set
            {
                if (value < 1000)
                {
                    throw new ArgumentException("Interval is in milliseconds - 1 sec = 1000 ms");
                }

                this.interval = value;
            }
        }

        public void Run()
        {
            int ticks = this.TicksCount;
            while (ticks > 0)
            {
                Thread.Sleep(this.interval);
                ticks--;
                this.callDelegate(ticks);
            }
        }
    }
}
