using System;

namespace Shortcut.DeepLinking.Pcl
{
    /// <summary>
    /// This class holds the configuration details for the SDK.
    /// </summary>
    public class SCConfig
    {
        private string mAuthToken;
        private int mEnvironment = KeyValues.ENVIRONMENT_PRODUCTION;
        private int mLogLevel = KeyValues.LOG_LEVEL_INFO;

        public SCConfig(String authToken)
        {
            this.mAuthToken = authToken;

            if (this.mEnvironment == KeyValues.ENVIRONMENT_SANDBOX)
            {
                this.mLogLevel = KeyValues.LOG_LEVEL_DEBUG;
            }
        }

        public string AuthToken
        {
            get
            {
                return this.mAuthToken;
            }
            set
            {
                this.mAuthToken = value;
            }
        }

        public int Environment
        {
            get
            {
                return this.mEnvironment;
            }
            set
            {
                this.mEnvironment = value;
            }
        }

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

        public static SCConfig InitFromManifest()
        {
            try
            {
                String authToken = "";
                if (String.IsNullOrWhiteSpace(authToken))
                {
                    return null;
                }
                SCConfig config = new SCConfig(authToken);

                String environment = "";
                if (!String.IsNullOrWhiteSpace(environment))
                {
                    switch (environment.ToLowerInvariant())
                    {
                        case "production":
                            config.Environment = KeyValues.ENVIRONMENT_PRODUCTION;
                            break;
                        case "sandbox":
                            config.Environment = KeyValues.ENVIRONMENT_SANDBOX;
                            break;
                    }
                }

                int logLevel = 0;
                if (logLevel > -1)
                {
                    config.LogLevel = logLevel;
                }

                return config;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
