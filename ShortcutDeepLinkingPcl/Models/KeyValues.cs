using System;

namespace Shortcut.DeepLinking.Pcl
{
    internal static class KeyValues
    {
        internal const string REQUEST_BASE_URL = "https://shortcut-service.shortcutmedia.com";

        internal const string PLATFORM_KEY = "platform";
        internal const string PLATFORM_VALUE = "Windows Phone";
        internal const string PLATFORM_VERSION_KEY = "platform_version";
        internal const string PLATFORM_BUILD_KEY = "platform_build";
        internal const string MODEL_KEY = "model";

        internal const string DEVICE_ID_KEY = "sc_device_id";
        internal const string SESSION_ID_KEY = "sc_session_id";
        internal const string LINK_ID_KEY = "sc_link_id";
        internal const string DEEP_LINK_KEY = "uri";
        internal const string DEEP_LINK_ITEM_KEY = "deep_link_item";
        internal const string SHORT_URL_RESPONSE_KEY = "short_url";

        internal const string URI_KEY = "uri";
        internal const string MOBILE_DEEP_LINK_KEY = "mobile_deep_link";
        internal const string ANDROID_DEEP_LINK_KEY = "android_in_app_url";
        internal const string ANDROID_PLAY_STORE_KEY = "android_app_store_url";
        internal const string IOS_DEEP_LINK_KEY = "ios_in_app_url";
        internal const string IOS_APP_STORE_KEY = "ios_app_store_url";
        internal const string WINDOWS_DEEP_LINK_KEY = "windows_in_app_url";
        internal const string WINDOWS_STORE_KEY = "windows_app_store_url";

        internal const int ENVIRONMENT_SANDBOX = 0;
        internal const int ENVIRONMENT_PRODUCTION = 1;

        private static string AUTH_TOKEN_KEY = "sc.shortcut.sdk.deeplinking.authToken";
        private static string ENVIRONMENT_KEY = "sc.shortcut.sdk.deeplinking.environment";
        private static string LOG_LEVEL_KEY = "sc.shortcut.sdk.deeplinking.logLevel";

        public static string LOG_TAG = "SCDeepLinking";
        public static int LOG_LEVEL_VERBOSE = 2;
        public static int LOG_LEVEL_DEBUG = 3;
        public static int LOG_LEVEL_INFO = 4;
        public static int LOG_LEVEL_WARN = 5;
        public static int LOG_LEVEL_ERROR = 6;
    }
}
