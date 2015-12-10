using System;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCLogger
    {
        public static string LOG_TAG = KeyValues.LOG_TAG;
        private int logLevel = KeyValues.LOG_LEVEL_INFO;

        public int LogLevel
        {
            get
            {
                return this.logLevel;
            }
            set
            {
                this.logLevel = value;
            }
        }

        public void Debug(string Message)
        {
            if (this.logLevel <= KeyValues.LOG_LEVEL_DEBUG)
            {
                
            }
        }

        public void Warning(String Message)
        {
            if (this.logLevel <= KeyValues.LOG_LEVEL_WARN)
            {

            }
        }

        public static int FromString(String LogLevel)
        {
            int logLevel = -1;
            if (!String.IsNullOrWhiteSpace(LogLevel))
            {
                switch(LogLevel.ToLowerInvariant())
                {
                    case "verbose":
                        logLevel = KeyValues.LOG_LEVEL_VERBOSE;
                        break;
                    case "debug":
                        logLevel = KeyValues.LOG_LEVEL_DEBUG;
                        break;
                    case "info":
                        logLevel = KeyValues.LOG_LEVEL_INFO;
                        break;
                    case "warn":
                        logLevel = KeyValues.LOG_LEVEL_WARN;
                        break;
                    case "error":
                        logLevel = KeyValues.LOG_LEVEL_ERROR;
                        break;
                }
            }
            return logLevel;
        }
    }
}
