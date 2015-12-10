using System;
using Newtonsoft.Json.Linq;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCShortLinkItem
    {
        private string mWebDeepLink;
        private string mAndroidDeepLink;
        private string mGooglePlayStore;
        private string mIosDeepLink;
        private string mAppleAppStore;
        private string mWindowsDeepLink;
        private string mWindowsStore;

        public SCShortLinkItem(string webDeepLink,
            string androidDeepLink = null, string googlePlayStore = null,
            string iosDeepLink = null, string appleAppStore = null,
            string windowsDeepLink = null, string windowsStore = null)
        {
            this.mWebDeepLink = webDeepLink;
            this.mAndroidDeepLink = androidDeepLink;
            this.mGooglePlayStore = googlePlayStore;
            this.mIosDeepLink = iosDeepLink;
            this.mAppleAppStore = appleAppStore;
            this.mWindowsDeepLink = windowsDeepLink;
            this.mWindowsStore = windowsStore;
        }

        public string WindowsStore
        {
            get
            {
                return this.mWindowsStore;
            }
        }

        public string WindowsDeepLink
        {
            get
            {
                return this.mWindowsDeepLink;
            }
        }

        public string AppleAppStore
        {
            get
            {
                return this.mAppleAppStore;
            }
        }

        public string GooglePlayStore
        {
            get
            {
                return this.mGooglePlayStore;
            }
        }

        public string IosDeepLink
        {
            get
            {
                return this.mIosDeepLink;
            }
        }

        public string AndroidDeepLink
        {
            get
            {
                return this.mAndroidDeepLink;
            }
        }

        public string WebDeepLink
        {
            get
            {
                return this.mWebDeepLink;
            }
        }

        internal JObject ToJson()
        {
            JObject json = new JObject();
            JObject jsonDeepLinkData = new JObject();
            try
            {
                jsonDeepLinkData.Add(KeyValues.ANDROID_DEEP_LINK_KEY, this.mAndroidDeepLink);
                jsonDeepLinkData.Add(KeyValues.ANDROID_PLAY_STORE_KEY, this.mGooglePlayStore);
                jsonDeepLinkData.Add(KeyValues.IOS_DEEP_LINK_KEY, this.mIosDeepLink);
                jsonDeepLinkData.Add(KeyValues.IOS_APP_STORE_KEY, this.mAppleAppStore);
                jsonDeepLinkData.Add(KeyValues.WINDOWS_DEEP_LINK_KEY, this.mWindowsDeepLink);
                jsonDeepLinkData.Add(KeyValues.WINDOWS_STORE_KEY, this.mWindowsStore);

                json.Add(KeyValues.URI_KEY, this.mWebDeepLink);
                json.Add(KeyValues.MOBILE_DEEP_LINK_KEY, jsonDeepLinkData);
            }
            catch (Exception e)
            {

            }
            return json;
        }
    }
}
