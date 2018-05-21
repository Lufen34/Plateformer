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
using TiledSharp;

namespace Plateformer
{
    class GameScene : Scene
    {
        private Player _player;
        private BackgroundParralax BackgroundP {get; set;}
        private readonly int _backgroundSpeed;
        private KeyboardState _oldKeystate;
        private readonly int _speedRatio;
        private TmxMap map { get; set; }
        private Texture2D Props { get; set; }
        private Texture2D Houses { get; set; }
        private Texture2D Tileset { get; set; }

        public GameScene(Main pMain) : base(pMain)
        {
            _backgroundSpeed = 100;
            _oldKeystate = Keyboard.GetState();
            _speedRatio = 1;
            map = new TmxMap("Content/map.tmx");
            Tileset = main.Content.Load<Texture2D>(map.Tilesets[0].Name);
            Houses = main.Content.Load<Texture2D>(map.Layers[1].Name);
            Props = main.Content.Load<Texture2D>(map.Layers[2].Name);
        }

        public override void Load()
        {
            base.Load();
            BackgroundP = new BackgroundParralax(main.Content.Load<Texture2D>("backgroundlevel1"), main.Content.Load<Texture2D>("middlegroundlevel1"));
            _player = new Player(main.Content.Load<Texture2D>("player2"));
            listActor.Add(BackgroundP);
            //listActor.Add(player);
            Debug.WriteLine("GameScene loaded");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                _player.Move(0, -_speedRatio, gameTime);
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _player.Move(0, _speedRatio, gameTime);
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                _player.Move(-_speedRatio, 0, gameTime);
                if (BackgroundP.PosMiddleGround.X < -1) // Change it later when the position of the player reach the start (Tiled speaking)
                    BackgroundP.Move(_speedRatio, 0, gameTime, _backgroundSpeed);
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _player.Move(_speedRatio, 0, gameTime);
                BackgroundP.Move(-_speedRatio, 0, gameTime, _backgroundSpeed);
            }
            
            _oldKeystate = Keyboard.GetState();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            main.spriteBatch.DrawString(AssetManager.MainFont, "This is the Game", new Vector2(), Color.White);
        }
    }
}
