using System;
using System.Collections.Generic;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCDeepLinking
    {
        private static SCDeepLinking scDeepLinking;
        private SCPreference scPreference;
        private SCSession scSession;
        private SCConfig scConfig;

        private Uri deepLinkAtLaunch;
        private Uri deepLink;
        private Dictionary<string, object> sessions;

        public SCDeepLinking(SCConfig config)
        {
            this.scConfig = config;
            this.scPreference = new SCPreference();
            this.sessions = new Dictionary<string, object>();
        }

        //public SCDeepLinking(SCConfig config, Context context)
        //{
        //    this.scConfig = config;
        //    this.context = context;
        //    this.scPreference = new SCPreference();
        //    this.sessions = new Dictionary<string, object>();

        //    if (context == typeof(SCDeepLinkingApp))
        //    {

        //    }
        //}

        public static SCDeepLinking GetInstance(SCConfig config)
        {
            if (scDeepLinking == null)
            {
                scDeepLinking = new SCDeepLinking(config);
            }
            return scDeepLinking;
        }

        //public static SCDeepLinking GetInstance(SCConfig config, Context context)
        //{
        //    if (scDeepLinking == null)
        //    {
        //        scDeepLinking = new SCDeepLinking(config, context);
        //    }
        //    return scDeepLinking;
        //}

        public static SCDeepLinking GetInstance()
        {
            return scDeepLinking;
        }

        public Uri GetDeepLink()
        {
            return this.deepLink;
        }

        public bool IsFirstLaunch()
        {
            return this.scPreference.IsFirstLaunch();
        }

        private void HandleDeepLink(string activity, Uri deepLink)
        {
            String Id = deepLink.Query;
        }

        private void GenerateSessionId()
        {
            this.scSession = new SCSession(this.deepLinkAtLaunch);
        }

        internal void CreateShortLink(SCShortLinkItem item, SCShortLinkCreateListener callback)
        {
            throw new NotImplementedException();
            //PostTask postTask = new PostTask();
            //postTask.Execute(new SCServerRequestCreateShortLink(this.scSession, item, callback));
        }
    }
}
