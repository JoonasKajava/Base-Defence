using SFML.Graphics;
using SFML.Window;

namespace Base_Defence.Entities
{
    class Barricade : GameEntity
    {
        static Texture BarricateFlat = new Texture(Helpers.GetResource("Assets.Textures.BarricadeFlat.png"));
        static Texture BarricateCurved = new Texture(Helpers.GetResource("Assets.Textures.BarricadeCurved.png"));

        public Barricade(int X, int Y, BarricadeType Type)
        {
            Shape = new Sprite()
            {
                Position = new Vector2f(X, Y),
                Origin = Type == BarricadeType.Flat ? new Vector2f(0, 51.5f) : new Vector2f(250.5f, 119),
                Texture = Type == BarricadeType.Flat ? BarricateFlat : BarricateCurved,
                Scale = new Vector2f(0.5f, 0.5f)
            };

            var test = this;

           GameContext.DrawQueue.Add(this);
        }


    }

    enum BarricadeType
    {
        Flat,
        Curved
    }
}
