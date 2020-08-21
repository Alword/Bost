using Bost.Agent.Jobs;
using Bost.AgentsHub.Abstractions.Hubs;
using Bost.AgentsHub.Data;
using Bost.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace Bost.AgentsHub.Hubs
{
    public class ServersHub : Hub<IServersHubClient>
    {
        private readonly AgentsContext context;
        public ServersHub(AgentsContext context)
        {
            this.context = context;
        }

        public async Task AddServer(string name, string ipPort)
        {
            var server = new Server()
            {
                IpPort = ipPort,
                Name = name
            };

            context.Servers.Add(server);
            await context.SaveChangesAsync();
            await PingServer(server);
        }

        public async override Task OnConnectedAsync()
        {
            var servers = context.Servers.ToArray();
            foreach (var server in servers)
            {
                await PingServer(server);
            }

        }

        private async Task PingServer(Server server)
        {
            var split = server.IpPort.Split(":");
            StatusPing statusPing = new StatusPing(split[0], ushort.Parse(split[1]));
            var ping = await statusPing.RequestStatus();

            ServerStatusData status = new ServerStatusData()
            {
                CoreName = ping.Version.Name,
                Description = ping.Description.Text,
                Max = ping.Players.Max,
                Online = ping.Players.Online,
                Name = server.Name,
                Proto = ping.Version.Protocol
            };

            await Clients.All.ReciveServerStatus(status);
        }
    }
}
