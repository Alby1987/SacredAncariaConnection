using Microsoft.AspNetCore.Mvc;
using SacredAncariaConnectionServer.Models;
using SacredAncariaConnectionServer.Services;
using System;

namespace SacredAncariaConnectionServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(NoStore = true, Duration = 0, Location = ResponseCacheLocation.None)]
    public class Servers : ControllerBase
    {
        [HttpGet("{version}")]
        public ActionResult Get([FromServices] IServersList servers, string version)
        {
            if (version != VersionManager.LatestVersion)
            {
                if (!VersionManager.Versions.TryGetValue(version, out var message))
                {
                    message = "Please update";
                };

                return Ok(new ServerListResponse
                {
                    ToUpdate = true,
                    UpdateMessage = message,
                    Motd = VersionManager.Motd,
                    Servers = Array.Empty<ServerResponse>(),
                    YourIp = HttpContext.Connection.RemoteIpAddress?.ToString()
                });
            }

            return Ok(new ServerListResponse
            {
                ToUpdate = false,
                UpdateMessage = string.Empty,
                Motd = VersionManager.Motd,
                Servers = servers.GetServers(),
                YourIp = HttpContext.Connection.RemoteIpAddress?.ToString()
            });
        }

        [HttpPost]
        public ActionResult Post([FromBody] Server[] serversToAdd, [FromServices] IServersList servers)
        {
            var toSend = servers.AddServers(serversToAdd);
            return Ok(toSend);
        }

        [HttpPost("delete")]
        public ActionResult Delete([FromBody] Server[] serversToDelete, [FromServices] IServersList servers)
        {
            servers.DeleteServers(serversToDelete);
            return Ok();
        }
    }
}
