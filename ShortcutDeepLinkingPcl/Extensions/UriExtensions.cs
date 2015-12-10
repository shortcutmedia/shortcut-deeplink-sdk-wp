using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Shortcut.DeepLinking.Pcl
{
    internal static class UriExtensions
    {
        private static readonly Regex _regex = new Regex(@"[?|&]([\w\.]+)=([^?|^&]+)");

        internal static IReadOnlyDictionary<string, string> ParseQueryString(this Uri uri)
        {
            var match = _regex.Match(uri.PathAndQuery);
            var parameters = new Dictionary<string, string>();
            while (match.Success)
            {
                parameters.Add(match.Groups[1].Value, match.Groups[2].Value);
                match = match.NextMatch();
            }
            return parameters;
        }

        internal static Uri StripQueryParameter(this Uri uri, string key)
        {
            if (String.IsNullOrWhiteSpace(uri.Query) || String.IsNullOrWhiteSpace(key))
                return uri;

            var absoluteUriWithoutQuery = uri.AbsoluteUri.Split('?')[0];
            var excludeKeys = new Dictionary<string, string>();
            excludeKeys.Add(key, "");
            var queryString = HttpUtility.ParseQueryString(uri.Query).ToString(true, excludeKeys);

            if (queryString.Length == 0)
            {
                uri = new Uri(absoluteUriWithoutQuery);
            }
            else
            {
                uri = new Uri(String.Format("{0}?{1}",
                    absoluteUriWithoutQuery, 
                    queryString));
            }
            return uri;
        }
    }
}
