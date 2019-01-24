using System;
using System.Threading;

namespace cockroachRun
{
    class Cockroach
    {
        public string Name { get; private set; }
        public double Distance { get; set; }
        private TimerCallback tm { get; set; }
        private static Random rnd = new Random(DateTime.Now.Millisecond);
        private Timer Timer { get; set; }
        public Cockroach(string name)
        {
            
            Name = name;
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
            Distance += (double)(rnd.Next(1, 10)) / 10; 
        }
    }
}
