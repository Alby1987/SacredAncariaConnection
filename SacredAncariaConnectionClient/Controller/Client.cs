using SacredAncariaConnectionClient.Models;
using SacredAncariaConnectionClient.Network;
using SacredAncariaConnectionClient.Utilities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SacredAncariaConnectionClient.Controller
{
    internal class Client
    {
        private readonly Context _context;
        private readonly UdpPacketManager _udpPacketManager;
        private readonly SACServerPacketManager _sacServerPackerManager;

        internal Client(Context context)
        {
            _context = context;
            _udpPacketManager = new UdpPacketManager();
            _sacServerPackerManager = new SACServerPacketManager();
        }

        internal bool ReadConfiguration()
        {
            var cfgPath = Path.Combine(Directory.GetCurrentDirectory(), "SacredAncariaConnectionClient.cfg");
            var configuration = Utils.ReadConfiguration(cfgPath);
            if (configuration == null)
            {
                Utils.WriteConfiguration(cfgPath, _context.Configuration);
                return true;
            }
            try
            {
                _context.Configuration = configuration;
            }
            catch (Exception)
            {
                Utils.WriteConfiguration(cfgPath, _context.Configuration);
            }

            return false;
        }

        internal void SetForcedIP(byte[] ip)
        {
            _context.ForceIPAddress = ip;
        }

        internal void SetBroadcastInLAN(bool broadcastInLAN)
        {
            _context.BroadcastInLan = broadcastInLAN;
        }

        internal void SetForceIP(bool forceip)
        {
            _context.ForceIP = forceip;
        }

        internal void Init()
        {
            _udpPacketManager.Init(_context);
            _sacServerPackerManager.Init(_context, new SACServerCommunication(_context));
            Task.Run(async () => await _udpPacketManager.AcceptServerAsync());
            Task.Run(async () => await _udpPacketManager.SendServersToClientAsync());
            Task.Run(async () => await _sacServerPackerManager.LoopAsync());
        }

        internal void Close()
        {
            var cfgPath = Path.Combine(Directory.GetCurrentDirectory(), "SacredAncariaConnectionClient.cfg");
            Utils.WriteConfiguration(cfgPath, _context.Configuration);
        }
    }
}
