using System;
using System.Net.NetworkInformation;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCUtils
    {
        public static string GetDeviceIdInternal()
        {
            return "35" +
                "1234567890123";
        }

        public static bool HasPermission()
        {
            return true;
        }

        /// <summary>
        /// Returns true if network is available.
        /// </summary>
        /// <returns></returns>
        public static bool IsNetworkAvailable()
        {
            bool isConnected = NetworkInterface.GetIsNetworkAvailable();
            if (!isConnected)
            {
                //await new MessageDialog("No internet connection is avaliable. The full functionality of the app isn't avaliable.").ShowAsync();
            }
            else
            {
                //ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
                //NetworkConnectivityLevel connection = InternetConnectionProfile.GetNetworkConnectivityLevel();
                //if (connection == NetworkConnectivityLevel.None || connection == NetworkConnectivityLevel.LocalAccess)
                //{
                //    isConnected = false;
                //}
            }
            return isConnected;
        }
    }
}
