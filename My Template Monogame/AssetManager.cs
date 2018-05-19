using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateformer
{
    class AssetManager
    {
        public static SpriteFont MainFont;
        public static SpriteFont textFont;
        public static SoundEffect onButton;
        public static SoundEffect clickedOnMenuButton;

        public static void Load(ContentManager pContent)
        {
            MainFont = pContent.Load<SpriteFont>("mainfont");
            textFont = pContent.Load<SpriteFont>("texte");
            onButton = pContent.Load<SoundEffect>("MouseOver");
            clickedOnMenuButton = pContent.Load<SoundEffect>("click");
        }
    }
}
