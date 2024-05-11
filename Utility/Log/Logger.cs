using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

namespace RetroNumen.Utility.Log
{
    public static class Logger
    {
        private static Dictionary<string, List<LogEntry>> LogContainer = new Dictionary<string, List<LogEntry>>();
        private static readonly string LOG_DIRECTORY = "C:\\OiCornwall\\GameDev\\Log\\";
        public static string StartLog(string logTitle)
        {
            if (LogContainer.ContainsKey(logTitle))
            {
                return StartLog(logTitle + "_I");
            }

            LogContainer.Add(logTitle, new List<LogEntry> { new LogEntry(DateTime.Now, "Initialized Log") });

            return logTitle;
        }

        public static void AddLog(string logTitle, string message)
        {
            if (!LogContainer.ContainsKey(logTitle))
            {
                return;
            }

            LogContainer[logTitle].Add(new LogEntry(DateTime.Now, message));
        }

        public static void StopLog(string logTitle)
        {
            if (!LogContainer.ContainsKey(logTitle))
            {
                return;
            }

            LogContainer[logTitle].Add(new LogEntry(DateTime.Now, "Finalized Log"));

            FlushLog(logTitle);
            LogContainer.Remove(logTitle);
        }

        private static void FlushLog(string logTitle)
        {
            string content = "";

            List<LogEntry> logs = LogContainer[logTitle];

            DateTime beginning = logs[0].Time;

            foreach (LogEntry logEntry in logs)
            {
                content += 
                    (logEntry.Time.ToUniversalTime().Subtract(
                        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    ).TotalMilliseconds - beginning.ToUniversalTime().Subtract(
                        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    ).TotalMilliseconds).ToString() +
                    ": " +
                    logEntry.Message + 
                    "\n";
            }

            try
            {
                File.WriteAllText(LOG_DIRECTORY + logTitle + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".txt", content);
                Console.WriteLine("File written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
