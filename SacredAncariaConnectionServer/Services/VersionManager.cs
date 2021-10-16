using System.Collections.Generic;

namespace SacredAncariaConnectionServer.Services
{
    public static class VersionManager
    {
        public static readonly string LatestVersion = "1.1";
        public static readonly string LatestVersionMessage = "You have the latest version of SAC Client";

        private static readonly string S2cm = "This version is expired, please go to SAC site at sac.s2cm.net to download the new version";

        public static readonly IReadOnlyDictionary<string, string> Versions = new Dictionary<string, string>
        {
            { "0.2", S2cm },
            { "0.3", S2cm },
            { "1.0", S2cm },
            { LatestVersion, LatestVersionMessage }
        };

        public static readonly string Motd = "Server hosted by s2cm.net, credits to Lain";
    }
}
