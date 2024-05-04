using Microsoft.Xna.Framework;

namespace RetroNumen.Display.DialogueDisplay
{
    public class DialogueDisplay : DisplayBase
    {
        private static DialogueDisplay instance;
        public static DialogueDisplay Instance => instance ?? (instance = new DialogueDisplay());
        private DialogueDisplay()
        {

        }

        public override void Draw()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
           
        }
    }
}
