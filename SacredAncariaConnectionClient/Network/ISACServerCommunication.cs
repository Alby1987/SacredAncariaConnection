using SacredAncariaConnectionClient.Models;
using System.Threading.Tasks;

namespace SacredAncariaConnectionClient.Network
{
    public interface ISACServerCommunication
    {
        Task<ServerList> GetServersAsync();
        Task<MyServerStatus[]> PostServers(Server[] server);
        Task RemoveServers(Server[] server);
    }

    public enum PortState
    {
        Unchecked,
        Reachable,
        Unreachable
    }

    public class ServerList
    {
        public bool Connected { get; set; } = false;

        public Server[] Servers { get; set; } = new Server[0];

        public string Motd { get; set; } = "";

        public string UpdateMessage { get; set; } = "";

        public bool ToUpdate { get; set; } = false;

        public string YourIp { get; set; } = "";
    }

    public class MyServerStatus
    {
        public int Port { get; set; }
        public PortState PortState { get; set; }
        public bool NameAlreadyUsed { get; set; }

        internal string GetPortStatus()
        {
            switch (PortState)
            {
                case PortState.Unchecked:
                    {
                        return "Unchecked";
                    }
                case PortState.Reachable:
                    {
                        return "Reachable";
                    }
                case PortState.Unreachable:
                    {
                        return "Unreachable";
                    }
            }
            return null;
        }
    }
}
