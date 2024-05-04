using Microsoft.Xna.Framework;
using RetroNumen.Utility;

namespace RetroNumen.Display.InfoDisplay
{
    public class InfoDisplay : DisplayBase
    {
        private static InfoDisplay instance;
        public static InfoDisplay Instance => instance ?? (instance = new InfoDisplay());
        private InfoDisplay()
        {
            this.tabIndex = 0;
            this.infoButtons = new InfoButton[4];
            InitializeButtons();
        }

        private int tabIndex;
        private InfoButton[] infoButtons;

        public override void Draw()
        {
            foreach(InfoButton button in infoButtons)
            {
                button.Draw();
            }    
        }

        public override void Update(GameTime gameTime)
        {
            foreach (InfoButton button in infoButtons)
            {
                button.Update(gameTime);
            }
        }

        private void SetSelectedTab(int tabIndex)
        {
            this.tabIndex = tabIndex;
            for (int i = 0; i < this.infoButtons.Length; i++)
            {
                infoButtons[i].IsSelected = i == tabIndex;
            }
        }

        private void InitializeButtons()
        {
            this.infoButtons[0] = new InfoButton(
                new Rectangle(Globals.INFO_DISPLAY_X_OFFSET + 0, Globals.INFO_DISPLAY_Y_OFFSET, Globals.INFO_BUTTON_WIDTH, Globals.INFO_BUTTON_HEIGHT),
                "STATS",
                () => this.SetSelectedTab(0));
            this.infoButtons[1] = new InfoButton(
                new Rectangle(Globals.INFO_DISPLAY_X_OFFSET + Globals.INFO_BUTTON_WIDTH, Globals.INFO_DISPLAY_Y_OFFSET, Globals.INFO_BUTTON_WIDTH, Globals.INFO_BUTTON_HEIGHT),
                "INV",
                () => this.SetSelectedTab(1));
            this.infoButtons[2] = new InfoButton(
                new Rectangle(Globals.INFO_DISPLAY_X_OFFSET + (Globals.INFO_BUTTON_WIDTH * 2), Globals.INFO_DISPLAY_Y_OFFSET, Globals.INFO_BUTTON_WIDTH, Globals.INFO_BUTTON_HEIGHT),
                "QUEST",
                () => this.SetSelectedTab(2));
            this.infoButtons[3] = new InfoButton(
                new Rectangle(Globals.INFO_DISPLAY_X_OFFSET + (Globals.INFO_BUTTON_WIDTH * 3), Globals.INFO_DISPLAY_Y_OFFSET, Globals.INFO_BUTTON_WIDTH, Globals.INFO_BUTTON_HEIGHT),
                "SEARCH",
                () => this.SetSelectedTab(3));

            this.SetSelectedTab(0);
        }
    }
}
