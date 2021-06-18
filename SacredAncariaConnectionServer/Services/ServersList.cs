using SacredAncariaConnectionServer.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SacredAncariaConnectionServer.Services
{
    public interface IServersList
    {
        ServerResponse[] GetServers();
        ServerAddResponse[] AddServers(Server[] servers);
        void DeleteServers(Server[] servers);
    }

    public class ServersList : IServersList
    {
        private readonly ConcurrentDictionary<(string ip, int port), Server> _servers = new ConcurrentDictionary<(string ip, int port), Server>();


        public ServersList()
        {
            Task.Run(() => Maintenance());
        }

        public async Task Maintenance()
        {
            while (true)
            {
                var now = DateTime.UtcNow;
                var toDelete = _servers.Where(x => x.Value.LastRefresh.AddMilliseconds(15000) < now);
                foreach (var keyToDelete in toDelete)
                {
                    _servers.TryRemove(keyToDelete);
                }

                var toCheck = _servers.Where(x => x.Value.PortState == PortState.Unchecked);
                foreach (var serverToCheck in toCheck)
                {
                    using var client = new TcpClient();
                    try
                    {
                        var ipAddress = IPAddress.Parse(serverToCheck.Value.IpAddess);
                        client.Connect(ipAddress, serverToCheck.Value.Port);
                        if (client.Connected)
                        {
                            _servers[serverToCheck.Key].PortState = PortState.Reachable;
                        }
                        else
                        {
                            _servers[serverToCheck.Key].PortState = PortState.Unreachable;
                        }
                    }
                    catch
                    {
                        _servers[serverToCheck.Key].PortState = PortState.Unreachable;
                    }
                }
                await Task.Delay(15000);
            }
        }

        public ServerAddResponse[] AddServers(Server[] servers)
        {
            var toReturn = new List<ServerAddResponse>();
            string[] names = null;
            foreach (var server in servers)
            {
                var toAdd = new ServerAddResponse
                {
                    Port = server.Port
                };

                if (_servers.TryGetValue((server.IpAddess, server.Port), out var serverRegistered))
                {
                    serverRegistered.LastRefresh = DateTime.UtcNow;
                    serverRegistered.PacketBase64 = server.PacketBase64;
                    toAdd.PortState = serverRegistered.PortState;
                }
                else
                {
                    if (names == null)
                    {
                        names = _servers.Values.Select(x => x.Name).ToArray();
                    }

                    if (names.Contains(server.Name))
                    {
                        toAdd.NameAlreadyUsed = true;
                    }
                    else
                    {
                        _servers.TryAdd((server.IpAddess, server.Port), server);
                    }
                }

                toReturn.Add(toAdd);
            }

            return toReturn.ToArray();
        }

        public ServerResponse[] GetServers()
        {
            return _servers.Values.Where(x => x.PortState == PortState.Reachable).Select(x => new ServerResponse(x)).ToArray();
        }

        public void DeleteServers(Server[] servers)
        {
            foreach (var server in servers)
            {
                var key = (server.IpAddess, server.Port);
                _servers.TryRemove(key, out _);
            }
        }
    }
}
