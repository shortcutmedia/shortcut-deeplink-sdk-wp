using System;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCLogger
    {
        public static string LOG_TAG = KeyValues.LOG_TAG;
        private int mLogLevel = KeyValues.LOG_LEVEL_INFO;

        public int LogLevel
        {
            get
            {
                return this.mLogLevel;
            }
            set
            {
                this.mLogLevel = value;
            }
        }

        public void Debug(string message)
        {
            if (this.mLogLevel <= KeyValues.LOG_LEVEL_DEBUG)
            {
                
            }
        }

        public void Warning(String message)
        {
            if (this.mLogLevel <= KeyValues.LOG_LEVEL_WARN)
            {

            }
        }

        public static int FromString(String logLevel)
        {
            int mLogLevel = -1;
            if (!String.IsNullOrWhiteSpace(logLevel))
            {
                switch(logLevel.ToLowerInvariant())
                {
                    case "verbose":
                        mLogLevel = KeyValues.LOG_LEVEL_VERBOSE;
                        break;
                    case "debug":
                        mLogLevel = KeyValues.LOG_LEVEL_DEBUG;
                        break;
                    case "info":
                        mLogLevel = KeyValues.LOG_LEVEL_INFO;
                        break;
                    case "warn":
                        mLogLevel = KeyValues.LOG_LEVEL_WARN;
                        break;
                    case "error":
                        mLogLevel = KeyValues.LOG_LEVEL_ERROR;
                        break;
                }
            }
            return mLogLevel;
        }
    }
}
