using Bost.AgentsHub.Data;
using Bost.Shared.Abstractions.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
