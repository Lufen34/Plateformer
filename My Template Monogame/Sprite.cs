using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Plateformer
{
    public abstract class Sprite : IActor
    {
        // IActor implementation
        public Vector2 Pos { get; set; }
        public Rectangle BoundingBox { get; set; }

        // Sprite implementation
        public Texture2D Texture { get; set; }

        // Caracteristics
        protected int speed = 200;

        public Sprite(Texture2D pTexture)
        {
            Texture = pTexture;
        }

        public void Move(float pX, float pY, GameTime gameTime)
        {
            Pos = new Vector2(Pos.X + speed * (pX * (float)gameTime.ElapsedGameTime.TotalSeconds), Pos.Y + speed * (pY * (float)gameTime.ElapsedGameTime.TotalSeconds));
        }

        public virtual void Load()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            BoundingBox = new Rectangle((int)Pos.X, (int)Pos.Y, Texture.Width, Texture.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Pos);
        }
    }
}
