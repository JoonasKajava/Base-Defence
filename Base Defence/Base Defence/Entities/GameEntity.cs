using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Base_Defence.Entities
{
    abstract class GameEntity : Drawable
    {
        public Sprite Shape { get; set; }

        public int HealthPoints { get; set; }
        public bool Alive => HealthPoints > 0;

        public Timer GameLogicTimer = new Timer(50);

        protected GameEntity()
        {
            GameLogicTimer.Start();
            GameLogicTimer.Elapsed += new ElapsedEventHandler(_OnEveryTick);
        }

        private void _OnEveryTick(object sender, ElapsedEventArgs e) => OnEveryTick();

        public virtual void OnEveryTick()
        {

        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Shape);
        }
    }
}
