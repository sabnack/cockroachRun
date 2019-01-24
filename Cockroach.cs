using System;
using System.Threading;

namespace cockroachRun
{
    class Cockroach
    {
        public string Name { get; private set; }
        private double Speed { get; set; }
        public double Distance { get; set; }
        private TimerCallback tm { get; set; }
        private static Random rnd = new Random();
        private Timer Timer { get; set; }
        public Cockroach(string name)
        {
            
            Name = name;
            Speed = (double)(rnd.Next(1, 10)) / 10;
            tm = new TimerCallback(DistanceCalculation);
        }

        public void Run()
        {
            Timer = new Timer(tm, null, 50, 1000);
        }

        public void Stop()
        {
            Timer.Dispose();
        }

        private void DistanceCalculation(object obj)
        {
            Distance += Speed;
        }
    }
}
