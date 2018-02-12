using Base_Defence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Base_Defence
{
    class Spawner
    {
        public Timer Timer;
        static Random rnd = new Random();

        public Spawner(int Interval)
        {
            Timer = new Timer(Interval);
            Timer.Elapsed += SpawnEnemy;
            Timer.Start();
        }

        public void SpawnEnemy(object sender, ElapsedEventArgs e)
        {
            int X = rnd.Next(0, (int)GameContext.Window.Size.X);
            int Y = rnd.Next(-40, -20);
            GameContext.DrawQueue.Add(new Zombie(X, Y));
        }
    }
}
