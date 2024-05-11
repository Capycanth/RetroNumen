using Microsoft.Xna.Framework;
using RetroNumen.Display.MainDisplay.HexMap;
using RetroNumen.Utility;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroNumen.Display.MainDisplay.Animation
{
    public class HexArt
    {
        private HexBox[,] screen;
        private int slide_time = 0;
        private readonly int SLIDE_INTERVAL = 100;
        private int print_size = 0;
        private readonly int PRINT_INTERVAL = 2;
        private bool done_printing = false;

        public HexArt(string image)
        {
            screen = new HexBox[Globals.MAP_HEX_BOX_SIZE, Globals.MAP_HEX_BOX_SIZE];
            Bitmap img = GameMain.Cache.Bitmaps[image];
            Parallel.For(0, Globals.MAP_HEX_BOX_SIZE,
                (y) =>
                {
                    for (int x = 0; x < Globals.MAP_HEX_BOX_SIZE; x++)
                    {
                        HexBox hexBox = HexBoxHelper.CreateHexBoxByEnum(HexBoxType.ART);
                        hexBox.SetPosition(x, y);
                        System.Drawing.Color pixel = img.GetPixel(x, y);
                        hexBox.TextColor = new Microsoft.Xna.Framework.Color(pixel.R, pixel.G, pixel.B);
                        screen[y, x] = hexBox;
                    }
                });
        }

        public void Draw()
        {
            for(int lines = 1; lines < print_size + 1; lines++)
            {
                for (int x = 0; x < Globals.MAP_HEX_BOX_SIZE; x++)
                {
                    screen[Globals.MAP_HEX_BOX_SIZE - lines, x].Draw();
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (done_printing)
                return;

            if ((this.slide_time += gameTime.ElapsedGameTime.Milliseconds) > this.SLIDE_INTERVAL)
            {
                this.slide_time = 0;
                this.print_size += PRINT_INTERVAL;
            }

            if (this.print_size == Globals.MAP_HEX_BOX_SIZE)
                this.done_printing = true;
        }
    }
}
