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

            while (GameContext.Window.IsOpen())
            {
                GameContext.Window.DispatchEvents();
                GameContext.DeltaTime = deltatimer.ElapsedMilliseconds;
                deltatimer.Restart();


                GameContext.Window.Clear();
                if (!GameContext.GameOver)
                {

                    GameContext.Window.Draw(GameContext.Environment);

                    GameContext.DrawQueue?.OrderBy(x => (x as GameEntity)?.DrawPriority ?? 5)?.ToList()?.ForEach(x => GameContext.Window.Draw(x));
                }else
                {
                    GameContext.Window.Draw(GameContext.Environment.GameOverText);
                }
                GameContext.Window.Draw(Environment.Score);
                GameContext.Window.Draw(Environment.Health);
                //GameContext.Window.Draw(GameContext.Environment.Health);

                GameContext.Window.Display();
            }


        }
    }
}
