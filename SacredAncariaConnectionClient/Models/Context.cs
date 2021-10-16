using SacredAncariaConnectionClient.Network;
using SacredAncariaConnectionClient.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;

namespace SacredAncariaConnectionClient.Models
{
    internal class Context
    {
        internal event EventHandler ServerPosted;
        internal event EventHandler ServerReceived;

        internal string SACServerAddress { get; set; } = ConfigurationManager.AppSettings["DefaultSACServerAddress"];
        internal ConcurrentDictionary<int, (MyServerStatus serverStatus, Server server)> MyServers { get; set; } = new ConcurrentDictionary<int, (MyServerStatus serverStatus, Server server)>();
        internal Server[] Servers { get; set; } = new Server[0];
        internal byte[] MyIp { get; set; } = { 0, 0, 0, 0 };
        internal bool ForceIP { get; set; } = false;
        internal byte[] ForceIPAddress { get; set; } = { 0, 0, 0, 0 };
        internal int ServerPort { get; set; } = 2006;
        internal int ClientPort { get; set; } = 2005;
        internal bool BroadcastInLan { get; set; } = false;
        internal bool Hosting { get; set; } = false;
        internal string UpdateMessage { get; set; } = "";
        internal string Motd { get; set; } = "";
        internal bool ToUpdate { get; set; } = false;
        internal bool Connected { get; set; } = false;

        internal Dictionary<string, string> Configuration
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { nameof(ConfigurationEntries.NETWORK_PORT_LISTEN), ServerPort.ToString() },
                    { nameof(ConfigurationEntries.NETWORK_PORT_BROADCAST), ClientPort.ToString() },
                    { nameof(ConfigurationEntries.IP_ADDRESS), Utils.ConvertIP(ForceIPAddress) },
                    { nameof(ConfigurationEntries.FORCE_ADDRESS), ForceIP.ToString() },
                    { nameof(ConfigurationEntries.SACSERVER_ADDRESS), SACServerAddress },
                    { nameof(ConfigurationEntries.LAN_BROADCAST), BroadcastInLan.ToString() },
                    { nameof(ConfigurationEntries.HOSTING), Hosting.ToString() }
                };
            }

            set
            {
                ForceIPAddress = Utils.ConvertIP(value[nameof(ConfigurationEntries.IP_ADDRESS)]);
                ClientPort = int.Parse(value[nameof(ConfigurationEntries.NETWORK_PORT_BROADCAST)]);
                ServerPort = int.Parse(value[nameof(ConfigurationEntries.NETWORK_PORT_LISTEN)]);
                ForceIP = bool.Parse(value[nameof(ConfigurationEntries.FORCE_ADDRESS)]);
                SACServerAddress = value[nameof(ConfigurationEntries.SACSERVER_ADDRESS)];
                BroadcastInLan = bool.Parse(value[nameof(ConfigurationEntries.LAN_BROADCAST)]);
                Hosting = bool.Parse(value[nameof(ConfigurationEntries.HOSTING)]);
            }
        }

        internal void SendServerPostedEvent()
        {
            ServerPosted?.Invoke(this, EventArgs.Empty);
        }

        internal void SendServerReceivedEvent()
        {
            ServerReceived?.Invoke(this, EventArgs.Empty);
        }
    }

    internal enum ConfigurationEntries
    {
        SACSERVER_ADDRESS,
        NETWORK_PORT_LISTEN,
        IP_ADDRESS,
        FORCE_ADDRESS,
        NETWORK_PORT_BROADCAST,
        LAN_BROADCAST,
        HOSTING
    }
}