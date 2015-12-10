using System;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCSession
    {
        private Uri mDeepLink;
        private string mId;
        private string mLinkId;
        private bool mClosed;

        public SCSession(string DeepLink = "")
        {
            if (!String.IsNullOrWhiteSpace(DeepLink))
                this.mDeepLink = new Uri(DeepLink);
            this.mId = new Random(int.MaxValue - 1).Next().ToString();
        }

        public SCSession(Uri DeepLink)
        {
            this.mDeepLink = DeepLink;
            this.mId = new Random(int.MaxValue - 1).Next().ToString();
        }

        public Uri DeepLink
        {
            get { return this.mDeepLink; }
            set { this.mDeepLink = value; }
        }

        public string Id
        {
            get { return this.mId; }
            private set { this.mId = value; }
        }

        public string LinkId
        {
            get
            {
                if (String.IsNullOrEmpty(this.mLinkId))
                {
                    var queryString = this.mDeepLink.ParseQueryString();
                    if (queryString.ContainsKey(KeyValues.LINK_ID_KEY))
                        this.mLinkId = queryString[KeyValues.LINK_ID_KEY];
                }
                return this.mLinkId;
            }
            private set { this.mLinkId = value; }
        }

        public void Open()
        {
            this.mClosed = false;
        }

        public void Close()
        {
            this.mClosed = true;
        }

        public bool IsClosed()
        {
            return this.mClosed;
        }

        public string ToString()
        {
            return String.Format(@"SESSION_ID={0} SESSION_STATE={1} DEEP_LINK={2}",
                this.mId,
                (this.mClosed ? "closed" : "open"),
                this.mDeepLink);
        }
    }
}
