using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Plateformer
{
    public class Background : IActor
    {
        public Rectangle BoundingBox { get; set; }
        public Vector2 Pos { get; set; }
        private Texture2D background;
        
        public Background(Texture2D pTexture)
        {
            background = pTexture;
            Pos = Vector2.Zero;
        }
        
        public virtual void Load()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Pos);
            if (Pos.X <= 0)
                spriteBatch.Draw(background, new Vector2(Pos.X + background.Width, Pos.Y));
            if (Pos.X <= -background.Width)
                Pos =  Vector2.Zero;
        }

    }
}
