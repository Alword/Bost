using Bost.Shared;
using System.Threading.Tasks;

namespace Bost.AgentsHub.Abstractions.Hubs
{
	public interface IServersHubClient
	{
		Task ReciveServerStatus(ServerStatusData serverStatuses);
		Task ReciveServerRemove(string ipport);
	}
}
