using System;
using System.Text.Json.Serialization;

namespace SacredAncariaConnectionServer.Models
{
    public class Server
    {
        public string Name { get; set; }

        public int Port { get; set; }

        public string PacketBase64 { get; set; }

        public string IpAddess { get; set; }

        [JsonIgnore]
        public DateTime LastRefresh { get; set; }

        [JsonIgnore]
        internal PortState PortState { get; set; }
    }

    public class ServerResponse
    {
        public string Name { get; }

        public string PacketBase64 { get; }

        public string PortState { get; }

        public ServerResponse(Server server)
        {
            Name = server.Name;
            PacketBase64 = server.PacketBase64;
            PortState = server.PortState.ToString();
        }
    }

    public class ServerListResponse
    {
        public ServerResponse[] Servers { get; set; } = Array.Empty<ServerResponse>();

        public string Motd { get; set; } = "";

        public string UpdateMessage { get; set; } = "";

        public bool ToUpdate { get; set; } = false;

        public string YourIp { get; set; } = "";
    }

    public class ServerAddResponse
    {
        public int Port { get; set; }

        public PortState PortState { get; set; } = PortState.Unchecked;

        public bool NameAlreadyUsed { get; set; } = false;
    }

    public enum PortState
    {
        Unchecked,
        Reachable,
        Unreachable
    }
}
