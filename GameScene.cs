using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Plateformer
{
    class GameScene : Scene
    {
        public Player player;
        public BackgroundParralax backgroundP {get; set;}
        private int backgroundSpeed;
        private KeyboardState oldKeystate;
        private int speedRatio;

        public GameScene(Main pMain) : base(pMain)
        {
            backgroundSpeed = 100;
            oldKeystate = Keyboard.GetState();
            speedRatio = 1;
        }

        public override void Load()
        {
            base.Load();
            backgroundP = new BackgroundParralax(main.Content.Load<Texture2D>("backgroundlevel1"), main.Content.Load<Texture2D>("middlegroundlevel1"));
            player = new Player(main.Content.Load<Texture2D>("player2"));
            listActor.Add(backgroundP);
            //listActor.Add(player);
            Debug.WriteLine("GameScene loaded");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                player.Move(0, -speedRatio, gameTime);
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                player.Move(0, speedRatio, gameTime);
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                player.Move(-speedRatio, 0, gameTime);
                if (backgroundP.PosMiddleGround.X < -1) // Change it later when the position of the player reach the start (Tiled speaking)
                backgroundP.Move(speedRatio, 0, gameTime, backgroundSpeed);
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                player.Move(speedRatio, 0, gameTime);
                backgroundP.Move(-speedRatio, 0, gameTime, backgroundSpeed);
            }
            
            oldKeystate = Keyboard.GetState();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            main.spriteBatch.DrawString(AssetManager.MainFont, "This is the Game", new Vector2(), Color.White);
        }
    }
}
