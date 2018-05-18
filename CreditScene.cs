using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Plateformer
{
    class CreditScene : Scene
    {
        private Button exit;
        private Rectangle screen;

        public CreditScene(Main pMain) : base(pMain)
        {
            screen = main.Window.ClientBounds;
        }

        public override void Load()
        {
            exit = new Button("Exit", Color.White, Color.ForestGreen);
            exit.Pos = new Vector2(screen.Width / 2 - (exit.ButtonName.Length*12) / 2, screen.Height / 1.2f - exit.BoundingBox.Height / 2);
            exit.Onclick = IsOnClickExit;
            listActor.Add(exit);
            base.Load();
        }

        public override void Unload()
        {
            base.Unload();
        }

        public void IsOnClickExit(Button pButton)
        {
            AssetManager.clickedOnMenuButton.Play();
            main.gameState.ChangeScene(GameState.SceneType.Menu);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            main.spriteBatch.DrawString(AssetManager.MainFont, "Programmer :", new Vector2(screen.Width / 2 - ("Programmer :".Length * 12) / 2, 20), Color.White);
            main.spriteBatch.DrawString(AssetManager.textFont, "Van Dorp Thibaut", new Vector2(screen.Width / 2 - ("Van Dorp Thibaut".Length * 12) / 2, 80), Color.White);
            main.spriteBatch.DrawString(AssetManager.MainFont, "Game Artist :", new Vector2(screen.Width / 2 - ("Game Artist :".Length * 12) / 2, 140), Color.White);
            main.spriteBatch.DrawString(AssetManager.textFont, "Zhou He", new Vector2(screen.Width / 2 - ("Zhou He".Length * 12) / 2, 200), Color.White);
            main.spriteBatch.DrawString(AssetManager.textFont, "Thanks for testing our game. This is our first \n\nproject that we share and also the" +
                " first one \n\nthat we actually worked on together.\n\nI hope you will enjoy it. Feel free to contact\n\nme at some@email.com", new Vector2(screen.Width - (screen.Width -20) , 300), Color.White);
            base.Draw(gameTime);
        }
    }
}
