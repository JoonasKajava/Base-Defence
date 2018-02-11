using Base_Defence.Entities;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Defence
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContext.Window.SetVerticalSyncEnabled(true);

            GameContext.RegisterEvents();

            Stopwatch deltatimer = new Stopwatch();
            deltatimer.Start();

            while(GameContext.Window.IsOpen())
            {
                GameContext.DeltaTime = deltatimer.ElapsedMilliseconds;
                deltatimer.Restart();

                GameContext.Window.DispatchEvents();
                GameContext.Window.Clear();

                GameContext.Window.Draw(GameContext.Environment);
                

                GameContext.DrawQueue.ToList()?.ForEach(x => GameContext.Window.Draw(x));

                GameContext.Window.Display();
            }


        }
    }
}
