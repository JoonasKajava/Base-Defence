using Base_Defence.Entities;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Defence
{
    class Environment : GameEntity
    {
        Texture BackgroundTexture;

        public Sprite Background;


        public Music BackgroundMusic = new Music(Helpers.GetResource("Assets.Sounds.background.wav"));

        public List<Barricade> Barricades = new List<Barricade>();

        public static List<Turret> Turrets = new List<Turret>() {
             new Turret(300, 500)
        };


        public static Text Score = new Text("Score: " + GameContext.Score, new Font(Helpers.GetResource("Assets.Fonts.Oswald.ttf")));
        public static Text Health = new Text("Health: " + GameContext.Health, new Font(Helpers.GetResource("Assets.Fonts.Oswald.ttf")))
        {
            Position = new Vector2f(0, 30)
        };

        public Text GameOverText = new Text("Game Over \nScore: ", new Font(Helpers.GetResource("Assets.Fonts.Oswald.ttf"))) {
            CharacterSize = 72,
            Position = new Vector2f(300, 300)
        };

        public Environment()
        {

            BackgroundTexture = new Texture(Helpers.GetResource("Assets.Textures.DefaultBackground.png"));
            Init();

        }
        public Environment(Texture _background) : base()
        {
            BackgroundTexture = _background;
            Init();
        }

        protected void Init()
        {
            // First line
            Barricades.Add(new Barricade(0, 100, BarricadeType.Flat));
            Barricades.Add(new Barricade(100, 100, BarricadeType.Flat));
            Barricades.Add(new Barricade(200, 100, BarricadeType.Flat));
            Barricades.Add(new Barricade(300, 100, BarricadeType.Flat));
            Barricades.Add(new Barricade(400, 100, BarricadeType.Flat));
            Barricades.Add(new Barricade(500, 100, BarricadeType.Flat));

            // Second line
            Barricades.Add(new Barricade(0, 250, BarricadeType.Flat));
            Barricades.Add(new Barricade(100, 250, BarricadeType.Flat));
            Barricades.Add(new Barricade(200, 250, BarricadeType.Flat));
            Barricades.Add(new Barricade(300, 250, BarricadeType.Flat));
            Barricades.Add(new Barricade(400, 250, BarricadeType.Flat));
            Barricades.Add(new Barricade(500, 250, BarricadeType.Flat));

            // Third line
            Barricades.Add(new Barricade(0, 400, BarricadeType.Flat));
            Barricades.Add(new Barricade(100, 400, BarricadeType.Flat));
            Barricades.Add(new Barricade(200, 400, BarricadeType.Flat));
            Barricades.Add(new Barricade(300, 400, BarricadeType.Flat));
            Barricades.Add(new Barricade(400, 400, BarricadeType.Flat));
            Barricades.Add(new Barricade(500, 400, BarricadeType.Flat));



            // Main Barricade
            Barricades.Add(new Barricade(0, 550, BarricadeType.Flat));
            Barricades.Add(new Barricade(100, 550, BarricadeType.Flat));
            Barricades.Add(new Barricade(400, 550, BarricadeType.Flat));
            Barricades.Add(new Barricade(500, 550, BarricadeType.Flat));
            Barricades.Add(new Barricade(300, 550, BarricadeType.Curved));


            Background = new Sprite(BackgroundTexture);

            GameOverText.Origin = new Vector2f(GameOverText.GetGlobalBounds().Width / 2, GameOverText.GetGlobalBounds().Height / 2);

            // Background Music Control
            BackgroundMusic.Loop = true;
            BackgroundMusic.Play();

        }

        public static void OnScoreChange()
        {
            lock(Score)
            {
                Score.DisplayedString = "Score: " + GameContext.Score;
            }
            
            if (GameContext.Score >= 350 && Turrets.Count < 2)
            {
                Turrets.Add(new Turret(250, 500));
            }
            if (GameContext.Score >= 700 && Turrets.Count < 3)
            {
                Turrets.Add(new Turret(350, 500));
            }
        }

        public override void OnEveryTick()
        {
            lock(Health)
            {
                Health.DisplayedString = "Health: " + GameContext.Health;
            }
            
            if (GameContext.Health <= 0)
            {
                Turrets.ForEach(x => x.HealthPoints = -1);
                GameContext.GameOver = true;
                GameOverText.DisplayedString += GameContext.Score.ToString();
                GameContext.ZombieSpawner.Timer.Stop();
                GameLogicTimer.Stop();
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Background);
        }
    }
}
