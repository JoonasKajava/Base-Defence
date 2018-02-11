using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Defence
{
    class Program
    {
        static void Main(string[] args)
        {

            GameContext.RegisterEvents();



            while(GameContext.Window.IsOpen())
            {
                GameContext.Window.DispatchEvents();
                GameContext.Window.Clear();

                GameContext.Window.Draw(GameContext.Environment);


                GameContext.DrawQueue.ForEach(x => GameContext.Window.Draw(x));

                GameContext.Window.Display();
            }


        }
    }
}
