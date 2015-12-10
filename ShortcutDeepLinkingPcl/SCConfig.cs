using System;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCConfig
    {
        private string authToken;
        private int environment = KeyValues.ENVIRONMENT_PRODUCTION;
        private int logLevel = KeyValues.LOG_LEVEL_INFO;

        public SCConfig(String AuthToken)
        {
            this.authToken = AuthToken;

            if (this.environment == KeyValues.ENVIRONMENT_SANDBOX)
            {
                this.logLevel = KeyValues.LOG_LEVEL_DEBUG;
            }
        }

        public string AuthToken
        {
            get
            {
                return this.authToken;
            }
            set
            {
                this.authToken = value;
            }
        }

        public int Environment
        {
            get
            {
                return this.environment;
            }
            set
            {
                this.environment = value;
            }
        }

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
