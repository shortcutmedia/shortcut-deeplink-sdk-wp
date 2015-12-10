using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCServerRequestCreateShortLink : SCServerRequest
    {
        private SCShortLinkCreateListener callback;

        public SCServerRequestCreateShortLink(SCSession session, SCShortLinkItem item)
            : base(ActionUrls.GetActionUrl(ActionUrls.Create), session)
        {
            Dictionary<string, string> postData = new Dictionary<string, string>();
            try
            {
                postData.Add(KeyValues.DEEP_LINK_ITEM_KEY, item.ToJson().ToString());
            }
            catch (Exception e)
            {

            }

            base.PostData = postData;
        }

        public SCServerRequestCreateShortLink(SCSession session, SCShortLinkItem item, SCShortLinkCreateListener callback)
            : this(session, item)
        {
            this.callback = callback;
        }

        public SCShortLinkCreateListener Callback
        {
            get
            {
                return this.callback;
            }
            set
            {
                this.callback = value;
            }
        }

        public void OnRequestSucceeded(SCServerResponse response)
        {
            if (this.callback != null)
            {
                JObject json = response.Json;
                string Url = json[KeyValues.SHORT_URL_RESPONSE_KEY].ToString();
                if (!String.IsNullOrWhiteSpace(Url))
                {
                    Uri shortLink = new Uri(Url);
                    this.callback.OnLinkCreated(shortLink.ToString());
                }
            }
        }
    }
}
