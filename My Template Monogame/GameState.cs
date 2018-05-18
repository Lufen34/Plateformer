using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateformer
{
    public class GameState
    {
        public enum SceneType
        {
            Menu,
            Game,
            GameOver,
            Credits
        }

        protected Main main;
        public Scene CurrentScene { get; set; }

        public GameState(Main pMain)
        {
            this.main = pMain;
        }

        public void ChangeScene(SceneType pSceneType)
        {
            if (CurrentScene != null)
            {
                CurrentScene.Unload();
                CurrentScene = null;
            }
            switch (pSceneType)
            {
                case SceneType.Menu:
                    CurrentScene = new SceneMenu(main);
                    CurrentScene.CurrentType = GameState.SceneType.Menu;
                    break;
                case SceneType.Game:
                    CurrentScene = new GameScene(main);
                    CurrentScene.CurrentType = GameState.SceneType.Game;
                    break;
                case SceneType.GameOver:
                    CurrentScene = new GameOverScene(main);
                    CurrentScene.CurrentType = GameState.SceneType.GameOver;
                    break;
                case SceneType.Credits:
                    CurrentScene = new CreditScene(main);
                    CurrentScene.CurrentType = GameState.SceneType.Credits;
                    break;
                default:
                    break;
            }
            CurrentScene.Load();
        }

    }
}
