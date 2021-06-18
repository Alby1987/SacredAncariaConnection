using Newtonsoft.Json;
using SacredAncariaConnectionClient.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SacredAncariaConnectionClient.Network
{
    public class SACServerCommunication : ISACServerCommunication
    {
        private readonly Context _context;

        internal SACServerCommunication(Context context)
        {
            _context = context;
        }

        private ServerList _serverlist = null;

        public async Task<ServerList> GetServersAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStringAsync($@"{_context.SACServerAddress}/api/servers/{Program.Version}");
                    _serverlist = JsonConvert.DeserializeObject<ServerList>(response);
                    return _serverlist;
                }
            }
            catch
            {
                return null;
            }

        }

        public async Task<MyServerStatus[]> PostServers(Server[] servers)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(servers);
                    var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($@"{_context.SACServerAddress}/api/servers", content);
                    var serverStatus = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<MyServerStatus[]>(serverStatus);
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task RemoveServers(Server[] servers)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(servers);
                    var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                    await httpClient.PostAsync($@"{_context.SACServerAddress}/api/servers/delete", content);
                }
            }
            catch
            {

            }
        }
    }
}
