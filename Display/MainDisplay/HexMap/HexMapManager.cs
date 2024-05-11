using Microsoft.Xna.Framework;
using RetroNumen.Utility;
using System.Threading.Tasks;

namespace RetroNumen.Display.MainDisplay.HexMap
{
    public class HexMapManager
    {
        private static HexMapManager instance;
        public static HexMapManager Instance => instance ?? (instance = new HexMapManager());
        private HexMapManager() { }

        private HexChunk[,] map;
        private (int, int) currentChunk = (Globals.MAP_HEX_BOX_SIZE >> 1, Globals.MAP_HEX_BOX_SIZE >> 1);

        public void Draw()
        {
            map[currentChunk.Item2, currentChunk.Item1].Draw();
        }

        public void Update(GameTime gameTime)
        {
            map[currentChunk.Item2, currentChunk.Item1].Update(gameTime);
        }

        public void InitializeRandomMap()
        {
            map = new HexChunk[Globals.MAP_HEX_BOX_SIZE, Globals.MAP_HEX_BOX_SIZE];

            Parallel.For(0, Globals.MAP_HEX_BOX_SIZE,
                (y) =>
                {
                    for (int x = 0; x < Globals.MAP_HEX_BOX_SIZE; x++)
                    {
                        map[y, x] = new HexChunk();
                        map[y, x].InitializeRandomChunk();
                    }
                });
        }

        public void InitializePerlinMap()
        {

        }

        public void ShiftChunk(int x, int y)
        {
            this.currentChunk = (this.currentChunk.Item1 + x, this.currentChunk.Item2 - y);
        }

    }
}
