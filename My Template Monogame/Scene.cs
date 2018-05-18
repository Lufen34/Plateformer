using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateformer
{
    public abstract class Scene
    {
        protected Main main;
        public GameState.SceneType CurrentType { get; set; }
        public List<IActor> listActor;

        public Scene(Main pMain)
        {
            this.main = pMain;
            listActor = new List<IActor>();
        }

        public virtual void Load()
        {
            foreach (IActor actor in listActor)
            {
                actor.Load();
            }
        }

        public virtual void Unload()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (IActor actor in listActor)
            {
                actor.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            foreach (IActor actor in listActor)
            {
                actor.Draw(main.spriteBatch);
            }
        }
    }
}
