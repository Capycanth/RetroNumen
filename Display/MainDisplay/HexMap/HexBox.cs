using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RetroNumen.Utility;
using System.Linq;

namespace RetroNumen.Display.MainDisplay.HexMap
{
    public class HexBox
    {
        // Hex Variables
        private string hexString;
        private int hexValue;
        // Text Variables
        private Color textColor;
        private Vector2 textPosition;
        private SpriteFont textFont;
        // Mod Variables
        private Rectangle modRect;
        private Texture2D modTexture;
        private Color modColor;
        // Enum Variables
        private HexBoxMod mod;
        private HexBoxType type;

        public HexBox() { }

        public HexBox(string hexString, int hexValue, Color textColor, HexBoxType type)
        {
            this.hexString = hexString;
            this.hexValue = hexValue;
            this.textColor = textColor;
            this.type = type;

            this.modTexture = new Texture2D(GameMain.Graphics.GraphicsDevice, 1, 1);
            this.Mod = HexBoxMod.NORMAL;
            this.textFont = GameMain.Cache.Fonts["wartext14"];
            
        }

        public void Draw()
        {
            if (this.mod != HexBoxMod.NORMAL)
                GameMain.SpriteBatch.Draw(this.modTexture, this.modRect, this.modColor);
            GameMain.SpriteBatch.DrawString(this.textFont, this.hexString, this.textPosition, this.textColor);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void SetPosition(int x, int y)
        {
            this.modRect = new Rectangle(
                (x * Globals.HEX_BOX_SIZE) + Globals.MAIN_DISPLAY_X_OFFSET,
                (y * Globals.HEX_BOX_SIZE) + Globals.MAIN_DISPLAY_Y_OFFSET, 
                Globals.HEX_BOX_SIZE, 
                Globals.HEX_BOX_SIZE);
            // NOTE: 1's are kind of skinny, so we need to shift the text an extra pixel for each 1
            int one_count = hexString.Count(c => c == '1');
            Vector2 textSize = this.textFont.MeasureString(this.hexString);
            this.textPosition = new Vector2(
                (this.modRect.X + (this.modRect.Width - textSize.X) / 2) + one_count,
                (this.modRect.Y + (this.modRect.Height - textSize.Y) / 2) + 2);
        }

        public void MovePosition(int x, int y)
        {
            this.modRect.X += (x * Globals.HEX_BOX_SIZE);
            this.modRect.Y -= (y * Globals.HEX_BOX_SIZE);
            this.textPosition.X += (x * Globals.HEX_BOX_SIZE);
            this.textPosition.Y -= (y * Globals.HEX_BOX_SIZE);
        }

        public HexBoxMod Mod
        {
            get { return this.mod; }
            set
            {
                this.mod = value;
                this.modColor = HexBoxHelper.GetHexBoxModColor(this.mod);
                this.modTexture.SetData(new[] { this.modColor });

            }
        }

        public Color TextColor
        {
            get { return this.textColor; }
            set { this.textColor = value; }
        }
    }
}
