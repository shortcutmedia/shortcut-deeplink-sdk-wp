using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCServerRequest
    {
        private int mStatus;
        private string mRequestUri;
        private SCSession mSession;
        private SCPreference mPreference;
        private SCConfig mConfig;
        private Dictionary<string, string> mPostData;

        public SCServerRequest(string requestPath, SCSession session)
        {
            this.mRequestUri = requestPath;
            this.mSession = session;
            this.mPreference = SCDeepLinking.GetInstance().Preference;
        }

        public SCConfig Config
        {
            get
            {
                if (mConfig == null)
                {
                    mConfig = SCDeepLinking.GetInstance().Config;
                }
                return this.mConfig;
            }
            private set
            {
                this.mConfig = value;
            }
        }

        public int Status
        {
            get
            {
                return this.mStatus;
            }
            private set
            {
                this.mStatus = value;
            }
        }

        protected Dictionary<string, string> PostData
        {
            get { return this.mPostData; }
            set { this.mPostData = value; }
        }

        protected Dictionary<string, string> CommonPostData
        {
            get
            {
                Dictionary<string, string> postData = new Dictionary<string, string>();
                postData.Add(KeyValues.DEVICE_ID_KEY, this.mPreference.DeviceId);
                postData.Add(KeyValues.SESSION_ID_KEY, this.mSession.Id);
                postData.Add(KeyValues.AUTH_TOKEN_KEY, this.Config.AuthToken);
                return postData;
            }
        }

        public string DoRequest()
        {
            var result = String.Empty;

            if (!shouldSend())
                return null;

            try
            {
                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    using (HttpClient client = new HttpClient(handler) { BaseAddress = new Uri(KeyValues.REQUEST_BASE_URL) })
                    {
                        string content = client.ExecutePostDataAsJsonAsync(this.mRequestUri, BuildPostData()).Result.GetResult();
                        SCServerResponse scResponse = new SCServerResponse(JObject.Parse(content));
                        result = scResponse.DeepLinkString;
                    }
                }
                mStatus = KeyValues.STATUS_SUCCESS;
            }
            catch (Exception ex)
            {
                mStatus = KeyValues.STATUS_CONNECTION_ERROR;
                return ex.StackTrace;
            }
            return result;
        }

        public virtual void OnRequestSucceeded(SCServerResponse response)
        {
        }

        private Dictionary<string, string> BuildPostData()
        {
            return this.PostData.Concat(this.CommonPostData).ToDictionary(x => x.Key, x => x.Value);
        }

        // Returns false if Request is initialized with insufficient or invalid data.
        protected virtual bool shouldSend()
        {
            return true;
        }
    }
}
