using System;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCServerRequestRegisterFirstOpen : SCServerRequest, ISCServerRequest
    {
        public SCServerRequestRegisterFirstOpen(SCSession session)
            : base(ActionUrls.GetActionUrl(ActionUrls.FirstOpen), session)
        {
            base.PostData = new SCEnvironment().toMap();
        }
    }
}
