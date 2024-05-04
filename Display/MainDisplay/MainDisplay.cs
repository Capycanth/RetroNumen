using Microsoft.Xna.Framework;
using RetroNumen.Display.MainDisplay.HexMap;

namespace RetroNumen.Display.MainDisplay
{
    public class MainDisplay : DisplayBase
    {
        private static MainDisplay instance;
        public static MainDisplay Instance => instance ?? (instance = new MainDisplay());

        private MainDisplay()
        {
            hexMapManager = HexMapManager.Instance;
            hexMapManager.InitializeRandomMap();
        }

        private HexMapManager hexMapManager;


        public override void Draw()
        {
            hexMapManager.Draw();
        }

        public override void Update(GameTime gameTime)
        {
            hexMapManager.Update(gameTime);
        }
    }
}
