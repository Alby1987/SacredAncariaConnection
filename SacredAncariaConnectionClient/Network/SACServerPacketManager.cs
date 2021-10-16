using SacredAncariaConnectionClient.Models;
using SacredAncariaConnectionClient.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacredAncariaConnectionClient.Network
{
    internal class SACServerPacketManager
    {
        private Context _context;
        private ISACServerCommunication _sacServerCommunication;

        internal void Init(Context context, ISACServerCommunication sacServerCommunication)
        {
            _context = context;
            _sacServerCommunication = sacServerCommunication;
        }

        internal async Task LoopAsync(int waittime = 7000, int timeout = 15000)
        {
            while (true)
            {
                var utcnow = DateTime.UtcNow;
                Server[] serversToRemoveArray = null;

                var serversToScan = _context.MyServers.Values.ToList();
                var serversToRemove = new List<Server>();
                foreach (var server in serversToScan)
                {
                    if (server.server.LastUpdate.AddMilliseconds(timeout) < utcnow)
                    {
                        while (_context.MyServers.ContainsKey(server.server.Port))
                        {
                            _context.MyServers.TryRemove(server.server.Port, out _);
                        }

                        serversToRemove.Add(server.server);
                    }
                }
                serversToRemoveArray = serversToRemove.ToArray();

                if (serversToRemoveArray.Length != 0)
                {
                    await _sacServerCommunication.RemoveServers(serversToRemoveArray);
                }

                if (_context.MyServers.Count != 0 && _context.Hosting)
                {
                    var response = await _sacServerCommunication.PostServers(_context.MyServers.Values.Select(x => x.server).ToArray());
                    if (response != null)
                    {
                        foreach (var serverResponse in response)
                        {
                            if (_context.MyServers.TryGetValue(serverResponse.Port, out var server))
                            {
                                _context.MyServers[serverResponse.Port] = (serverResponse, server.server);
                            }
                        }
                    }
                    else
                    {
                        _context.MyServers.Clear();
                    }
                }
                _context.SendServerPostedEvent();

                var servers = await _sacServerCommunication.GetServersAsync();
                lock (_context.Servers)
                {
                    if (servers != null)
                    {
                        _context.Servers = servers.Servers.Select(x => Server.ServerFromBase64(x.PacketBase64)).ToArray();
                        _context.MyIp = Utils.ConvertIP(servers.YourIp);
                        _context.UpdateMessage = servers.UpdateMessage;
                        _context.Motd = servers.Motd;
                        _context.ToUpdate = servers.ToUpdate;
                        _context.Connected = !servers.ToUpdate;
                    }
                    else
                    {
                        _context.Connected = false;
                    }
                }

                _context.SendServerReceivedEvent();
                await Task.Delay(waittime);
            }
        }
    }
}
