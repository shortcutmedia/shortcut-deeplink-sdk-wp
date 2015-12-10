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
    }
}
