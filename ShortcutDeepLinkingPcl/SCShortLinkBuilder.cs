using System;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCShortLinkBuilder
    {
        private object mContext;

        private string mWebDeepLink;
        private string mAndroidDeepLink;
        private string mGooglePlayStore;
        private string mIosDeepLink;
        private string mAppleAppStore;
        private string mWindowsDeepLink;
        private string mWindowsStore;

        public SCShortLinkBuilder()
        {

        }

        public SCShortLinkBuilder(object context)
        {
            this.mContext = context;
        }

        public string WindowsStore
        {
            set
            {
                this.mWindowsStore = value;
            }
        }

        public string WindowsDeepLink
        {
            set
            {
                this.mWindowsDeepLink = value;
            }
        }

        public string AppleAppStore
        {
            set
            {
                this.mAppleAppStore = value;
            }
        }

        public string IosDeepLink
        {
            set
            {
                this.mIosDeepLink = value;
            }
        }

        public string GooglePlayStore
        {
            set
            {
                this.mGooglePlayStore = value;
            }
        }

        public string AndroidDeepLink
        {
            set
            {
                this.mAndroidDeepLink = value;
            }
        }

        public string WebDeepLink
        {
            set
            {
                this.mWebDeepLink = value;
            }
        }

        public SCShortLinkItem Item
        {
            get
            {
                return new SCShortLinkItem(this.mWebDeepLink,
                    this.mAndroidDeepLink, this.mGooglePlayStore,
                    this.mIosDeepLink, this.mAppleAppStore,
                    this.mWindowsDeepLink, this.mWindowsStore);
            }
        }

        public void CreateShortLink(ISCShortLinkCreateListener callback)
        {
            SCDeepLinking scDeepLinking = SCDeepLinking.GetInstance();
            scDeepLinking.CreateShortLink(Item, callback);
        }
    }
}
