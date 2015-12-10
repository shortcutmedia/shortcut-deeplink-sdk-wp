using System;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCShortLinkBuilder
    {
        //private Context context;

        private string webDeepLink;
        private string androidDeepLink;
        private string googlePlayStore;
        private string iosDeepLink;
        private string appleAppStore;
        private string windowsDeepLink;
        private string windowsStore;

        public SCShortLinkBuilder()
        {

        }

        //public SCShortLinkBuilder(Context context)
        //{
        //    this.context = context;
        //}

        public string WindowsStore
        {
            set
            {
                this.windowsStore = value;
            }
        }

        public string WindowsDeepLink
        {
            set
            {
                this.windowsDeepLink = value;
            }
        }

        public string AppleAppStore
        {
            set
            {
                this.appleAppStore = value;
            }
        }

        public string IosDeepLink
        {
            set
            {
                this.iosDeepLink = value;
            }
        }

        public string GooglePlayStore
        {
            set
            {
                this.googlePlayStore = value;
            }
        }

        public string AndroidDeepLink
        {
            set
            {
                this.androidDeepLink = value;
            }
        }

        public string WebDeepLink
        {
            set
            {
                this.webDeepLink = value;
            }
        }

        public SCShortLinkItem Item
        {
            get
            {
                return new SCShortLinkItem(this.webDeepLink,
                    this.androidDeepLink, this.googlePlayStore,
                    this.iosDeepLink, this.appleAppStore,
                    this.windowsDeepLink, this.windowsStore);
            }
        }

        public void CreateShortLink(SCShortLinkCreateListener callback)
        {
            SCDeepLinking scDeepLinking = SCDeepLinking.GetInstance();
            scDeepLinking.CreateShortLink(Item, callback);
        }
    }
}
