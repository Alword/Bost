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

        public async ValueTask RemoveServer(string ipPort)
        {
            var server = context.Servers.FirstOrDefault(d => d.IpPort == ipPort);
            if (server == null) return;

            context.Remove(server);
            await context.SaveChangesAsync().ConfigureAwait(false);

            await Clients.All.ReciveServerRemove(ipPort);
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
            if (server.IpPort == null || !server.IpPort.Contains(":"))
            {
                var serverToRemove = context.Servers.SingleOrDefault(s => s.IpPort == server.IpPort);
                context.Remove(serverToRemove);
                context.SaveChanges();
                return;
            }

            var split = server.IpPort.Split(":");
            StatusPing statusPing = new StatusPing(split[0], ushort.Parse(split[1]));
            var ping = await statusPing.RequestStatus();

            ServerStatusData status = new ServerStatusData()
            {
                CoreName = ping.Version.Name,
                Description = ping.Description.Text,
                Max = ping.Players.Max,
                Online = ping.Players.Online,
                Proto = ping.Version.Protocol,
                IpPort = server.IpPort,
                Name = server.Name,
                Id = server.Id
            };

            await Clients.All.ReciveServerStatus(status);
        }
    }
}
