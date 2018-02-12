using SFML.Graphics;
using SFML.Window;
using System;
using System.Linq;

namespace Base_Defence.Entities
{
    class Bullet : GameEntity
    {
        static Texture BulletTexture = new Texture(Helpers.GetResource("Assets.Textures.bullet.png"));

        float Speed = 5f;

        public Bullet(float X, float Y, float Angle) : base()
        {
            GameLogicTimer.Interval = 5;
            Shape = new Sprite()
            {
                Position = new Vector2f(X, Y),
                Origin = new Vector2f(16, 16),
                Rotation = Angle
            };

            GameContext.DrawQueue.Add(this);
            Shape.Texture = BulletTexture;
        }

        public override void OnEveryTick()
        {
            var Zombie = GameContext.DrawQueue?.ToList()?.OfType<Zombie>()?.ToList()?.Find(x => x.Shape.GetGlobalBounds().Intersects(Shape.GetGlobalBounds()) && x.Alive);

            if (Zombie != null)
            {
                Zombie.HealthPoints -= 50;
                GameContext.DrawQueue.Remove(this);
                GameLogicTimer.Stop();
            }


            if ((Shape.Position.X > GameContext.Window.Size.X || Shape.Position.Y > GameContext.Window.Size.Y) || (Shape.Position.X < 0 || Shape.Position.Y < 0))
            {
                GameContext.DrawQueue.Remove(this);
                GameLogicTimer.Stop();
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            double Rads = (3.1415926536 / 180) * (Shape.Rotation - 90);
            Shape.Position = new Vector2f((float)((Speed * GameContext.DeltaTime) * Math.Cos(Rads) + Shape.Position.X), (float)((Speed * GameContext.DeltaTime) * Math.Sin(Rads) + Shape.Position.Y));

            base.Draw(target, states);
        }

    }
}
