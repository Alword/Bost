using System.Threading.Tasks;

namespace Bost.Shared.Abstractions.Hubs
{
	public interface IControlHubClient
	{
		Task ReciveServerStatus(ServerStatusData serverStatuses);
		Task RecoveAddedAgent(ServerStatusData serverStatuses);
		Task ReciveInventoryUpdate(ServerStatusData serverStatuses);
		Task ReciveStatsUpdate(ServerStatusData serverStatuses);
		Task RecivePositionUpdate(ServerStatusData serverStatuses);
	}
}
