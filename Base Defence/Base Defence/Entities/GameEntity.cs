using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Defence.Entities
{
    abstract class GameEntity : Drawable
    {
        public Shape Shape { get; set; }

        public Texture Texture { get; set; }

        public int HealthPoints { get; set; }
        public bool Alive => HealthPoints > 0;

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Shape);
        }
    }
}
