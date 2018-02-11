

using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace Base_Defence
{
    static class GameContext
    {
        public static RenderWindow Window = new RenderWindow(new VideoMode(600, 600), "Base Defence");

        public static Environment Environment = new Environment();

        public static bool GameOver = false;

        public static List<Drawable> DrawQueue = new List<Drawable>();

        public static void OnClose(object sender, EventArgs e)
        {
            (sender as RenderWindow).Close();
        }



        public static void RegisterEvents()
        {
            Window.Closed += new EventHandler(OnClose);
        }
    }
}
