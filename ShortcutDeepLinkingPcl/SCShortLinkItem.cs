using System;
using Newtonsoft.Json.Linq;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCShortLinkItem
    {
        private string webDeepLink;
        private string androidDeepLink;
        private string googlePlayStore;
        private string iosDeepLink;
        private string appleAppStore;
        private string windowsDeepLink;
        private string windowsStore;

        public SCShortLinkItem(string webDeepLink,
            string androidDeepLink = null, string googlePlayStore = null,
            string iosDeepLink = null, string appleAppStore = null,
            string windowsDeepLink = null, string windowsStore = null)
        {
            this.webDeepLink = webDeepLink;
            this.androidDeepLink = androidDeepLink;
            this.googlePlayStore = googlePlayStore;
            this.iosDeepLink = iosDeepLink;
            this.appleAppStore = appleAppStore;
            this.windowsDeepLink = windowsDeepLink;
            this.windowsStore = windowsStore;
        }

        public string WindowsStore
        {
            get
            {
                return this.windowsStore;
            }
        }

        public string WindowsDeepLink
        {
            get
            {
                return this.windowsDeepLink;
            }
        }

        public string AppleAppStore
        {
            get
            {
                return this.appleAppStore;
            }
        }

        public string GooglePlayStore
        {
            get
            {
                return this.googlePlayStore;
            }
        }

        public string IosDeepLink
        {
            get
            {
                return this.iosDeepLink;
            }
        }

        public string AndroidDeepLink
        {
            get
            {
                return this.androidDeepLink;
            }
        }

        public string WebDeepLink
        {
            get
            {
                return this.webDeepLink;
            }
        }

        internal JObject ToJson()
        {
            JObject json = new JObject();
            JObject jsonDeepLinkData = new JObject();
            try
            {
                jsonDeepLinkData.Add(KeyValues.ANDROID_DEEP_LINK_KEY, this.androidDeepLink);
                jsonDeepLinkData.Add(KeyValues.ANDROID_PLAY_STORE_KEY, this.googlePlayStore);
                jsonDeepLinkData.Add(KeyValues.IOS_DEEP_LINK_KEY, this.iosDeepLink);
                jsonDeepLinkData.Add(KeyValues.IOS_APP_STORE_KEY, this.appleAppStore);
                jsonDeepLinkData.Add(KeyValues.WINDOWS_DEEP_LINK_KEY, this.windowsDeepLink);
                jsonDeepLinkData.Add(KeyValues.WINDOWS_STORE_KEY, this.windowsStore);

                json.Add(KeyValues.URI_KEY, this.webDeepLink);
                json.Add(KeyValues.MOBILE_DEEP_LINK_KEY, jsonDeepLinkData);
            }
            catch (Exception e)
            {

            }
            return json;
        }
    }
}
