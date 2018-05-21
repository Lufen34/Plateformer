using System;
using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Plateformer
{
    public class BackgroundParralax : Background
    {
        public Vector2 PosMiddleGround { get; set; }
        public int amountRedraw;
        private Texture2D Middleground { get; set; }
        
        
        public BackgroundParralax(Texture2D pBackground, Texture2D pMiddleground) : base(pBackground)
        {
            Middleground = pMiddleground;
            PosMiddleGround = Vector2.Zero;
            amountRedraw = 0;
        }

        public void Move(float pX, float pY, GameTime gameTime, int pSpeed)
        {
            Pos = new Vector2(Pos.X + pSpeed * (pX * (float)gameTime.ElapsedGameTime.TotalSeconds), Pos.Y + pSpeed * (pY * (float)gameTime.ElapsedGameTime.TotalSeconds));
            PosMiddleGround = new Vector2(PosMiddleGround.X + (pSpeed + 50) * (pX * (float)gameTime.ElapsedGameTime.TotalSeconds), PosMiddleGround.Y + pSpeed * (pY * (float)gameTime.ElapsedGameTime.TotalSeconds));
        }
        
        public override void Load()
        {
            base.Load();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(Middleground, PosMiddleGround);
            if (PosMiddleGround.X <= 0)
                spriteBatch.Draw(Middleground, new Vector2(PosMiddleGround.X + Middleground.Width, PosMiddleGround.Y));
            if (PosMiddleGround.X <= -Middleground.Width)
                PosMiddleGround =  Vector2.Zero;
        }
    }
}