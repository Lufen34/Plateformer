using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateformer
{
    class GameOverScene : Scene
    {
        protected Vector2 pos;

        public GameOverScene(Main pMain) : base(pMain)
        {
            pos = new Vector2();
        }

        public override void Load()
        {
            base.Load();
            Debug.WriteLine("GameOverScene loaded");
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            main.spriteBatch.DrawString(AssetManager.MainFont, "This is the Game Over", pos, Color.White);;
        }
    }
}
