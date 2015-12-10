using System;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCPreference
    {
        private object mContext;
        private object mSharedPreferences;
        private object mEditor;

        public SCPreference()
        {
        }

        public SCPreference(object context)
        {
            mContext = context;
        }

        public string DeviceId
        {
            get { return SCUtils.GetDeviceIdInternal(); }
        }

        public void SetFirstLaunch(bool value)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public bool IsFirstLaunch()
        {
            throw new NotImplementedException();
        }
    }
}
