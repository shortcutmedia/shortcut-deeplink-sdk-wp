using System;
using System.Collections.Generic;

namespace Shortcut.DeepLinking.Pcl
{
    /// <summary>
    /// The SCDeepLinking class acts as central interaction point with the SDK.
    /// 
    /// It is implemented as a singleton: Use the SCDeepLinking.GetInstance method to get the
    /// singleton instance.
    /// </summary>
    public class SCDeepLinking
    {
        private static SCDeepLinking mDeepLinking;
        private SCPreference mPreference;
        private SCSession mSession;
        private SCConfig mConfig;

        private object mContext;
        private string mCurrentActivity;
        private Uri mDeepLinkAtLaunch;
        private Uri mDeepLink;
        private Dictionary<string, SCSession> mSessions;
        private bool mDeviceRotated;

        public SCDeepLinking(SCConfig config, object context)
        {
            this.mConfig = config;
            this.mContext = context;
            this.mPreference = new SCPreference(context);
            this.mSessions = new Dictionary<string, SCSession>();

            //if (context == typeof(SCDeepLinkingApp))
            //{

            //}
        }

        public SCConfig Config
        {
            get
            {
                return this.mConfig;
            }
            private set
            {
                this.mConfig = value;
            }
        }

        public Uri DeepLink
        {
            get
            {
                return this.mDeepLink;
            }
            private set
            {
                this.mDeepLink = value;
            }
        }

        public SCPreference Preference
        {
            get
            {
                return this.mPreference;
            }
            private set
            {
                this.mPreference = value;
            }
        }

        public static SCDeepLinking GetInstance(SCConfig config, object context)
        {
            if (mDeepLinking == null)
            {
                mDeepLinking = new SCDeepLinking(config, context);
            }
            return mDeepLinking;
        }

        public static SCDeepLinking GetInstance()
        {
            return mDeepLinking;
        }

        public bool IsFirstLaunch()
        {
            return this.mPreference.IsFirstLaunch();
        }

        public void StartSession(string intent)
        {
            var activity = String.Empty;
            StartSession(activity, intent);
        }

        public void StartSession(string activity, string intent)
        {
            mDeepLink = null;
            mCurrentActivity = activity;
            mDeepLinkAtLaunch = GetDeepLinkFromIntent(intent);
            SCSession session;

            if (mDeepLinkAtLaunch == null && IsFirstLaunch())
            {
                GenerateSessionId();
                session = mSessions[activity];

                throw new NotImplementedException();
                //PostTask postTask = new PostTask();
                //postTask.Execute(new SCServerRequestRegisterFirstOpen(session));

                try
                {

                }
                catch (Exception e)
                {

                }
            }
            else if (mDeepLinkAtLaunch != null)
            {
                session = mSessions[activity];
                if (session == null)
                {
                    if (!this.mDeviceRotated)
                    {
                        GenerateSessionId();
                        mDeviceRotated = false;
                    }
                    else
                    {
                        SaveSessionId();
                    }
                }

                session = mSessions[activity];
                if (session != null)
                {
                    session.Open();
                    HandleDeepLink(activity, mDeepLinkAtLaunch);

                    throw new NotImplementedException();
                    //PostTask postTask = new PostTask();
                    //postTask.Execute(new SCServerRequestRegisterOpen(session));
                }
            }

            if (IsFirstLaunch())
            {
                mPreference.SetFirstLaunch(false);
            }
        }

        private Uri GetDeepLinkFromIntent(string intent)
        {
            throw new NotImplementedException();
        }

        public void StopSession(string activity)
        {
            SCSession session = mSessions[activity];
            if (session != null && !session.IsClosed())
            {
                session.Close();
                throw new NotImplementedException();
                //PostTask postTask = new PostTask();
                //postTask.Execute(new SCServerRequestRegisterClose(session));
            }
        }

        private void HandleDeepLink(string activity, Uri deepLink)
        {
            String Id = deepLink.Query;
        }

        private void GenerateSessionId()
        {
            this.mSession = new SCSession(this.mDeepLinkAtLaunch);
            SaveSessionId();
        }

        private void SaveSessionId()
        {
            throw new NotImplementedException();
        }

        internal void CreateShortLink(SCShortLinkItem item, SCShortLinkCreateListener callback)
        {
            throw new NotImplementedException();
            //PostTask postTask = new PostTask();
            //postTask.Execute(new SCServerRequestCreateShortLink(this.scSession, item, callback));
        }
    }
}
