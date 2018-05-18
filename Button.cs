using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Plateformer
{
    public delegate void OnClick(Button button);

    public class Button : IActor
    {
        public String ButtonName { get; set; }
        public Vector2 Pos { get; set; }
        public Rectangle BoundingBox { get; set; }
        public bool IsOver;
        public OnClick Onclick { get; set; }


        private MouseState oldMouseState;
        private Color idle;
        private Color mouseOver;

        public Button (String pName)
        {
            this.ButtonName = pName;
            this.oldMouseState = Mouse.GetState();
            this.IsOver = false;
            idle = Color.Black;
            mouseOver = Color.ForestGreen;
        }

        public Button(String pName, Color pIdle, Color pMouseOver)
        {
            this.ButtonName = pName;
            this.oldMouseState = Mouse.GetState();
            this.IsOver = false;
            this.idle = pIdle;
            this.mouseOver = pMouseOver;
        }

        public void Load()
        {
            this.BoundingBox = new Rectangle((int)Pos.X, (int)Pos.Y, ButtonName.Length * 20, ButtonName.Length * 10);
            Console.WriteLine("Pos X = " + (int)Pos.X + "Pos Y = " + (int)Pos.Y);
        }



        public void Update(GameTime gameTime)
        {
            Point mousePos = Mouse.GetState().Position;
            if (BoundingBox.Contains(mousePos))
            {
                if (!IsOver)
                {
                    IsOver = true;
                    AssetManager.onButton.Play();
                }
            }
            else if (!BoundingBox.Contains(mousePos))
            {
                if (IsOver)
                {
                    IsOver = false;
                }
            }
            if (IsOver)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && oldMouseState.LeftButton != ButtonState.Pressed)
                {
                    if (Onclick != null)
                    {
                        Onclick(this);
                    }
                }
            }
            oldMouseState = Mouse.GetState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsOver)
                spriteBatch.DrawString(AssetManager.MainFont, ButtonName, Pos, mouseOver);
            else if (!IsOver)
                spriteBatch.DrawString(AssetManager.MainFont, ButtonName, Pos, idle);
        }
    }
}
