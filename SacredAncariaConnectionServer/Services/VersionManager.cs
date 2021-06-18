using System.Collections.Generic;

namespace SacredAncariaConnectionServer.Services
{
    public static class VersionManager
    {
        public static readonly string LatestVersion = "0.3";
        public static readonly string LatestVersionMessage = "You have the lastest version of SAC Client";
        public static readonly IReadOnlyDictionary<string, string> Versions = new Dictionary<string, string>
        {
            { "0.2", "This version is expired, please go to SAC site at ... to download the new version" },
            { LatestVersion, LatestVersionMessage }
        };

        public static readonly string Motd = "Server hosted by s2cm.net, credits to Lain";
    }
}
