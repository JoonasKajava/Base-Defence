using SFML.Graphics;
using SFML.Window;
using System;

namespace Base_Defence.Entities
{
    class Bullet : GameEntity
    {
        static Texture BulletTexture = new Texture(Helpers.GetResource("Assets.Textures.bullet.png"));

        float Speed = 5f;

        public Bullet(float X, float Y, float Angle)
        {
            Shape = new Sprite()
            {
                Position = new Vector2f(X, Y),
                Origin = new Vector2f(16, 16),
                Rotation = Angle
            };

            GameContext.DrawQueue.Add(this);
            Shape.Texture = BulletTexture;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            if ((Shape.Position.X > GameContext.Window.Size.X || Shape.Position.Y > GameContext.Window.Size.Y) || (Shape.Position.X < 0 || Shape.Position.Y < 0))
            {
                GameContext.DrawQueue.Remove(this);
            }else
            {
                double Rads = (3.1415926536 / 180) * (Shape.Rotation - 90);
                Shape.Position = new Vector2f((float)( (Speed * GameContext.DeltaTime) * Math.Cos(Rads) + Shape.Position.X), (float)((Speed * GameContext.DeltaTime) * Math.Sin(Rads) + Shape.Position.Y));
            }

            

            base.Draw(target, states);
        }

    }
}
