using System;

namespace Shortcut.DeepLinking.Pcl
{
    public interface ISCShortLinkCreateListener
    {
        void OnLinkCreated(string shortLink);
    }
}
