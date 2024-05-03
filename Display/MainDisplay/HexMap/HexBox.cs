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

        public HexBox(string hexString, int hexValue, Color textColor, HexBoxType type)
        {
            this.hexString = hexString;
            this.hexValue = hexValue;
            this.textColor = textColor;
            this.type = type;

            this.mod = HexBoxMod.NORMAL;
            this.modColor = HexBoxHelper.GetHexBoxModColor(this.mod);
            this.textFont = GameMain.Cache.Fonts["wartext"];
            this.modTexture = new Texture2D(GameMain.Graphics.GraphicsDevice, 1, 1);
        }

        public void Draw()
        {
            if (this.mod != HexBoxMod.NORMAL)
                GameMain.SpriteBatch.Draw(this.modTexture, this.modRect, this.modColor);
            GameMain.SpriteBatch.DrawString(this.textFont, this.hexString, this.textPosition, this.textColor);
        }

        public void Update()
        {

        }

        public void SetPosition(int x, int y)
        {
            this.modRect = new Rectangle(x * Globals.HEX_BOX_SIZE, y * Globals.HEX_BOX_SIZE, Globals.HEX_BOX_SIZE, Globals.HEX_BOX_SIZE);
            // NOTE: 1's are kind of skinny, so we need to shift the text an extra pixel for each 1
            int one_count = hexString.Count(c => c == '1');
            // TODO: Center text in rectangle
            this.textPosition = new Vector2(
                this.modRect.X,
                this.modRect.Y);
        }

        public void SetModType(HexBoxMod mod)
        {
            this.mod = mod;
            this.modColor = HexBoxHelper.GetHexBoxModColor(mod);
        }
    }
}
