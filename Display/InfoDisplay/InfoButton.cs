using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace RetroNumen.Display.InfoDisplay
{
    public class InfoButton 
    {
        private Rectangle rec;
        private Texture2D unselected;
        private Texture2D selected;
        private string text;
        private Action tabSetter;
        private bool isSelected;
        private Color selectedTextColor;
        private Color unselectedTextColor;
        private Vector2 textPosition;

        public InfoButton(Rectangle rec, string text, Action action)
        {
            this.rec = rec;
            this.text = text;
            this.tabSetter = action;
            this.unselected = GameMain.Cache.Textures["InfoButtonUnselected"];
            this.selected = GameMain.Cache.Textures["InfoButtonSelected"];
            this.selectedTextColor = Color.Black;
            this.unselectedTextColor = new Color(255, 176, 0);

            Vector2 textSize = GameMain.Cache.Fonts["wartext20"].MeasureString(text);
            this.textPosition = new Vector2(
                this.rec.X + (this.rec.Width - textSize.X) / 2,
                this.rec.Y + (this.rec.Height - textSize.Y) / 2);
        }

        public void Draw()
        {
            GameMain.SpriteBatch.Draw(this.isSelected ? this.selected : this.unselected, this.rec, Color.White);
            GameMain.SpriteBatch.DrawString(GameMain.Cache.Fonts["wartext20"], this.text,
                this.textPosition, this.isSelected ? this.selectedTextColor : this.unselectedTextColor);
        }

        public void Update(GameTime gameTime)
        {
            MouseState currMouseState = GameMain.InputManager.GetCurrentMouseState();
            if (this.rec.Contains(currMouseState.X, currMouseState.Y) && currMouseState.LeftButton == ButtonState.Pressed)
            {
                this.tabSetter();
            }
        }

        public bool IsSelected
        {
            set
            {
                this.isSelected = value;
            }
        }
    }
}
