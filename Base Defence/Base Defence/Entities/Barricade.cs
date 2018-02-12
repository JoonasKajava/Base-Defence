﻿using SFML.Graphics;
using SFML.Window;
using System.Linq;

namespace Base_Defence.Entities
{
    class Barricade : GameEntity
    {
        static Texture BarricateFlat = new Texture(Helpers.GetResource("Assets.Textures.BarricadeFlat.png"));
        static Texture BarricateCurved = new Texture(Helpers.GetResource("Assets.Textures.BarricadeCurved.png"));

        public Barricade(int X, int Y, BarricadeType Type, int? Health = null) : base()
        {
            DrawPriority = 2;
            HealthPoints = Health ?? 100;

            Shape = new Sprite()
            {
                Position = new Vector2f(X, Y),
                Origin = Type == BarricadeType.Flat ? new Vector2f(0, 51.5f) : new Vector2f(250.5f, 119),
                Texture = Type == BarricadeType.Flat ? BarricateFlat : BarricateCurved,
                Scale = new Vector2f(0.5f, 0.5f)
            };

            GameContext.DrawQueue.Add(this);
        }

        public override void OnEveryTick()
        {
            if (!Alive)
            {

                GameContext.DrawQueue.Remove(this);
                GameContext.Environment.Barricades.Remove(this);
            }
        }

    }

    enum BarricadeType
    {
        Flat,
        Curved
    }
}
