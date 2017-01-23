using System;
using System.Diagnostics;
using System.Threading;

namespace ZY.FBG.Engine.demos
{
    public class TimerDemo
    {
        public static readonly TimerDemo Instance = new TimerDemo();
        public DateTime Time { get; private set; }
        private static object lockObject;
        private TimerDemo()
        {
            Time = new DateTime(0, DateTimeKind.Local);
            lockObject = new object();
        }

        public void Run()
        {
            lock (lockObject)
            {
                Time.AddSeconds(1);
                var time = Time.ToShortTimeString();
            }
        }
    }
}
