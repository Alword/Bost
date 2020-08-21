using Bost.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bost.AgentsHub.Abstractions.Hubs
{
    public interface IServersHubClient
    {
        Task ReciveServerStatus(ServerStatusData serverStatuses);
    }
}
