using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCServerRequest
    {
        private string requestUri;
        private SCSession session;
        private Dictionary<string, string> postData;

        public SCServerRequest(string RequestPath, SCSession Session)
        {
            this.requestUri = RequestPath;
            this.session = Session;
        }

        protected Dictionary<string, string> PostData
        {
            get { return this.postData; }
            set { this.postData = value; }
        }

        protected Dictionary<string, string> CommonPostData
        {
            get
            {
                Dictionary<string, string> postData = new Dictionary<string, string>();
                postData.Add(KeyValues.DEVICE_ID_KEY, new SCPreference().DeviceId);
                postData.Add(KeyValues.SESSION_ID_KEY, this.session.Id);
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
                        string content = client.ExecutePostDataAsJsonAsync(this.requestUri, BuildPostData()).Result.GetResult();
                        SCServerResponse scResponse = new SCServerResponse(JObject.Parse(content));
                        result = scResponse.DeepLinkString;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
            return result;
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
