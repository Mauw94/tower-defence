using System;
using System.Threading;
using towerdef.Main;

namespace towerdef.game.logging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new(Callback, "Something", TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

            // Thread.Sleep(2000);

            Console.ReadLine();
        }

        private static void Callback(object state)
        {
            Console.WriteLine(TowerDefence.GetMessage());
        }
    }
}
