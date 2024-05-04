using Microsoft.Xna.Framework;

namespace RetroNumen.Display
{
    public class DisplayContainer
    {
        private static DisplayContainer instance;
        public static DisplayContainer Instance => instance ?? (instance = new DisplayContainer());
        private DisplayContainer() 
        { 
            mainDisplay = MainDisplay.MainDisplay.Instance;
            infoDisplay = InfoDisplay.InfoDisplay.Instance;
            dialogueDisplay = DialogueDisplay.DialogueDisplay.Instance;
        }

        private MainDisplay.MainDisplay mainDisplay;
        private InfoDisplay.InfoDisplay infoDisplay;
        private DialogueDisplay.DialogueDisplay dialogueDisplay;

        public void Draw()
        {
            mainDisplay.Draw();
            infoDisplay.Draw();
            dialogueDisplay.Draw();
        }

        public void Update(GameTime gameTime)
        {
            mainDisplay.Update(gameTime);
            infoDisplay.Update(gameTime);
            dialogueDisplay.Update(gameTime);
        }

    }
}
