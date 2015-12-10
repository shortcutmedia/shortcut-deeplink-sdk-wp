using System;

namespace Shortcut.DeepLinking.Pcl
{
    internal static class ActionUrls
    {
        private const string Api = "/api/v1/deep_links/";

        internal static string GetActionUrl(string action)
        {
            action.EnsureNotNullOrEmpty();
            return String.Concat(Api, action);
        }

        internal const string FirstOpen = "first_open";
        internal const string Open = "open";
        internal const string Close = "close";
        internal const string Create = "create";
    }
}
