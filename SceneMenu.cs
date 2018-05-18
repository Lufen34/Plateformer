using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Plateformer
{
    class SceneMenu : Scene
    {
        private Background background;
        private Button buttonPlay;
        private Button buttonCredits;
        private Button buttonExit;

        public SceneMenu(Main pMain) : base(pMain)
        {
            
        }

        public override void Load()
        {
            Debug.WriteLine("SceneMenu loaded");
            Rectangle screen = main.Window.ClientBounds;

            // Background
            background = new Background(main.Content.Load<Texture2D>("BackGroundMenu"));
            listActor.Add(background);

            //Buttons
            buttonPlay = new Button("PLAY");
            buttonPlay.Pos = new Vector2(screen.Width / 2 - buttonPlay.BoundingBox.Width / 2,
                                        screen.Height / 2.7f - buttonPlay.BoundingBox.Height / 2);
            buttonPlay.Onclick = OnClickPlay;

            buttonCredits = new Button("credits");
            buttonCredits.Pos = new Vector2(screen.Width / 2 - buttonPlay.BoundingBox.Width / 2,
                                            screen.Height / 2.0f - buttonPlay.BoundingBox.Height / 2);
            buttonCredits.Onclick = OnclickCredits;
            buttonExit = new Button("EXIT");
            buttonExit.Pos = new Vector2(screen.Width / 2 - buttonPlay.BoundingBox.Width / 2,
                                        screen.Height / 1.55f - buttonPlay.BoundingBox.Height / 2);
            buttonExit.Onclick = OnClickExit;

            listActor.Add(buttonPlay);
            listActor.Add(buttonCredits);
            listActor.Add(buttonExit);
            base.Load();
        }

        public void OnClickPlay(Button pButton)
        {
            AssetManager.clickedOnMenuButton.Play();
            main.gameState.ChangeScene(GameState.SceneType.Game);
        }

        public void OnclickCredits(Button pButton)
        {
            AssetManager.clickedOnMenuButton.Play();
            main.gameState.ChangeScene(GameState.SceneType.Credits);
        }

        public void OnClickExit(Button pButton)
        {
            main.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
