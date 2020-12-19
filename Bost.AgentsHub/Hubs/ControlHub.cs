using Bost.AgentsHub.Data;
using Bost.Shared.Abstractions.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Bost.AgentsHub.Hubs
{
	public class ControlHub : Hub<IControlHubClient>
	{
		private readonly AgentsContext context;
		public ControlHub(AgentsContext context)
		{
			this.context = context;
		}
	}
}
