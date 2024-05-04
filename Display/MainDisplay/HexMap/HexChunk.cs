using Microsoft.Xna.Framework;
using RetroNumen.Utility;
using System;

namespace RetroNumen.Display.MainDisplay.HexMap
{
    public class HexChunk
    {
        private HexBox[,] chunk;
        private int x_coord;
        private int y_coord;

        public HexChunk() { }

        public HexChunk(int x, int y)
        {
            this.x_coord = x;
            this.y_coord = y;
            this.chunk = new HexBox[Globals.CHUNK_HEX_BOX_SIZE, Globals.CHUNK_HEX_BOX_SIZE];
        }

        public void Draw()
        {
            foreach(HexBox box in this.chunk)
            {
                box.Draw();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (HexBox box in this.chunk)
            {
                box.Update();
            }
        }

        public void SetHexBox(int x, int y, HexBox hexBox)
        {
            this.chunk[y, x] = hexBox;
        }

        public void InitializeRandomChunk()
        {
            this.chunk = new HexBox[Globals.CHUNK_HEX_BOX_SIZE, Globals.CHUNK_HEX_BOX_SIZE];
            for (int y = 0; y < Globals.CHUNK_HEX_BOX_SIZE; y++)
            {
                for (int x = 0; x < Globals.CHUNK_HEX_BOX_SIZE; x++)
                {
                    HexBoxType[] types = Enum.GetValues<HexBoxType>();
                    HexBox hexBox = HexBoxHelper.CreateHexBoxByEnum(types[GameMain.Random.Next(1, types.Length)]);
                    hexBox.SetPosition(x, y);
                    this.chunk[y, x] = hexBox;
                }
            }
        }
    }
}
