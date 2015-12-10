using System;
using Newtonsoft.Json.Linq;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCServerResponse
    {
        private JObject mJson;

        public SCServerResponse(JObject json)
        {
            this.mJson = json;
        }

        public JObject Json
        {
            get
            {
                return this.mJson;
            }
            private set
            {
                this.mJson = value;
            }
        }

        public string DeepLinkString
        {
            get { return mJson[KeyValues.DEEP_LINK_KEY].ToString(); }
        }

        public Uri DeepLink
        {
            get { return new Uri(this.DeepLinkString); }
        }
    }
}
