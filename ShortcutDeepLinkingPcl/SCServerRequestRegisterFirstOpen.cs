using System;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCServerRequestRegisterFirstOpen : SCServerRequest
    {
        public SCServerRequestRegisterFirstOpen(SCSession Session)
            : base(ActionUrls.GetActionUrl(ActionUrls.FirstOpen), Session)
        {
            base.PostData = new SCEnvironment().toMap();
        }
    }
}
