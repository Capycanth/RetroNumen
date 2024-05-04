namespace RetroNumen.Event
{
    public class EventProcessor
    {
        private EventProcessor instance;
        public EventProcessor Instance => instance ?? (instance = new EventProcessor());
        private EventProcessor() { }
    }
}
