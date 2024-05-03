namespace RetroNumen.Display
{
    public class DisplayContainer
    {
        private DisplayContainer instance;
        public DisplayContainer Instance => instance ?? (instance = new DisplayContainer());
        private DisplayContainer() { }

        private MainDisplay.MainDisplay mainDisplay;
        private InfoDisplay.InfoDisplay infoDisplay;
        private DialogueDisplay.DialogueDisplay dialogueDisplay;

    }
}
