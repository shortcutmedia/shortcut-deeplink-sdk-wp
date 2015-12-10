using System;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCPreference
    {
        public string DeviceId
        {
            get { return SCUtils.GetDeviceIdInternal(); }
        }

        internal bool IsFirstLaunch()
        {
            throw new NotImplementedException();
        }
    }
}
