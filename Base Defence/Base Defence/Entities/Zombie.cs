using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;

namespace Base_Defence.Entities
{
    class Zombie : GameEntity
    {
        public ZombieStage AnimationStage { get; set; }
        int SubAnimationStage { get; set; }

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

        public Zombie(int width, int height)
        {
            Shape = new RectangleShape(new Vector2f(width, height));
            Texture = new Texture(Helpers.GetResource("Assets.Textures.zombie.png"));
        }



        public void AnimationCycle()
        {

        }

    }


    enum ZombieStage
    {
        Walking,
        Attacking,
        Dead
    }

}
