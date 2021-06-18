using SacredAncariaConnectionClient.Models;
using SacredAncariaConnectionClient.Utilities;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SacredAncariaConnectionClient.Network
{
    internal class UdpPacketManager
    {
        private Context _context;

        internal void Init(Context context)
        {
            _context = context;
        }

        internal async Task AcceptServerAsync()
        {
            byte[] data;
            var ipep = new IPEndPoint(IPAddress.Any, _context.ServerPort);
            var ipepBroadcast = new IPEndPoint(IPAddress.Broadcast, _context.ClientPort);

            IPEndPoint sender;
            using (var newsock = new UdpClient(ipep))
            {
                while (true)
                {
                    if (!_context.Connected)
                    {
                        await Task.Delay(1000);
                        continue;
                    }

                    byte[] ipAddress;
                    if (_context.ForceIP)
                    {
                        ipAddress = _context.ForceIPAddress;
                    }
                    else
                    {
                        ipAddress = _context.MyIp;
                    }

                    try
                    {
                        var received = await newsock.ReceiveAsync();
                        data = received.Buffer;
                        sender = received.RemoteEndPoint;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    try
                    {
                        var uncompressedData = Utils.DecompressData(data);

                        uncompressedData[4] = ipAddress[3];
                        uncompressedData[5] = ipAddress[2];
                        uncompressedData[6] = ipAddress[1];
                        uncompressedData[7] = ipAddress[0];

                        byte[] originalHeader = new byte[4];
                        Array.Copy(data, originalHeader, 4);

                        var (resultArray, base64) = Utils.CompressData(originalHeader, uncompressedData);

                        if (_context.BroadcastInLan)
                        {
                            await newsock.SendAsync(data, data.Length, ipepBroadcast);
                        }

                        var server = Server.ServerFromUncompressedData(uncompressedData);

                        if (_context.MyServers.TryGetValue(server.Port, out var serverCache) && serverCache.server.PacketBase64 == base64)
                        {
                            serverCache.server.LastUpdate = DateTime.UtcNow;
                            _context.MyServers[serverCache.server.Port] = serverCache;
                            continue;
                        }
                        server.PacketBase64 = base64;
                        server.PacketToSacredClient = resultArray;
                        server.LastUpdate = DateTime.UtcNow;

                        _context.MyServers[server.Port] = (null, server);
                    }

                    catch
                    {
                        continue;
                    }
                }
            }
        }

        internal async Task SendServersToClientAsync(int waitTime = 1000)
        {
            var ipep = new IPEndPoint(IPAddress.Loopback, _context.ClientPort);
            using (var newsock = new UdpClient())
            {
                while (true)
                {
                    string[] myServersBase64;
                    Server[] servers;
                    myServersBase64 = _context.MyServers.Values.Select(x => x.server.PacketBase64).ToArray();

                    lock (_context.Servers)
                    {
                        servers = _context.Servers.ToArray();
                    }

                    foreach (var server in servers)
                    {
                        if (_context.BroadcastInLan && myServersBase64.Contains(server.PacketBase64))
                        {
                            continue;
                        }

                        await newsock.SendAsync(server.PacketToSacredClient, server.PacketToSacredClient.Length, ipep);
                    }
                    await Task.Delay(waitTime);
                }
            }
        }
    }
}