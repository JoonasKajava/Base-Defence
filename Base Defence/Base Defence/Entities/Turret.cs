using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Base_Defence.Entities
{
    class Turret : GameEntity
    {
        static Texture TurretTexture = new Texture(Helpers.GetResource("Assets.Textures.turret.png"));
        static Sound ShootingSound = new Sound(new SoundBuffer(Helpers.GetResource("Assets.Sounds.cannon.wav")));

        List<Bullet> Bullets = new List<Bullet>();
        Stopwatch ShotLimiter = new Stopwatch();

        int TimeBetweenShots = 600;

        public Turret(int X, int Y)
        {
            DrawPriority = 5;
            ShotLimiter.Start();
            Shape = new Sprite()
            {
                Position = new Vector2f(X, Y),
                Origin = new Vector2f(64, 64)
            };

            GameContext.DrawQueue.Add(this);
            Shape.Texture = TurretTexture;

            GameContext.Window.MouseMoved += new EventHandler<MouseMoveEventArgs>(Rotate);
            GameContext.Window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(Shoot);

        }

        public void Rotate(object sender, MouseMoveEventArgs e)
        {
            Shape.Rotation = (float)(Math.Atan2(e.Y - Shape.Position.Y, e.X - Shape.Position.X) * 180 / 3.14159265359 + 90);
        }

        public void Shoot(object sender, MouseButtonEventArgs e)
        {
            if(ShotLimiter.ElapsedMilliseconds > TimeBetweenShots)
            {
                new Bullet(Shape.Position.X, Shape.Position.Y, Shape.Rotation);
                ShootingSound.Play();
                ShotLimiter.Restart();
            }

            
        }
    }
}
