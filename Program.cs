using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace cockroachRun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var cockroachs = new List<Cockroach> { new Cockroach("Vasya"), new Cockroach("Petya"), new Cockroach("Sanya"), new Cockroach("Vanya") };

            cockroachs.ForEach(x => x.Run());

            //TimerCallback tm = new TimerCallback(PrintDistance);

            Timer timer = new Timer(PrintDistance, cockroachs, 0, 5000);
            Timer timer2 = null;
            timer2 = new Timer((obj) => { Dispose(cockroachs); timer2.Dispose();},null, 30000, Timeout.Infinite);

            Thread.Sleep(31000);
            timer.Dispose();
            PrintWinner(cockroachs);
        }

        static void Dispose(List<Cockroach> cockroachs)
        {
            cockroachs.ForEach(x => x.Stop());
        }

        static void PrintDistance(object o)
        {
            var cockroachs = (List<Cockroach>)o;
            cockroachs.OrderByDescending(x=> x.Distance).ToList().ForEach(x => Console.WriteLine($"{x.Name} - {x.Distance:f1}"));
            Console.SetCursorPosition(0, 0);
        }

        static void PrintWinner(List<Cockroach> cockroachs)
        {
            Console.SetCursorPosition(0, 4);
            Console.WriteLine(new string('-', 30));
            var winer = cockroachs.OrderByDescending(x => x.Distance).First();
            Console.WriteLine($"Winner {winer.Name} - {winer.Distance}");
        }
    }
}
