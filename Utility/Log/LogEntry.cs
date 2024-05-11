using System;

namespace RetroNumen.Utility.Log
{
    public class LogEntry
    {
        private DateTime time;
        public DateTime Time { get { return time; } }
        private string message;
        public string Message { get { return message; } }

        public LogEntry(DateTime time, string message)
        {
            this.time = time;
            this.message = message;
        }
    }
}
