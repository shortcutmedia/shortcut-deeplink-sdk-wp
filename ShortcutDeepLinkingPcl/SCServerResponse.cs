using System;
using Newtonsoft.Json.Linq;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCServerResponse
    {
        private JObject json;

        public SCServerResponse(JObject Json)
        {
            this.json = Json;
        }

        public string DeepLinkString
        {
            get { return json[KeyValues.DEEP_LINK_KEY].ToString(); }
        }

        public Uri DeepLink
        {
            get { return new Uri(this.DeepLinkString); }
        }

        public JObject Json { get; set; }
    }
}
