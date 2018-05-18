using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateformer
{
    public interface IActor
    {
        Vector2 Pos { get; set; }
        Rectangle BoundingBox { get; set; }
        void Load();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
