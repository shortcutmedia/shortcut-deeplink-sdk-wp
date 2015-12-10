using System;
using System.Collections.Generic;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCServerRequestRegisterClose : SCServerRequest
    {
        public SCServerRequestRegisterClose(SCSession Session)
            : base(ActionUrls.GetActionUrl(ActionUrls.Close), Session)
        {
            Dictionary<string, string> postData = new Dictionary<string, string>();
            postData.Add(KeyValues.LINK_ID_KEY, Session.LinkId);
            base.PostData = postData;
        }

        protected override bool shouldSend()
        {
            // no need to send request without a link_id
            return base.PostData.ContainsKey(KeyValues.LINK_ID_KEY) && !String.IsNullOrEmpty(base.PostData[KeyValues.LINK_ID_KEY]);
        }
    }
}
