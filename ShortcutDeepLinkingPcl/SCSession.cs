using System;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCSession
    {
        private Uri deepLink;
        private string id;
        private string linkId;
        private bool closed;

        public SCSession(string DeepLink = "")
        {
            if (!String.IsNullOrWhiteSpace(DeepLink))
                this.deepLink = new Uri(DeepLink);
            this.id = new Random(int.MaxValue - 1).Next().ToString();
        }

        public SCSession(Uri DeepLink)
        {
            this.deepLink = DeepLink;
            this.id = new Random(int.MaxValue - 1).Next().ToString();
        }

        public Uri DeepLink
        {
            get { return this.deepLink; }
            set { this.deepLink = value; }
        }

        public string Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public string LinkId
        {
            get
            {
                if (String.IsNullOrEmpty(this.linkId))
                {
                    var queryString = this.deepLink.ParseQueryString();
                    if (queryString.ContainsKey(KeyValues.LINK_ID_KEY))
                        this.linkId = queryString[KeyValues.LINK_ID_KEY];
                }
                return this.linkId;
            }
            private set { this.linkId = value; }
        }

        public void Open()
        {
            this.closed = false;
        }

        public void Close()
        {
            this.closed = true;
        }

        public bool IsClosed()
        {
            return this.closed;
        }

        public string ToString()
        {
            return String.Format(@"SESSION_ID={0} SESSION_STATE={1} DEEP_LINK={2}",
                this.id,
                (this.closed ? "closed" : "open"),
                this.deepLink);
        }
    }
}
