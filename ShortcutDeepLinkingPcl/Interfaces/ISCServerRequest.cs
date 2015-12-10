using System;

namespace Shortcut.DeepLinking.Pcl
{
    /// <summary>
    /// Interface for all requests send to the server API.
    /// </summary>
    public interface ISCServerRequest
    {
        SCConfig Config { get; }

        int Status { get; }

        string DoRequest();

        void OnRequestSucceeded(SCServerResponse response);
    }
}