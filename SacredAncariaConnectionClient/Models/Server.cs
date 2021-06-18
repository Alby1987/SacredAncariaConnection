using Newtonsoft.Json;
using SacredAncariaConnectionClient.Utilities;
using System;
using System.Text;

namespace SacredAncariaConnectionClient.Models
{
    public class Server
    {
        public string Name { get; set; }

        public int Port { get; set; }

        public string PacketBase64 { get; set; }

        [JsonIgnore]
        public byte[] Ip { get; set; }

        [JsonIgnore]
        public bool Locked { get; set; }

        [JsonIgnore]
        public bool Started { get; set; }

        [JsonIgnore]
        public int GameMode { get; set; }

        [JsonIgnore]
        public int Difficulty { get; set; }

        [JsonIgnore]
        public int CurNumber { get; set; }

        [JsonIgnore]
        public int MaxNumber { get; set; }

        [JsonIgnore]
        public bool Pass { get; set; }

        [JsonIgnore]
        public DateTime LastUpdate { get; set; }

        [JsonIgnore]
        public byte[] PacketToSacredClient { get; set; }

        public string IpAddess
        {
            get
            {
                return Utils.ConvertIP(Ip);
            }
            set
            {
                Ip = Utils.ConvertIP(value);
            }
        }

        private Server()
        {
        }

        internal static Server ServerFromUncompressedData(byte[] data)
        {
            var toReturn = new Server();

            var name = new byte[48];

            Array.Copy(data, 14, name, 0, 48);

            var unicode = new UnicodeEncoding(false, false);

            toReturn.Name = unicode.GetString(name).Trim('\u0000');

            toReturn.Ip = new byte[] { data[7], data[6], data[5], data[4] };

            int b0 = 0;
            int b1 = 0;
            b0 |= data[2];
            b1 |= data[3];
            toReturn.Port = b1 * 256 + b0;

            toReturn.Locked = (data[8] & 4) != 0;
            toReturn.Pass = (data[8] & 2) != 0;
            toReturn.Started = data[8] >> 7 != 0;

            toReturn.GameMode = (data[8] >> 4) & 7;
            toReturn.Difficulty = data[9];

            toReturn.CurNumber = data[12];
            toReturn.MaxNumber = data[13];

            return toReturn;
        }

        internal static Server ServerFromBase64(string base64)
        {
            var dataCompressed = Convert.FromBase64String(base64);
            var uncompressedData = Utils.DecompressData(dataCompressed);
            var server = ServerFromUncompressedData(uncompressedData);
            server.PacketToSacredClient = dataCompressed;
            server.PacketBase64 = base64;
            return server;
        }

        internal string GetIPPort()
        {
            return $"{Utils.ConvertIP(Ip)}:{Port}";
        }

        internal string GetUsers()
        {
            return $"{CurNumber}/{MaxNumber}";
        }

        internal string GetDifficulty()
        {
            switch (Difficulty)
            {
                case 0:
                    return "Bronze";
                case 1:
                    return "Silver";
                case 2:
                    return "Gold";
                case 4:
                    return "Platinum";
                case 8:
                    return "Niobium";
                default:
                    throw new ArgumentException($"Game Difficulty error, {Difficulty}");
            }
        }

        internal string GetGamemode()
        {
            switch (GameMode)
            {
                case 0:
                    return "Underworld Campaign";
                case 1:
                    return "Campaign";
                case 2:
                    return "Free";
                case 4:
                    return "Playerkiller";
                default:
                    throw new ArgumentException($"Game Mode error, {GameMode}");
            }
        }
    }
}
