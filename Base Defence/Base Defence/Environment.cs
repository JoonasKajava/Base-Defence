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
    class Environment : Drawable
    {
        Texture BackgroundTexture;

        public Sprite Background;


        public Music BackgroundMusic = new Music(Helpers.GetResource("Assets.Sounds.background.wav"));

        public Environment()
        { 

            BackgroundTexture = new Texture(Helpers.GetResource("Assets.Textures.DefaultBackground.png"));
            Init();
            
        }
        public Environment(Texture _background)
        {
            BackgroundTexture = _background;
            Init();
        }

        protected void Init()
        {
            Background = new Sprite(BackgroundTexture);

            // Background Music Control
            BackgroundMusic.Loop = true;
            BackgroundMusic.Play();

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Background);
        }
    }
}
