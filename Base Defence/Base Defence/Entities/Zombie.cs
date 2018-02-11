using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Base_Defence.Entities
{
    class Zombie : GameEntity
    {
        public ZombieStage AnimationStage = ZombieStage.Walking;
        int SubAnimationStage = 0;
        public float Speed = 0.03f;
        static Texture ZombieTexture = new Texture(Helpers.GetResource("Assets.Textures.zombie.png"));

        static Dictionary<KeyValuePair<ZombieStage, int>, IntRect> AnimationRects = new Dictionary<KeyValuePair<ZombieStage, int>, IntRect>()
        {
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Walking, 0), new IntRect(512, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Walking, 1), new IntRect(640, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Walking, 2), new IntRect(768, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Walking, 3), new IntRect(896, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Walking, 4), new IntRect(1024, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Walking, 5), new IntRect(1152, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Walking, 6), new IntRect(1280, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Walking, 7), new IntRect(1408, 896, 128, 128)},

            {new KeyValuePair<ZombieStage, int>(ZombieStage.Attacking, 0), new IntRect(1536, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Attacking, 1), new IntRect(1664, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Attacking, 2), new IntRect(1792, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Attacking, 3), new IntRect(1920, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Attacking, 4), new IntRect(2048, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Attacking, 5), new IntRect(2048, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Attacking, 6), new IntRect(2048, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Attacking, 7), new IntRect(2304, 896, 128, 128)},

            {new KeyValuePair<ZombieStage, int>(ZombieStage.Dead, 0), new IntRect(3584, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Dead, 1), new IntRect(3712, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Dead, 2), new IntRect(3840, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Dead, 3), new IntRect(3968, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Dead, 4), new IntRect(4096, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Dead, 5), new IntRect(4224, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Dead, 6), new IntRect(4352, 896, 128, 128)},
            {new KeyValuePair<ZombieStage, int>(ZombieStage.Dead, 7), new IntRect(4480, 896, 128, 128)},
        };

        public Zombie(int X, int Y)
        {
            HealthPoints = 100;
            Shape = new Sprite()
            {
                Position = new Vector2f(X, Y),
                Origin = new Vector2f(64, 64)
            };

            GameContext.DrawQueue.Add(this);
            GameContext.ZombieAnimator.AttactEvent(DoAnimationCycle);
            Shape.Texture = ZombieTexture;
            Shape.TextureRect = AnimationRects[new KeyValuePair<ZombieStage, int>(AnimationStage, SubAnimationStage)];
        }

        public void DoAnimationCycle(object sender, ElapsedEventArgs e)
        {
            if (!Alive) AnimationStage = ZombieStage.Dead;
            Shape.TextureRect = AnimationRects[new KeyValuePair<ZombieStage, int>(AnimationStage, SubAnimationStage)];
            if( SubAnimationStage < 7) SubAnimationStage++;
            if (SubAnimationStage >= 7 && Alive) SubAnimationStage = 0;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            if (Alive)
            {
                var ZombiePosition = Shape.GetGlobalBounds();
                ZombiePosition.Top -= 35;
                if (GameContext.Environment.Barricades.Any(x => x.Shape.GetGlobalBounds().Intersects(ZombiePosition)))
                {
                    AnimationStage = ZombieStage.Attacking;
                }
                else
                {
                    Shape.Position = new Vector2f(Shape.Position.X, Shape.Position.Y + (float)GameContext.DeltaTime * Speed);
                }
            }

            base.Draw(target, states);
        }

    }


    enum ZombieStage
    {
        Walking,
        Attacking,
        Dead
    }

}
